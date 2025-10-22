// Program.cs
using Obli1Prog2;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

bool salir = false;
List<Pacientes> listaPacientes = Pacientes.CargarPacientes();
List<Medicos> listaMedicos = Medicos.CargarMedicos();
List<Recepcionistas> listaRecepcionistas = Recepcionistas.CargarReps();
List<Turnos> listaTurnos = Turnos.CargarTurnos();
List<Pagos> listaPagos = Pagos.CargarPagos();
Dictionary<string, string> contrReps = GuardarContrReps();

Login();

do
{
    MostrarMenuPrincipal();

    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadKey().KeyChar.ToString();
    switch (opcion)
    {
        case "1":
            GestionUsuarios();
            break;

        case "2":
            GestionTurnos();
            break;

        case "3":
            MenuPagos();
            break;

        case "4":
            EstadisticasReportes();
            break;

        case "5":
            Login();
            break;

        case "0":
            Console.Clear();
            Console.WriteLine("Saliendo...");
            salir = true;
            break;

        default:
            Console.WriteLine("Opción invalida. Presione una tecla para continuar...");
            Console.ReadKey().KeyChar.ToString();
            break;
    }
}
while (!salir);

#region Metodos menú principal

// Metodo para hacer login y recibir acceso a todas las opciones del programa
void Login()
{
    string? usuario;
    string? contrasenia;

    do
    {
        do
        {
            Console.Clear();
            Console.WriteLine("===== Bienvenido a la Clínica Vida Sana =====");

            usuario = LeerTexto("Ingrese su nombre de usuario");
            if (!contrReps.ContainsKey(usuario))
            {
                Console.WriteLine("El usuario ingresado no existe. Presione una tecla para continuar...");
                Console.ReadKey();
            }
        } while (!contrReps.ContainsKey(usuario));

        contrasenia = LeerContrasenia("Contraseña");
        if (contrReps[usuario] != contrasenia)
        {
            Console.WriteLine("Contraseña incorrecta. Presione una tecla para continuar...");
            Console.ReadKey();
        }
        else
        {
            break;
        }
    } while (contrReps[usuario] != contrasenia);
}

// Menu principal que se muestra despues de hacer login
void MostrarMenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("===== Menu de Gestión de pacientes | Clínica Vida Sana =====");
    Console.WriteLine("1. Gestión de usuarios");
    Console.WriteLine("2. Gestión de turnos");
    Console.WriteLine("3. Pagos");
    Console.WriteLine("4. Estadísticas y reportes");
    Console.WriteLine("0. Salir");
    Console.WriteLine("");
}

// Menu 1: Gestion de usuarios
void GestionUsuarios()
{
    bool volver = false;

    do
    {
        Console.Clear();
        Console.WriteLine("===== Gestión de usuarios =====");
        Console.WriteLine("1. Registrar nuevo paciente");
        Console.WriteLine("2. Cambiar contraseña");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                RegistrarPaciente();
                break;

            case "2":
                CambiarCont();
                break;

            case "0":
                volver = true;
                break;

            default:
                Console.WriteLine("Valor no valido. Presione una tecla para continuar...");
                Console.ReadKey();
                break;
        }
    } while (!volver);
}

// Menu 2: Gestion de turnos
void GestionTurnos()
{
    bool volver = false;
    do
    {
        Console.Clear();
        Console.WriteLine("===== Gestión de turnos =====");
        Console.WriteLine("1. Ver disponibilidad");
        Console.WriteLine("2. Agendar consulta médica");
        Console.WriteLine("3. Cancelar consulta");
        Console.WriteLine("4. Reprogramar consulta");
        Console.WriteLine("5. Historial de consultas");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                //VerDisponibilidad();
                break;
            case "2":
                //AgendarConsulta();
                break;
            case "3":
                //CancelarConsulta();
                break;
            case "4":
                //ReprogramarConsulta();
                break;
            case "5":
                //HistorialConsultas();
                break;
            case "0":
                volver = true;
                break;
            default:
                Console.WriteLine("Valor no valido. Presione una tecla para continuar...");
                Console.ReadKey().KeyChar.ToString();
                break;
        }
    } while (!volver);

}

