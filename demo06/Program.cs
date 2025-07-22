using System.Dynamic;

internal class Program
{

    /// <summary>
    ///  Interface IMedicalAppointment define un contrato para las citas médicas.
    /// </summary>
    interface IMedicalAppointment
    {
        void ShowAllMedicalAppointment(); // Método para mostrar todas las citas médicas
    }


    /// <summary>
    /// Clase MedicalAppointment implementa la interfaz IMedicalAppointment y representa una cita médica.
    /// </summary>
    
    class MedicalAppointment : IMedicalAppointment
    {
        private int Id { get; set; }
        public DateTime Date { get; set; }
        public string specialty { get; set; }
        public string PacienteFullName { get; set; } // Nombre del paciente asignado a la cita
        public string DoctorFullName { get; set; } // Nombre del doctor asignado a la cita

        public MedicalAppointment(int _id, DateTime _date, string _specialty, Doctor doctor, Patient paciente)
        {
            Id = _id;
            Date = _date;
            specialty = _specialty;
            DoctorFullName = doctor.Name + " " + doctor.LastName;
            PacienteFullName = paciente.Name + " " + paciente.LastName;
        }

        public void ShowAllMedicalAppointment()
        {
            Console.WriteLine($"Cita ID: {Id}, Fecha: {Date.ToShortDateString()}, Especialidad: {specialty}, Paciente: {PacienteFullName}, Doctor: {DoctorFullName}");
        }

        // Notificar sobre una cita médica

    }
    

    // Clase Usuario representa un usuario del sistema
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public User(int _id, string _name, string _lastName, string _dni, string _phone, string _email, int _age)
        {
            Id = _id;
            Name = _name;
            LastName = _lastName;
            Dni = _dni;
            Phone = _phone;
            Email = _email;
            Age = _age;
        }

