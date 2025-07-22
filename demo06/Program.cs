using System.Dynamic;

/// <summary>
/// Interfaz que define un contrato para las citas médicas.
/// </summary>
interface IMedicalAppointment
{
    /// <summary>
    /// Método para mostrar todas las citas médicas
    /// </summary>
    void ShowAllMedicalAppointment();
}

/// <summary>
/// Clase que implementa la interfaz IMedicalAppointment y representa una cita médica en el sistema.
/// </summary>
class MedicalAppointment : IMedicalAppointment
{
    /// <summary>
    /// Identificador único de la cita médica
    /// </summary>
    private int Id { get; set; }

    /// <summary>
    /// Fecha y hora programada para la cita médica
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Especialidad médica de la cita
    /// </summary>
    public string specialty { get; set; }

    /// <summary>
    /// Nombre completo del paciente asignado a la cita
    /// </summary>
    public string PacienteFullName { get; set; }

    /// <summary>
    /// Nombre completo del doctor asignado a la cita
    /// </summary>
    public string DoctorFullName { get; set; }

    /// <summary>
    /// Constructor para crear una nueva cita médica
    /// </summary>
    /// <param name="_id">Identificador único de la cita</param>
    /// <param name="_date">Fecha y hora de la cita</param>
    /// <param name="_specialty">Especialidad médica requerida</param>
    /// <param name="doctor">Doctor asignado a la cita</param>
    /// <param name="paciente">Paciente para quien se programa la cita</param>
    public MedicalAppointment(int _id, DateTime _date, string _specialty, Doctor doctor, Patient paciente)
    {
        Id = _id;
        Date = _date;
        specialty = _specialty;
        DoctorFullName = doctor.Name + " " + doctor.LastName;
        PacienteFullName = paciente.Name + " " + paciente.LastName;
    }

    /// <summary>
    /// Muestra la información completa de la cita médica en consola
    /// </summary>
    public void ShowAllMedicalAppointment()
    {
        Console.WriteLine($"Cita ID: {Id}, Fecha: {Date.ToShortDateString()}, Especialidad: {specialty}, Paciente: {PacienteFullName}, Doctor: {DoctorFullName}");
    }
}

/// <summary>
/// Clase base que representa un usuario del sistema médico
/// </summary>
class User
{
    /// <summary>
    /// Identificador único del usuario
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Apellido del usuario
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Documento Nacional de Identidad del usuario
    /// </summary>
    public string Dni { get; set; }

    /// <summary>
    /// Número de teléfono del usuario
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Dirección de correo electrónico del usuario
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Edad del usuario
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Constructor para crear un nuevo usuario
    /// </summary>
    /// <param name="_id">Identificador único del usuario</param>
    /// <param name="_name">Nombre del usuario</param>
    /// <param name="_lastName">Apellido del usuario</param>
    /// <param name="_dni">Documento Nacional de Identidad</param>
    /// <param name="_phone">Número de teléfono</param>
    /// <param name="_email">Dirección de correo electrónico</param>
    /// <param name="_age">Edad del usuario</param>
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

    /// <summary>
    /// Notifica al usuario sobre una nueva cita médica
    /// </summary>
    public virtual void Notify()
    {
        Console.WriteLine($"Hola {Name} {LastName}, te notificamos que tienes una nueva cita médica.");
    }

    /// <summary>
    /// Devuelve una representación en cadena de los datos del usuario
    /// </summary>
    /// <returns>String con la información completa del usuario</returns>
    public override string ToString()
    {
        return $"Id: {Id}, Nombre: {Name} {LastName}, DNI: {Dni}, Telefono: {Phone}, Email: {Email}, Edad: {Age}";
    }
}

/// <summary>
/// Clase que hereda de User y representa un paciente en el sistema médico
/// </summary>
class Patient : User
{
    /// <summary>
    /// Número de historia clínica del paciente
    /// </summary>
    public string nroHistory { get; set; }

    /// <summary>
    /// Lista de citas médicas asignadas al paciente
    /// </summary>
    public List<MedicalAppointment> MedicalAppointments { get; set; } = new List<MedicalAppointment>();

    /// <summary>
    /// Constructor para crear un nuevo paciente
    /// </summary>
    /// <param name="_id">Identificador único del paciente</param>
    /// <param name="_name">Nombre del paciente</param>
    /// <param name="_lastName">Apellido del paciente</param>
    /// <param name="_dni">Documento Nacional de Identidad</param>
    /// <param name="_phone">Número de teléfono</param>
    /// <param name="_email">Dirección de correo electrónico</param>
    /// <param name="_age">Edad del paciente</param>
    /// <param name="_nroHistory">Número de historia clínica</param>
    public Patient(int _id, string _name, string _lastName, string _dni, string _phone, string _email, int _age, string _nroHistory)
        : base(_id, _name, _lastName, _dni, _phone, _email, _age)
    {
        nroHistory = _nroHistory;
    }