// Menu 3: Gestion de pagos
void MenuPagos()
{
    bool volver = false;
    do
    {
        Console.Clear();
        Console.WriteLine("===== Menu de Pagos =====");
        Console.WriteLine("1. Registrar pago de consulta");
        Console.WriteLine("2. Emitir comprobante");
        Console.WriteLine("3. Consultar pagos");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                //RegistrarPago();
                break;

            case "2":
                //EmitirComprobante();
                break;

            case "3":
                // ConsultarPagos();
                break;

            case "0":
                volver = true;
                break;

            default:
                Console.WriteLine("Valor no valido. Presione una tecla para continuar...");
                Console.ReadKey().KeyChar.ToString();
                break;
        }
    } while (!volver);
}

// Menu 4: Estadisticas y reportes
void EstadisticasReportes()
{
    bool volver = false;
    do
    {
        Console.Clear();
        Console.WriteLine("===== Estadísticas y reportes =====");
        Console.WriteLine("1. Listado de pacientes");
        Console.WriteLine("2. Listado de médicos");
        Console.WriteLine("3. Consultas mas frecuentes");
        Console.WriteLine("4. Médicos mas consultados");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.Write("Seleccione una opción:");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                ListadoPacientes();
                break;
            case "2":
                ListadoMedicos();
                break;
            case "3":
                ConsultasFrecuentes();
                break;
            case "4":
                RankingConsultados();
                break;
            case "0":
                volver = true;
                break;
            default:
                Console.Write("Valor no válido. Presiona una tecla para continuar...");
                Console.ReadKey();
                break;

        }
    } while (!volver);
}
#endregion

#region Metodos menú 1
// Metodo para registrar un paciente nuevo, el ID es autonumerico
void RegistrarPaciente()
{
    // Limpia la pantalla y muestra el cabezal de la seccion
    Console.Clear();
    Console.WriteLine("===== Registrar nuevo paciente =====\n");

    // Captura todos los datos del paciente nuevo
    string nombre = LeerTexto("Nombre");
    string apellido = LeerTexto("Apellido");
    int numDocumento = LeerDocumento();
    DateOnly fechaNacimiento = LeerFecha("Fecha de nacimiento");
    int telefono = LeerEntero("Telefono");
    string email = LeerEmail();
    string obraSocial = LeerTexto("Obra social");
    string nombreUsuario = LeerTexto("Nombre de usuario");
    string contrasenia = LeerContrasenia("Contraseña");

    // Guarda todos los datos en un nuevo paciente y lo añade a la lista de paciente
    listaPacientes.Add(new Pacientes(nombre, apellido, numDocumento, fechaNacimiento, telefono, email, obraSocial, nombreUsuario, contrasenia));

    Console.Write("Paciente agregado exitosamente. Presione una tecla para continuar...");
    Console.ReadKey();
}

//Metodo para cambiar la contraseña del usuario recepcionista.
void CambiarCont()
{
    string usuario;
    string contrasenia;
    string nuevaCont;
    string nuevaCont2;

    //Piede el nombre de usuario al que se le va a cambiar la contraseña y verifica que exista.
    do
    {
        Console.Clear();
        Console.WriteLine("===== Cambiar contraseña =====");

        Console.WriteLine("Nombre de usuario:");
        usuario = Console.ReadLine()?.Trim();

        if (!contrReps.ContainsKey(usuario))
        {
            Console.WriteLine("No se encontró un usuario con ese nombre. Presione una tecla para intentarlo nuevamente.");
            Console.ReadKey();
        }
    }
    while (!contrReps.ContainsKey(usuario));

    //Pide la contraseña actual del usuario y verifica que sea esa.
    do
    {
        contrasenia = LeerContrasenia("Contraseña actual");
        if (contrReps[usuario] != contrasenia)
        {
            Console.WriteLine("Contraseña incorrecta. Presione una tecla para intentarlo nuevamente.");
            Console.ReadKey();
        }
    }
    while (contrReps[usuario] != contrasenia);

    //Pide ingresar la nueva contraseña 2 veces y verifica que sean iguales.
    do
    {
        nuevaCont = LeerContrasenia("Nueva contraseña");
        nuevaCont2 = LeerContrasenia("Confirmar nueva contraseña");
        if (nuevaCont != nuevaCont2)
        {
            Console.WriteLine("Las contraseñas ingresadas no coinciden. Presione una tecla para intentarlo nuevamente.");
            Console.ReadKey();
        }

    }
    while (nuevaCont != nuevaCont2);

    //Se actualiza la contraseña.
    contrReps[usuario] = nuevaCont;
    Console.WriteLine("Contrasña actualizada correctamente.");
    Console.ReadKey();

    //foreach para verificar que se cambio la contraseña. (temporal).
    foreach (var usuarioo in contrReps)
    {
        Console.WriteLine(usuarioo);
    }
    Console.ReadKey();

}
#endregion