        // Notificar al usuario sobre una nueva cita médica
        public virtual void Notify()
        {
            Console.WriteLine($"Hola {Name} {LastName}, te notificamos que tienes una nueva cita médica.");
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Name} {LastName}, DNI: {Dni}, Telefono: {Phone}, Email: {Email}, Edad: {Age}";
        }
    }

    // Clase Patient hereda de Usuario y representa un paciente en el sistema
    class Patient : User
    {
        public string nroHistory { get; set; } // Número de historia clínica
        public List<MedicalAppointment> MedicalAppointments { get; set; } = new List<MedicalAppointment>(); // Lista de citas médicas del paciente

        public Patient(int _id, string _name, string _lastName, string _dni, string _phone, string _email, int _age, string _nroHistory)
            : base(_id, _name, _lastName, _dni, _phone, _email, _age)
        {
            nroHistory = _nroHistory;
        }

        public int GetId(int id)
        {
            return Id;
        }
        
        public void AddCita(MedicalAppointment cita)
        {
            MedicalAppointments.Add(cita);
        }

        // Notificar al paciente sobre una nueva cita médica
        public override void Notify()
        {
            Console.WriteLine($"Hola {Name} {LastName}, te notificamos que tienes una nueva cita médica programada el dia {MedicalAppointments.Last().Date.ToShortDateString()} con el doctor {MedicalAppointments.Last().DoctorFullName}.");
        }

        public void ShowAllMedicalAppointment()
        {
            MedicalAppointments.ForEach(cita => Console.WriteLine($"Citas del Paciente {Name} {LastName}: {cita}"));
        }


        public override string ToString()
        {
            return base.ToString() + $", Numero de Historia Clinica: {nroHistory}";

        }


    }

    // Clase Doctor representa un doctor en el sistema

    class Doctor : User
    {
        public string Specialty { get; set; } // Especialidad del doctor
        public string GraduationUniversity { get; set; } // Universidad de egreso del doctor
        public string TuitionNumber { get; set; } // Número de colegiatura del doctor
        public int YearsOfExperience { get; set; } // Años de experiencia del doctor

        public List<MedicalAppointment> MedicalAppointmentsPending { get; set; } = new List<MedicalAppointment>(); // Lista de citas médicas del doctor
        public Doctor(int _id, string _name, string _lastName, string _dni, string _phone, string _email, int _age, string _specialty, string _GraduationUniversity, string _TuitionNumber, int _YearsOfExperience)
            : base(_id, _name, _lastName, _dni, _phone, _email, _age)
        {
            Specialty = _specialty;
            GraduationUniversity = _GraduationUniversity;
            TuitionNumber = _TuitionNumber;
            YearsOfExperience = _YearsOfExperience;
        }

        public int GetId(int id)
        {
            return Id;
        }

        public void AddCitaPending(MedicalAppointment cita)
        {
            MedicalAppointmentsPending.Add(cita);
        }

        // Notificar al doctor sobre una nueva cita médica
        public override void Notify()
        {
            Console.WriteLine($"Hola Dr. {Name} {LastName}, te notificamos que tienes una nueva cita médica programada el dia {MedicalAppointmentsPending.Last().Date.ToShortDateString()} con el paciente {MedicalAppointmentsPending.Last().PacienteFullName}.");
        }


        public override string ToString()
        {
            return base.ToString() + $", Especialidad: {Specialty}, Universidad de Egreso: {GraduationUniversity}, Numero de Colegiatura: {TuitionNumber}, Años de Experiencia: {YearsOfExperience}";
        }
    }

    // Clase Receptionist representa un recepcionista en el sistema

    class Recepcionist : User
    {
        public string WorkSchedule { get; set; } // Horario de trabajo del recepcionista
        public string WorkArea { get; set; } // Área de trabajo del recepcionista
        public List<MedicalAppointment> MedicalAppointmentsPending { get; set; } = new List<MedicalAppointment>(); // Lista de citas médicas pendientes del recepcionista

        public Recepcionist(int _id, string _name, string _lastName, string _dni, string _phone, string _email, int _age, string _workSchedule, string _workArea)
        : base(_id, _name, _lastName, _dni, _phone, _email, _age)
         {
             WorkSchedule = _workSchedule;
             WorkArea = _workArea;
        }

        public void AddCitaPending(MedicalAppointment cita)
        {
            MedicalAppointmentsPending.Add(cita);
        }

        // Notificar al recepcionista sobre una nueva cita médica
        public override void Notify()
        {
            Console.WriteLine($"Hola {Name} {LastName}, te notificamos que tienes una nueva cita médica pendiente para gestionar, el dia {MedicalAppointmentsPending.Last().Date.ToShortDateString()}.");
        }

        public override string ToString()
         {
             return base.ToString() + $", Horario de Trabajo: {WorkSchedule}, Area de Trabajo: {WorkArea}";
        }
    }

    // Clase Hospital representa un hospital
    class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Hospital(int _id, string _name, string _address)
        {
            Id = _id;
            Name = _name;
            Address = _address;
        }


    }

    public static void Main(string[] args)
    {
        // Pacientes 

        List<Patient> pacientes = new List<Patient>()
        {
            new Patient(1, "Juan", "Cruz", "12345678", "7777767", " 987654321", 30, "H12345"),
            new Patient(2, "Maria", "Lopez", "87654321", "8888877", " 923456789", 25, "H54321"),
            new Patient(3, "Pedro", "Gomez", "11223344", "9999988", " 912345678", 40, "H67890"),
            new Patient(4, "Ana", "Martinez", "44332211", "6666655", " 901234567", 35, "H09876"),
        };

        // Doctores
        List<Doctor> doctores = new List<Doctor>()
        {
            new Doctor(1, "Jose", "Perez Gonzalez", "12345678", "7777767", "987654321", 45, "Cardiologia", "Universidad Nacional", "D12345", 53),
            new Doctor(2, "Juan", "Hernandez Cuña", "87654321", "8888877", "923456789", 38, "Pediatria", "Universidad Estatal", "D54321", 34),
            new Doctor(3, "Ramon", "Torres Lopez", "11223344", "9999988", "912345678", 50, "Dermatologia", "Universidad Privada", "D67890", 32),
            new Doctor(4, "Maria", "Sanchez Martinez", "44332211", "6666655", "901234567", 42, "Ginecologia", "Universidad Tecnologica", "D09876", 43),
            };

        // Recepcionistas

        List<Recepcionist> recepcionistas = new List<Recepcionist>()
        {
            new Recepcionist(1, "Laura", "Fernandez", "12345678", "7777767", "987654321", 28, "Lunes a Viernes 8am - 5pm", "Atencion al Cliente"),
            new Recepcionist(2, "Carlos", "Gonzalez", "87654321", "8888877", "923456789", 30, "Lunes a Sabado 9am - 6pm", "Administracion"),
            new Recepcionist(3, "Sofia", "Lopez", "11223344", "9999988", "912345678", 26, "Martes a Domingo 10am - 7pm", "Recepcion"),
            new Recepcionist(4, "Miguel", "Martinez", "44332211", "6666655", "901234567", 32, "Lunes a Viernes 8am - 4pm", "Coordinacion"),
        };

        // Citas

        List<MedicalAppointment> citas = new List<MedicalAppointment>()
        {
            new MedicalAppointment(1, DateTime.Parse("2023-10-01"), "Cardiologia", doctores[0], pacientes[0]),
            new MedicalAppointment(2, DateTime.Parse("2023-10-02"), "Pediatria", doctores[1], pacientes[1]),
            new MedicalAppointment(3, DateTime.Parse("2023-10-03"), "Dermatologia", doctores[2], pacientes[2]),
            new MedicalAppointment(4, DateTime.Parse("2023-10-04"), "Ginecologia", doctores[3], pacientes[3]),
        };

        // Hospitales

        List<Hospital> hospitales = new List<Hospital>()
        {
            new Hospital(1, "Hospital Central", "Av. Principal 123"),
            new Hospital(2, "Clinica Santa Maria", "Calle Secundaria 456"),
            new Hospital(3, "Hospital San Juan", "Avenida Terciaria 789"),
            new Hospital(4, "Clinica Esperanza", "Calle Cuarta 101"),
        };

        // Mostrar Pacientes

        Console.WriteLine("Lista de Pacientes:");
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente);
        }
        Console.WriteLine("--------------------------------------------------");
        // Crear Cita para Paciente
        Console.WriteLine("Ingrese el ID del paciente para crear una cita:");
        int idPaciente = int.Parse(Console.ReadLine());
        Patient pacienteSeleccionado = pacientes.Find(p => p.GetId(idPaciente) == idPaciente);
        Console.WriteLine("--------------------------------------------------");
        // Mostrar Citas 

        Console.WriteLine("Lista de Citas:");
        foreach (var cita in citas)
        {
            cita.ShowAllMedicalAppointment();
        }
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Ingrese el ID de la cita a crear:");
        int idCita = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la fecha de la cita (dd/mm/yyyy):");
        DateTime fechaCita = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la especialidad de la cita:");
        string especialidadCita = Console.ReadLine();
        Console.WriteLine("--------------------------------------------------");
        // Mostrar Doctores
        Console.WriteLine("Lista de Doctores:");
        foreach (var doctor in doctores)
        {
            Console.WriteLine(doctor);
        }
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine( "Ingrese el ID del doctor para asignar a la cita:");
        int idDoctor = int.Parse(Console.ReadLine());
        Doctor doctorSeleccionado = doctores.Find(d => d.GetId(idDoctor) == idDoctor);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine( idCita + " " + fechaCita + " " + especialidadCita + " " + doctorSeleccionado.Name + " " + doctorSeleccionado.LastName);

        // Asignar Cita al Paciente y Doctor
        MedicalAppointment nuevaCita = new MedicalAppointment(idCita, fechaCita, especialidadCita ,doctorSeleccionado, pacienteSeleccionado);
        pacienteSeleccionado.AddCita(nuevaCita);
        doctorSeleccionado.AddCitaPending(nuevaCita);
        Console.WriteLine("Cita creada exitosamente para el paciente " + pacienteSeleccionado.Name + " " + pacienteSeleccionado.LastName);
        Console.WriteLine("--------------------------------------------------");
        nuevaCita.ShowAllMedicalAppointment();

        // Notificar al paciente, doctor y recepcionista
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Notificando al paciente");
        pacienteSeleccionado.Notify();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Notificando al doctor");
        doctorSeleccionado.Notify();
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Notificando al recepcionista");
        Recepcionist recepcionistaSeleccionado = recepcionistas[0];
        recepcionistaSeleccionado.AddCitaPending(nuevaCita);
        recepcionistaSeleccionado.Notify();
    }
}