    /// <summary>
    /// Obtiene el identificador del paciente
    /// </summary>
    /// <param name="id">Parámetro de identificador (no utilizado en la implementación actual)</param>
    /// <returns>El identificador del paciente</returns>
    public int GetId(int id)
    {
        return Id;
    }

    /// <summary>
    /// Agrega una nueva cita médica a la lista del paciente
    /// </summary>
    /// <param name="cita">Cita médica a agregar</param>
    public void AddCita(MedicalAppointment cita)
    {
        MedicalAppointments.Add(cita);
    }

    /// <summary>
    /// Notifica al paciente sobre su nueva cita médica con detalles específicos
    /// </summary>
    public override void Notify()
    {
        Console.WriteLine($"Hola {Name} {LastName}, te notificamos que tienes una nueva cita médica programada el dia {MedicalAppointments.Last().Date.ToShortDateString()} con el doctor {MedicalAppointments.Last().DoctorFullName}.");
    }

    /// <summary>
    /// Muestra todas las citas médicas del paciente en consola
    /// </summary>
    public void ShowAllMedicalAppointment()
    {
        MedicalAppointments.ForEach(cita => Console.WriteLine($"Citas del Paciente {Name} {LastName}: {cita}"));
    }

    /// <summary>
    /// Devuelve una representación en cadena de los datos del paciente incluyendo su historia clínica
    /// </summary>
    /// <returns>String con la información completa del paciente</returns>
    public override string ToString()
    {
        return base.ToString() + $", Numero de Historia Clinica: {nroHistory}";
    }
}

/// <summary>
/// Clase que hereda de User y representa un doctor en el sistema médico
/// </summary>
class Doctor : User
{
    /// <summary>
    /// Especialidad médica del doctor
    /// </summary>
    public string Specialty { get; set; }

    /// <summary>
    /// Universidad donde se graduó el doctor
    /// </summary>
    public string GraduationUniversity { get; set; }

    /// <summary>
    /// Número de colegiatura profesional del doctor
    /// </summary>
    public string TuitionNumber { get; set; }

    /// <summary>
    /// Años de experiencia profesional del doctor
    /// </summary>
    public int YearsOfExperience { get; set; }

    /// <summary>
    /// Lista de citas médicas pendientes asignadas al doctor
    /// </summary>
    public List<MedicalAppointment> MedicalAppointmentsPending { get; set; } = new List<MedicalAppointment>();

    /// <summary>
    /// Constructor para crear un nuevo doctor
    /// </summary>
    /// <param name="_id">Identificador único del doctor</param>
    /// <param name="_name">Nombre del doctor</param>
    /// <param name="_lastName">Apellido del doctor</param>
    /// <param name="_dni">Documento Nacional de Identidad</param>
    /// <param name="_phone">Número de teléfono</param>
    /// <param name="_email">Dirección de correo electrónico</param>
    /// <param name="_age">Edad del doctor</param>
    /// <param name="_specialty">Especialidad médica</param>
    /// <param name="_GraduationUniversity">Universidad de graduación</param>
    /// <param name="_TuitionNumber">Número de colegiatura</param>
    /// <param name="_YearsOfExperience">Años de experiencia profesional</param>
    public Doctor(int _id, string _name, string _lastName, string _dni, string _phone, string _email, int _age, string _specialty, string _GraduationUniversity, string _TuitionNumber, int _YearsOfExperience)
        : base(_id, _name, _lastName, _dni, _phone, _email, _age)
    {
        Specialty = _specialty;
        GraduationUniversity = _GraduationUniversity;
        TuitionNumber = _TuitionNumber;
        YearsOfExperience = _YearsOfExperience;
    }

    /// <summary>
    /// Obtiene el identificador del doctor
    /// </summary>
    /// <param name="id">Parámetro de identificador (no utilizado en la implementación actual)</param>
    /// <returns>El identificador del doctor</returns>
    public int GetId(int id)
    {
        return Id;
    }

    /// <summary>
    /// Agrega una nueva cita médica pendiente a la lista del doctor
    /// </summary>
    /// <param name="cita">Cita médica a agregar como pendiente</param>
    public void AddCitaPending(MedicalAppointment cita)
    {
        MedicalAppointmentsPending.Add(cita);
    }

    /// <summary>
    /// Notifica al doctor sobre su nueva cita médica con detalles específicos
    /// </summary>
    public override void Notify()
    {
        Console.WriteLine($"Hola Dr. {Name} {LastName}, te notificamos que tienes una nueva cita médica programada el dia {MedicalAppointmentsPending.Last().Date.ToShortDateString()} con el paciente {MedicalAppointmentsPending.Last().PacienteFullName}.");
    }