#region Metodos menú 2
//Metodo para elegir ver disponibilidad por medico o especialidad
void VerDisponibilidad() 
{
    bool volver = false;
    do
    {
        Console.Clear();
        Console.WriteLine("===== Disponibilidad =====");
        Console.WriteLine("1. Por médico");
        Console.WriteLine("2. Por especialidad");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                DisponibilidadMed();
                break;
            case "2":
                DisponibilidadEsp();
                break;
            case "0":
                volver = true;
                break;
            default:
                Console.WriteLine("Valor no válido. Presione una tecla para continuar...");
                Console.ReadKey().KeyChar.ToString();
                break;
        }
    } while (!volver);
}

//Metodo para cer disponibilidad por medico
void DisponibilidadMed() 
{
    Console.Clear();
    Console.WriteLine("===== Disponibilidad por médico =====");

    foreach (Medicos medico in listaMedicos) 
    {
        var dias = medico.DiasAtencion != null ? string.Join(", ", medico.DiasAtencion) : "Sin disponibilidad";
        var horas = medico.HorariosDisponibles != null ? string.Join(", ", medico.HorariosDisponibles) : " Sin disponibilidad";
        Console.Write($"Medico: {medico.Nombre} {medico.Apellido}, Dias disponibles: {dias}, Horarios disponnibles: {horas}");
    }
}

void DisponibilidadEsp() 
{
    Console.Clear();
    Console.WriteLine("===== Disponibilidad por especialidad =====");

    foreach (Medicos medico in listaMedicos)
    {
        var dias = medico.DiasAtencion != null ? string.Join(", ", medico.DiasAtencion) : "Sin disponibilidad";
        var horas = medico.HorariosDisponibles != null ? string.Join(", ", medico.HorariosDisponibles) : " Sin disponibilidad";
        Console.WriteLine($"Especialidad: {medico.Especialidad}, Dias disponibles: {dias}, Horarios disponnibles: {horas}");
    }
}

void AgendarConsulta()
{
    int idPaciente;
    int idMedico;
    DateOnly fechaConsulta;
    float horaConsulta;

    var cultura = new System.Globalization.CultureInfo("es-ES");
    DateOnly diaHoy = DateOnly.FromDateTime(DateTime.Today);

    

    // Limpia la pantalla y muestra el cabezal de la seccion
    Console.Clear();
    Console.WriteLine("===== Agendar nueva consulta médica =====");

    // Captura todos los datos para la consulta

    // Valida si el ID del paciente ingresado existe
    do
    {
        idPaciente = LeerEntero("Id del paciente");
        if (!listaPacientes.Any(paciente => paciente.IdPaciente == idPaciente))
            Console.WriteLine("No existe el paciente, intente nuevamente...");
    } while (!listaPacientes.Any(paciente => paciente.IdPaciente == idPaciente));

    // Valida si el ID del medico ingresado existe
    do
    {
        idMedico = LeerEntero("Id del médico");
        if (!listaMedicos.Any(medico => medico.IdMedico == idMedico))
            Console.WriteLine("No existe el médico, intente nuevamente...");
    } while (!listaMedicos.Any(medico => medico.IdMedico == idMedico));

    // Guarda la lista de los horarios del medico ingresado en una lista para despues confirmar si esta disponible esa hora
    Medicos medicoAConsultar = listaMedicos.FirstOrDefault(medico => medico.IdMedico == idMedico)!;
    float[] horariosConsulta = medicoAConsultar.HorariosDisponibles;

    // Primero valida si la fecha ingresada es posterior a la fecha de mañana, y despues valida si la hora ingresada coincide con las horas disponibles del medico ingresado
    do
    {
        do
        {
            fechaConsulta = LeerFecha("Fecha de la consulta");
            if (fechaConsulta <= diaHoy.AddDays(1))
                Console.WriteLine("La fecha elegida no puede ser anterior a mañana, intente nuevamente...");
        } while (fechaConsulta <= diaHoy);

        horaConsulta = LeerFlotante("Hora de la consulta");
        if (!horariosConsulta.Any(hora => hora == horaConsulta))
            Console.WriteLine("Esa hora no la ofrece el medico o no está disponible, intente nuevamente");
    } while (!horariosConsulta.Any(hora => hora == horaConsulta));

    // Por ultimo, guarda todos los datos en un objeto Turno y le asigna el estado como 1 (Agendado)
    listaTurnos.Add(new Turnos(idPaciente, idMedico, fechaConsulta, horaConsulta, 1));

    Console.Write("Consulta agendada exitosamente. Presione una tecla para continuar...");
    Console.ReadKey();
}

#endregion

#region Metodos menú 4
// Metodo para listar todos los pacientes ordenados alfabeticamente
void ListadoPacientes()
{
    Console.Clear();
    Console.WriteLine("=== Listado de pacientes ===");
    if (listaPacientes.Count == 0)
    {
        Console.WriteLine("No hay pacientes en la lista.");
    }
    else
    {
        listaPacientes = listaPacientes.OrderBy(paciente => paciente.Nombre).ToList();
        listaPacientes.ForEach(paciente => Console.WriteLine(paciente + $"\n"));
    }
    Console.Write("Presione cualquier tecla para volver...");
    Console.ReadKey();
}

// Metodo para listar todos los medicos ordenados por especialidad
void ListadoMedicos()
{
    Console.Clear();
    Console.WriteLine("=== Listado de médicos ===");
    listaMedicos = listaMedicos.OrderBy(medico => medico.Especialidad).ToList();
    listaMedicos.ForEach(medico => Console.WriteLine(medico + $"\n"));

    Console.Write("Presione cualquier tecla para volver...");
    Console.ReadKey();
}

//Metodo para mostrar las consulas mas frecuentes por especialidad
void ConsultasFrecuentes()
{
    Console.Clear();
    Console.WriteLine("=== Consultas mas frecuentes por especialidad ===");

    //Diccionario para guardar la especialidad como clave y la cantidad de consultas como valor
    Dictionary<string, int> dEspecialidad = new Dictionary<string, int>();
    dEspecialidad.Add("Cardiología", 0);
    dEspecialidad.Add("Pediatría", 0);
    dEspecialidad.Add("Dermatología", 0);
    dEspecialidad.Add("Neurología", 0);

    //foreach para encontrar el medico que atiende en cada turno y guardar su especialidad para despues sumarle 1 al valor de esa especialidad en el diccionario
    foreach (var turno in listaTurnos)
    {
        int idMedicoTurno = turno.IdMedicos;
        Medicos medicoEncontrado = listaMedicos.Find(m => m.IdMedico == idMedicoTurno);
        string especialidad = medicoEncontrado.Especialidad;

        dEspecialidad[especialidad]++;
    }

    //foreach para mostrar la especialidad y su cantidad de consultas
    foreach (var par in dEspecialidad)
    {
        string cadena = "consultas";
        if (par.Value == 1)
        {
            cadena = "consulta";
        }
        Console.WriteLine($"{par.Key}: {par.Value} {cadena}");
    }

    Console.Write("Presione cualquier tecla para volver...");
    Console.ReadKey();
}