    /// <summary>
    /// Devuelve una representación en cadena de los datos del doctor incluyendo información profesional
    /// </summary>
    /// <returns>String con la información completa del doctor</returns>
    public override string ToString()
    {
        return base.ToString() + $", Especialidad: {Specialty}, Universidad de Egreso: {GraduationUniversity}, Numero de Colegiatura: {TuitionNumber}, Años de Experiencia: {YearsOfExperience}";
    }
}

/// <summary>
/// Clase que hereda de User y representa un recepcionista en el sistema médico
/// </summary>
class Recepcionist : User
{
    /// <summary>
    /// Horario de trabajo del recepcionista
    /// </summary>
    public string WorkSchedule { get; set; }

    /// <summary>
    /// Área de trabajo asignada al recepcionista
    /// </summary>
    public string WorkArea { get; set; }

    /// <summary>
    /// Lista de citas médicas pendientes que debe gestionar el recepcionista
    /// </summary>
    public List<MedicalAppointment> MedicalAppointmentsPending { get; set; } = new List<MedicalAppointment>();

    /// <summary>
    /// Constructor para crear un nuevo recepcionista
    /// </summary>
    /// <param name="_id">Identificador único del recepcionista</param>
    /// <param name="_name">Nombre del recepcionista</param>
    /// <param name="_lastName">Apellido del recepcionista</param>
    /// <param name="_dni">Documento Nacional de Identidad</param>
    /// <param name="_phone">Número de teléfono</param>
    /// <param name="_email">Dirección de correo electrónico</param>
    /// <param name="_age">Edad del recepcionista</param>
    /// <param name="_workSchedule">Horario de trabajo</param>
    /// <param name="_workArea">Área de trabajo asignada</param>
    public Recepcionist(int _id, string _name, string _lastName, string _dni, string _phone, string _email, int _age, string _workSchedule, string _workArea)
    : base(_id, _name, _lastName, _dni, _phone, _email, _age)
    {
        WorkSchedule = _workSchedule;
        WorkArea = _workArea;
    }

    /// <summary>
    /// Agrega una nueva cita médica pendiente para gestionar
    /// </summary>
    /// <param name="cita">Cita médica a agregar como pendiente de gestión</param>
    public void AddCitaPending(MedicalAppointment cita)
    {
        MedicalAppointmentsPending.Add(cita);
    }

    /// <summary>
    /// Notifica al recepcionista sobre una nueva cita médica que debe gestionar
    /// </summary>
    public override void Notify()
    {
        Console.WriteLine($"Hola {Name} {LastName}, te notificamos que tienes una nueva cita médica pendiente para gestionar, el dia {MedicalAppointmentsPending.Last().Date.ToShortDateString()}.");
    }

    /// <summary>
    /// Devuelve una representación en cadena de los datos del recepcionista incluyendo información laboral
    /// </summary>
    /// <returns>String con la información completa del recepcionista</returns>
    public override string ToString()
    {
        return base.ToString() + $", Horario de Trabajo: {WorkSchedule}, Area de Trabajo: {WorkArea}";
    }
}

/// <summary>
/// Clase que representa un hospital en el sistema
/// </summary>
class Hospital
{
    /// <summary>
    /// Identificador único del hospital
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre del hospital
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Dirección física del hospital
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Constructor para crear un nuevo hospital
    /// </summary>
    /// <param name="_id">Identificador único del hospital</param>
    /// <param name="_name">Nombre del hospital</param>
    /// <param name="_address">Dirección del hospital</param>
    public Hospital(int _id, string _name, string _address)
    {
        Id = _id;
        Name = _name;
        Address = _address;
    }
}

/// <summary>
/// Sistema de gestión de citas médicas que permite administrar pacientes, doctores, recepcionistas y citas médicas.
/// </summary>
internal class Program
{

    /// <summary>
    /// Método principal que ejecuta el sistema de gestión de citas médicas
    /// </summary>
    /// <param name="args">Argumentos de línea de comandos</param>
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
        Console.WriteLine("Ingrese el ID del doctor para asignar a la cita:");
        int idDoctor = int.Parse(Console.ReadLine());
        Doctor doctorSeleccionado = doctores.Find(d => d.GetId(idDoctor) == idDoctor);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(idCita + " " + fechaCita + " " + especialidadCita + " " + doctorSeleccionado.Name + " " + doctorSeleccionado.LastName);

        // Asignar Cita al Paciente y Doctor
        MedicalAppointment nuevaCita = new MedicalAppointment(idCita, fechaCita, especialidadCita, doctorSeleccionado, pacienteSeleccionado);
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