//Metodo para listar los medicos ordenados por cantidad de consultas
void RankingConsultados()
{
    Console.Clear();
    Console.WriteLine("=== Listado de médicos mas consultados ===");

    //Por cada turno guarda el ID del medico que lo atiende y lo busca en la lista de medicos para despues sumarle uno a la cantidad de consultas
    foreach (var turno in listaTurnos)
    {
        int idMedicoTurno = turno.IdMedicos;
        Medicos medicoEncontrado = listaMedicos.Find(m => m.IdMedico == idMedicoTurno);
        medicoEncontrado.CantConsultas++;
    }
    //Ordena la lista de medicos en orden descendiente y muestra el nombre, apellido y cantidad de consultas de cada medico
    listaMedicos = listaMedicos.OrderByDescending(medico => medico.CantConsultas).ToList();
    listaMedicos.ForEach(medico => Console.WriteLine($"Medico: {medico.Nombre} {medico.Apellido} | Cantidad de consultas: {medico.CantConsultas}"));

    Console.Write("Presione cualquier tecla para volver...");
    Console.ReadKey();
}
#endregion

#region Metodos para leer datos
// Metodo para ingresar un string de texto
string LeerTexto(string campo)
{
    string? valor;
    do
    {
        Console.Write($"{campo}: ");
        valor = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(valor))
            Console.WriteLine($"El campo '{campo}' no puede estar vacío.");
    } while (string.IsNullOrWhiteSpace(valor));
    return valor;
}

// Metodo para ingresar un numero entero
int LeerEntero(string campo)
{
    int valor;
    string? entrada;
    do
    {
        Console.Write($"{campo}: ");
        entrada = Console.ReadLine()?.Trim();
        if (!int.TryParse(entrada, out valor))
            Console.WriteLine("El valor ingresado no es un numero, intente nuevamente.");
        else if (valor <= 0)
            Console.WriteLine("El valor ingresado no puede ser menor a 0, intente nuevamente.");
        else if (string.IsNullOrWhiteSpace(entrada))
            Console.WriteLine($"El campo '{campo}' no puede estar vacío.");
    } while (!int.TryParse(entrada, out valor) || valor <= 0 || string.IsNullOrWhiteSpace(entrada));
    return valor;
}

float LeerFlotante(string campo)
{
    float valor;
    string? entrada;
    do
    {
        Console.Write($"{campo}: ");
        entrada = Console.ReadLine()?.Trim();
        if (!float.TryParse(entrada, out valor))
            Console.WriteLine("El valor ingresado no es un numero o no es un valor válido, intente nuevamente.");
        else if (valor <= 0)
            Console.WriteLine("El valor ingresado no puede ser menor a 0, intente nuevamente.");
        else if (string.IsNullOrWhiteSpace(entrada))
            Console.WriteLine($"El campo '{campo}' no puede estar vacío");
    } while (!float.TryParse(entrada, out valor) || valor <= 0 || string.IsNullOrWhiteSpace(entrada));
    return valor;
}

// Funcion para ingresar una fecha de tipo DateOnly
DateOnly LeerFecha(string campo)
{
    bool resultado1;
    bool resultado2;
    bool resultado3;
    int dia;
    int mes;
    int anio;

    // Bucle para el año, con sus validaciones respectivas
    do
    {
        Console.WriteLine($"{campo}: ");
        Console.Write("Ingrese el año:");
        resultado3 = int.TryParse(Console.ReadLine()?.Trim(), out anio);
        if (!resultado3)
            Console.WriteLine("El año ingresado no es un numero. Intente nuevamente.");
        else if (anio < 0)
            Console.WriteLine("El año ingresado no puede ser menor a 0. Intente nuevamente.");
    } while (!resultado3 || anio < 0);

    // Bucle para el mes, con validaciones respectivas.
    do
    {
        Console.Write("Ingrese el mes: ");
        resultado1 = int.TryParse(Console.ReadLine()?.Trim(), out mes);
        if (!resultado1)
            Console.WriteLine("El mes ingresado no es un numero. Intente nuevamente.");
        else if (mes < 1 || mes > 12)
            Console.WriteLine("El mes ingresado no puede ser menor a 1 o mayor que 12. Intente nuevamente.");
    } while (!resultado1 || (mes < 1 || mes > 12));

    // Bucle para el dia, con sus muchas validaciones respectivas.
    do
    {
        Console.Write("Ingrese el día: ");
        resultado2 = int.TryParse(Console.ReadLine()?.Trim(), out dia);
        if (!resultado2)
            Console.WriteLine("El dia ingresado no es un numero. Intente nuevamente.");
        else if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && (dia < 1 && dia > 30))
            Console.WriteLine("El dia ingresado no puede ser mayor a 30. Intente nuevamente.");
        else if ((mes == 2) && DateTime.IsLeapYear(anio) && (dia < 1 && dia > 29))
            Console.WriteLine("El dia ingresado no puede ser mayor a 29. Intente nuevamente.");
        else if ((mes == 2) && (dia < 1 && dia > 28))
            Console.WriteLine("El dia ingresado no puede ser mayor a 28. Intente nuevamente.");
        else if (dia < 1 && dia > 31)
            Console.WriteLine("El mes ingresado no puede ser mayor a 31. Intente nuevamente.");
    } while (!resultado2 || ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && (dia < 1 && dia > 30)) || ((mes == 2) && DateTime.IsLeapYear(anio) && (dia < 1 && dia > 29)) ||
        ((mes == 2) && (dia < 1 && dia > 28)) || (dia < 1 && dia > 31));

    // Se necesita guardar en una variable tipo var el formato de calendario necesitado
    var calendarioGregoriano = new System.Globalization.GregorianCalendar();
    return new DateOnly(anio, mes, dia, calendarioGregoriano);
}

// Metodo para ingresar un email
string LeerEmail()
{
    string? valor;
    do
    {
        Console.WriteLine("Email:");
        valor = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(valor))
        {
            Console.Write("El campo no puede estar vacio.");
        }
        else if (!valor.Contains('@') || !valor.Contains('.'))
        {
            Console.WriteLine("Ingrese un email válido.");
        }
    } while (string.IsNullOrWhiteSpace(valor) || (!valor.Contains('@') || !valor.Contains('.')));
    return valor;
}

// Metodo para ingresar una contraseña
string LeerContrasenia(string campo)
{
    string? valor;
    do
    {
        Console.Write($"{campo}: ");
        valor = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(valor))
        {
            Console.WriteLine("El campo no puede estar vacio");
        }
        else if (valor.Length < 8)
        {
            Console.WriteLine("La contraseña debe tener mas de 8 caracteres");
        }
    } while (string.IsNullOrWhiteSpace(valor) || valor.Length < 8);
    return valor;
}

// Metodo para ingresar un documento de identidad
int LeerDocumento()
{
    int documento;
    string? entrada;

    do
    {
        Console.WriteLine("Documento de identidad: ");
        entrada = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(entrada))
            Console.WriteLine("El documento ingresado no puede ser nulo. Intente nuevamente.");
        else if (!int.TryParse(entrada, out documento))
            Console.WriteLine("El documento ingresado no es un numero. Intente nuevamente.");
        else if (entrada.Length != 8)
            Console.WriteLine("El documento ingresado tiene que tener un largo de 8 digitos. Intente nuevamente.");
    } while (string.IsNullOrWhiteSpace(entrada) || !int.TryParse(entrada, out documento) || (entrada.Length != 8));
    return documento;
}
#endregion

/* Metodo que devuelve un diccionario de clave string y valor string con los usuarios y contraseñas de todos los
 * recepcionistas administrativos presentes en la lista listaRecepcionistas 
 */
Dictionary<string, string> GuardarContrReps()
{
    Dictionary<string, string> contrReps = new Dictionary<string, string>();
    foreach (Recepcionistas rep in listaRecepcionistas)
    {
        contrReps.Add(rep.Usuario, rep.Contrasenia);
    }
    return contrReps;
}