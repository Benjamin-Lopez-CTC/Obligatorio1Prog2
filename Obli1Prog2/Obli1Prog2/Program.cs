// Programa codificado por Benjamín López y Felipe Alvarez
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

ActualizarDatos();

Login(); // Desactivado para agilizar pruebas

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
            Console.ReadKey();
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

        // Intenta encontrar la clave en el diccionario de contraseñas con el mismo valor que el ingresado
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
        Console.WriteLine("2. Ver consultas");
        Console.WriteLine("3. Agendar consulta médica");
        Console.WriteLine("4. Cancelar consulta");
        Console.WriteLine("5. Reprogramar consulta");
        Console.WriteLine("6. Historial de consultas");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                VerDisponibilidad();
                break;
            case "2":
                VerConsultas();
                break;
            case "3":
                AgendarConsulta();
                break;
            case "4":
                CancelarConsulta();
                break;
            case "5":
                ReprogramarConsulta();
                break;
            case "6":
                HistorialConsultas();
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
                RegistrarPago();
                break;

            case "2":
                EmitirComprobante();
                break;

            case "3":
                ConsultarPagos();
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
                Console.WriteLine("Valor no válido. Presiona una tecla para continuar...");
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
    Console.WriteLine("=== Registrar nuevo paciente ===\n");

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

    Console.Write("Paciente agregado exitosamente. ");
    Volver();
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
        usuario = Console.ReadLine()?.Trim()!;

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
    Console.WriteLine("Contrasña actualizada correctamente. ");
    Volver();
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
        Console.WriteLine("=== Disponibilidad ===");
        Console.WriteLine("1. Por médico");
        Console.WriteLine("2. Por especialidad");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                NuevoDispMed();
                break;
            case "2":
                NuevoDispEsp();
                break;
            case "0":
                volver = true;
                break;
            default:
                Console.WriteLine("Valor no válido. Presione una tecla para continuar...");
                Console.ReadKey();
                break;
        }
    } while (!volver);
}

// Metodo para cer disponibilidad por medico
void NuevoDispMed()
{
    Console.Clear();
    int idMedico;

    // Utiliza un bucle para recibir un id de medico valido
    do
    {
        Console.WriteLine("=== Disponibilidad por médico ===");
        idMedico = LeerEntero("Ingrese el Id del médico a mostrar");
        if (!listaMedicos.Exists(medico => medico.IdMedico == idMedico))
        {
            Console.Write("No existe el médico ingresado. ");
            Pausar();
            Console.Clear();
        }
    } while (!listaMedicos.Exists(medico => medico.IdMedico == idMedico));

    // Obtiene el medico con el mismo id que el ingresado, guarda las horas disponibles del medico en una lista y extrae los dias de atencion del medico
    Medicos medico = listaMedicos.Find(medico => medico.IdMedico == idMedico)!;
    List<Hora> horasDisponibles = medico.HorariosDisponibles!.FindAll(hora => hora.IdPaciente == 0);
    string[] diasMedico = medico.DiasAtencion!;

    Console.WriteLine($"\nMedico/a: {medico.Nombre} {medico.Apellido}\n");
    // Por cada dia de atencion...
    foreach (string dia in diasMedico)
    {
        // Guarda en una lista las horas de ese dia, obtiene el texto que dice la hora en si y une todas las horas para mostrarlas con un formato legible
        List<Hora> horaPorDia = horasDisponibles.FindAll(hora => hora.DiaConsulta == dia);
        List<string> horaString = horaPorDia.Select(hora => hora.HoraConsulta).ToList();
        Console.WriteLine($"{dia}: \n {string.Join(", ", horaString)}\n");
    }

    Volver();
}

//Metodo para mostrar cada especialidad con la cantidad de medicos disponibles de cada una
void NuevoDispEsp()
{
    Console.Clear();
    Console.WriteLine("=== Disponibilidad por especialidad ===");

    //Diccionario para guardar la especialidad como clave y la cantidad de medicos como valor
    Dictionary<string, int> dEspecialidad = new();
    dEspecialidad.Add("Cardiología", 0);
    dEspecialidad.Add("Pediatría", 0);
    dEspecialidad.Add("Dermatología", 0);
    dEspecialidad.Add("Neurología", 0);

    //foreach para encontrar la especialidad de cada medico en la lista precargada y aumentar en 1 el valor del diccionario con la misma clave
    foreach (var medico in listaMedicos)
    {   
        string especialidad = medico.Especialidad!;
        dEspecialidad[especialidad]++;
    }

    //foreach para mostrar la especialidad y su cantidad de médicos
    foreach (var par in dEspecialidad)
    {
        string cadena = "Médicos";
        if (par.Value == 1)
        {
            cadena = "Médico";
        }
        Console.WriteLine($"{par.Key}: {par.Value} {cadena} ");
    }

    Volver();
}

//Metodo para ver todas las consultas si las hay
void VerConsultas()
{
    Console.Clear();
    Console.WriteLine("=== Consultas agendadas ===");
    if (listaTurnos.Count == 0)
    {
        Console.Write("No hay consultas agendadas actualmente. ");
        Pausar();
    }
    else
    {
        foreach (Turnos turno in listaTurnos)
        {
            Console.WriteLine(turno);
        }
        Volver();
    }
}

// Metodo que captura los datos necesarios para agendar una nueva consulta
void AgendarConsulta()
{
    int idPaciente = 0;
    int idMedico = 0;
    DateOnly fechaConsulta = new DateOnly(2026, 12, 20);
    string horaString = "";
    Hora horaConsulta;
    List<Hora> horaDia = [];
    List<Turnos> turnosMedico = [];

    var idioma = new System.Globalization.CultureInfo("es-ES");
    DateOnly diaHoy = DateOnly.FromDateTime(DateTime.Today);
    string nombreDia;

    // Limpia la pantalla y muestra el cabezal de la seccion
    Console.Clear();
    Console.WriteLine("=== Agendar nueva consulta médica ===");

    bool continuar = true;
    int paso = 0;

    // Captura todos los datos para la consulta
    while (continuar)
    {
        switch (paso)
        {
            case 0:
                // Valida si el ID del paciente ingresado existe
                idPaciente = LeerEntero("Id del paciente");
                if (!listaPacientes.Any(paciente => paciente.IdPaciente == idPaciente))
                {
                    Console.WriteLine("No existe el paciente, intente nuevamente...");
                    paso = 0;
                    continue;
                }

                paso = 1;
                break;

            case 1:
                // Valida si el ID del medico ingresado existe
                idMedico = LeerEntero("Id del médico");
                if (!listaMedicos.Any(medico => medico.IdMedico == idMedico))
                {
                    Console.WriteLine("No existe el médico, intente nuevamente...");
                    paso = 1;
                    continue;
                }

                paso = 2;
                break;

            // Primero valida si la fecha ingresada es posterior a la fecha de mañana, y despues valida si la hora ingresada coincide con las horas disponibles del medico ingresado
            case 2:
                Medicos medicoAConsultar = listaMedicos.FirstOrDefault(medico => medico.IdMedico == idMedico)!;
                var horariosConsulta = medicoAConsultar.HorariosDisponibles;

                fechaConsulta = LeerFecha("Fecha de la consulta");
                var diaSemana = fechaConsulta.DayOfWeek;
                nombreDia = idioma.DateTimeFormat.GetDayName(diaSemana);

                turnosMedico.FindAll(turno => (turno.IdMedicos == idMedico) && (turno.FechaTurno == fechaConsulta));

                // Si el medico ya tiene el maximo de 6 consultas en el mismo dia
                if (turnosMedico.Count == 6)
                {
                    Console.WriteLine("El medico ingresado ya tiene el maximo de consultas agendadas en el mismo dia, intente con otra fecha.");
                    paso = 2;
                    continue;
                }

                // Si el paciente tiene una consulta con el mismo medico en el mismo dia
                if (listaTurnos.Exists(turno => (turno.FechaTurno == fechaConsulta) && (turno.IdPaciente == idPaciente && turno.IdMedicos == idMedico))) 
                {
                    Console.WriteLine("Ese paciente ya tiene agendada una consulta con ese medico en ese dia, intente nuevamente.");
                    paso = 2;
                    continue;
                }

                // Si la fecha de consulta es dentro de las proximas 24 horas
                if (fechaConsulta < diaHoy.AddDays(1))
                {
                    Console.WriteLine("La consulta solo puede ser agendada con 24 horas de anticipacion como minimo, intente nuevamente.");
                    paso = 2;
                    continue;
                }

                // Si la fecha ingresada no concuerda con los dias de atencion del medico
                if (!horariosConsulta!.Exists(hora => hora.DiaConsulta == nombreDia))
                {
                    Console.WriteLine("El dia ingresado no coincide con los dias de atencion del medico, intente nuevamente.");
                    paso = 2;
                    continue;
                }

                horaDia = horariosConsulta.FindAll(hora => hora.DiaConsulta == nombreDia);

                paso = 3;
                break;

            case 3:
                horaString = LeerHora();
                // Si la hora ingresada no esta disponible
                if (!horaDia.Any(hora => hora.HoraConsulta == horaString))
                {
                    Console.WriteLine("Esa hora no la ofrece el medico o no está disponible, intente nuevamente");
                    paso = 2;
                    continue;
                }

                // Si la hora ingresada ya esta agendada
                horaConsulta = horaDia.Find(hora => hora.HoraConsulta == horaString)!;
                if (horaConsulta.IdPaciente != 0)
                {
                    Console.WriteLine("Esa hora ya está agendada, intente nuevamente.");
                    paso = 2;
                    continue;
                }

                // Asigna a la hora ingresada el id del paciente para que figure como ocupada
                horaConsulta.IdPaciente = idPaciente;

                // Por ultimo, guarda todos los datos en un objeto Turno y le asigna el estado como 1 (Agendado)
                listaTurnos.Add(new Turnos(idPaciente, idMedico, fechaConsulta, horaString, 1));

                Console.Write("Consulta agendada exitosamente. ");
                Volver();
                continuar = false;
                break;
        }
    }
}

// Metodo para cancelar una consulta con estado 1 (Agendada)
void CancelarConsulta()
{
    int idConsulta;
    do
    {
        Console.Clear();
        Console.WriteLine("===== Cancelar consulta =====");
        //Si la lista de consultas esta vacia lo dice
        if (listaTurnos.Count == 0)
        {
            Console.WriteLine("No hay consultas agendadas en este momento.");
            Volver();
            return;
        }
        //Pide el id de la cosulta a cancelar hasta que el usuario ingrese una que existe
        idConsulta = LeerEntero("Ingrese el ID de la consulta a cancelar");
        if (!listaTurnos.Any(consulta => consulta.IdTurno == idConsulta))
        {
            Console.Write("No existe una consulta con ese ID. Presione una tecla para intentarlo nuevamente...");
            Console.ReadKey();
        }
    }
    while (!listaTurnos.Any(consulta => consulta.IdTurno == idConsulta));

    //Encuentra y guarda la consulta que tenga el mismo ID que el que ingreso el usuario
    Turnos consultaElegida = listaTurnos.Find(consulta => consulta.IdTurno == idConsulta)!;

    //Verifica que la consulta no este ya cancelada o realizada
    if (consultaElegida.EstadoTurno != 1)
    {
        Console.Write("La consulta ingresada ya fue realizada o cancelada. Presione una tecla para intentarlo nuevamente...");
        Console.ReadKey();
        return;
    }

    //Muestra al usuario los datos de la consulta elegida y pide la verificacion para cancelarla
    //Se repite hasta que el usuario eliga la opcion "Si" o "No"
    string confirmacion;
    do
    {
        Console.WriteLine("Esta seguro que quiere cancelar esta consulta?");
        Console.WriteLine(consultaElegida);
        confirmacion = LeerTexto("(Si / No)");
        if (confirmacion.ToLower() != "si" && confirmacion.ToLower() != "no")
        {
            Console.Write("Opcion invalida. Presione una telca para volver a intentar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    while (confirmacion.ToLower() != "si" && confirmacion.ToLower() != "no");

    //Si elige la opcion "Si" el estado de la consulta cambia a cancelada
    if (confirmacion.ToLower() == "si")
    {
        consultaElegida.EstadoTurno = 3;
        Console.Write("Consulta cancelada correctamente. ");
        Volver();
    }
    //Si elige la opcion "No" la consulta no es cancelada
    else
    {
        Console.Write("Cancelacion anulada. ");
        Volver();
    }
}

//Metodo para reprogramar una consulta ya agendada
void ReprogramarConsulta()
{
    var idioma = new System.Globalization.CultureInfo("es-ES");

    Console.Clear();
    Console.WriteLine("=== Reprogramar consulta ===");
    //Verifica que la lista de consultas no este vacia.
    if (listaTurnos.Count == 0)
    {
        Console.Write("No hay consultas agendadas en este momento. ");
        Volver();
        return;
    }

    //Pide el ID de la consulta que se quiere reprogramar y verifica que exista
    int idConsulta = LeerEntero("Ingrese el ID de la consulta a reporogramar");
    if (!listaTurnos.Exists(turno => turno.IdTurno == idConsulta))
    {
        Console.Write("No se encontro una consulta con ese ID. ");
        Volver();
        return;
    }

    //Si existe guarda la consulta elegida
    Turnos consultaElegida = listaTurnos.Find(turno => turno.IdTurno == idConsulta)!;

    //Verifica que la consulta no esté ya realizada o cancelada
    if (consultaElegida.EstadoTurno == 2 || consultaElegida.EstadoTurno == 3)
    {
        Console.Write("La consulta elegida ya fue realizada o cancelada. ");
        Volver();
        return;
    }

    //Pide ingresar la nueva fecha y hora de la consulta
    DateOnly nuevaFecha = LeerFecha("Nueva fecha");
    string nuevaHora = LeerHora();

    var diaSemana = nuevaFecha.DayOfWeek;
    string nombreDia = idioma.DateTimeFormat.GetDayName(diaSemana);

    Medicos medico = listaMedicos.Find(medico => medico.IdMedico == consultaElegida.IdMedicos)!;
    List<Hora> horarios = medico.HorariosDisponibles!;

    //Verifica que el medico ofrezca esa hora
    if (!horarios.Any(hora => (hora.HoraConsulta == nuevaHora) && (hora.DiaConsulta == nombreDia)))
    {
        Console.Write("Esa hora no la ofrece el medico, intente nuevamente. ");
        Volver();
        return;
    }

    var horaConsulta = horarios.Find(hora => (hora.HoraConsulta == nuevaHora) && (hora.DiaConsulta == nombreDia))!;
    if (horaConsulta.IdPaciente != 0)
    {
        Console.Write("Esa hora ya está agendada, intente nuevamente. ");
        Volver();
        return;
    }

    //Pide la confirmacion del usuario mostrando la nueva fecha y hora y la consulta elegida hasta que el usuario seleccione una de las opciones esperadas
    string confirmacion;
    do
    {
        Console.WriteLine("Esta seguro que quiere reprogramar esta consulta para el dia " + nuevaFecha + " a las " + nuevaHora +"hrs?");
        Console.WriteLine(consultaElegida);
        confirmacion = LeerTexto("(Si / No)");
        if (confirmacion.ToLower() != "si" && confirmacion.ToLower() != "no")
        {
            Console.Write("Opcion invalida. Presione una telca para volver a intentar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    while (confirmacion.ToLower() != "si" && confirmacion.ToLower() != "no");

    //Si el usuario elige reprogramar la consulta se le cambian los valores de fecha y hora a los ingresados
    if (confirmacion.ToLower() == "si")
    {
        consultaElegida.FechaTurno = nuevaFecha;
        consultaElegida.HoraTurno = nuevaHora;
        Console.Write("Consulta reprogramada correctamente. ");
        Volver();
    }
    //Si el usuario elige la opcion "No" la reprogramacion es cancelada
    else
    {
        Console.Write("Reprogramacion cancelada. ");
        Volver();
    }
}

//Metodo para ver las consultas de un paciente espeficico
void HistorialConsultas()
{
    Console.Clear();
    Console.WriteLine("=== Historial de consultas por paciente ===");

    //Se pide el ID del paciente y verifica que exista
    int idPaciente = LeerEntero("Ingrese el ID del paciente");

    if (!listaPacientes.Any(paciente => paciente.IdPaciente == idPaciente))
    {
        Console.Write("No se encontro un paciente con ese ID. ");
        Volver();
        return;
    }

    //Verifica que el paciente tenga alguna consulta registrada
    if (!listaTurnos.Any(turno => turno.IdPaciente == idPaciente))
    {
        Console.Write("El paciente ingresado no tiene ninguna consulta registrada.");
        Volver();
        return;
    }

    //Guarda en una lista todos los turnos del paciente
    List<Turnos> listaFiltrada = listaTurnos.FindAll(turno => turno.IdPaciente == idPaciente);

    //Ordena los turnos por fecha en orden descendiente
    listaFiltrada.OrderByDescending(turno => turno.EstadoTurno).ToList();
    //Muestra todos los turnos
    listaFiltrada.ForEach(turno => Console.WriteLine(turno));

    Volver();
}
#endregion

#region Metodos menú 3
// Metodo para registrar un nuevo pago de turno
void RegistrarPago()
{
    Console.Clear();
    Console.WriteLine("=== Registrar nuevo pago ===");
    
    // Inicializa todos los datos que se deben obtener
    int idTurno = 0;
    DateOnly fechaPago = new DateOnly(2026, 12, 31);
    int monto = 0;
    string metodo = "";

    // Verifica si la consulta existe o si ya tiene asignada un pago
    do
    {
        idTurno = LeerEntero("Id de la consulta a pagar");
        if (!listaTurnos.Exists(turno => turno.IdTurno == idTurno))
            Console.WriteLine("No existe la consulta. Intente nuevamente.");
        else if (listaPagos.Exists(pago => pago.IdTurno == idTurno))
            Console.WriteLine("Esa consulta ya tiene un pago registrado. Intente nuevamente.");
    } while (!listaTurnos.Exists(turno => turno.IdTurno == idTurno) || listaPagos.Exists(pago => pago.IdTurno == idTurno));

    // Captura el turno correspondiente al Id ingresado y muestra info relevante para facilitar el proceso
    Turnos turno = listaTurnos.Find(turno => turno.IdTurno == idTurno)!;
    Console.WriteLine($"Turno: ID: {turno.IdTurno}, Fecha: {turno.FechaTurno}, Hora: {turno.HoraTurno}");

    // Solo se puede registrar un pago posterior a la fecha de cuando se agendo la consulta
    do
    {
        fechaPago = LeerFecha("Fecha de pago");
        if (fechaPago < turno.FechaTurno)
            Console.WriteLine("La fecha de pago no puede ser anterior a cuando se agendó la consulta. Intente nuevamente.");
    } while (fechaPago < turno.FechaTurno);

    monto = LeerEntero("Monto");

    Console.WriteLine("Elija el método de pago: ");
    Console.WriteLine("1. Efectivo");
    Console.WriteLine("2. Débito");
    Console.WriteLine("3. Crédito");
    Console.WriteLine("4. Transferencia bancaria");

    Console.Write("Opción: ");
    string opcion = Console.ReadKey().KeyChar.ToString();
    switch (opcion)
    {
        case "1":
            metodo = "Efectivo";
            break;

        case "2":
            metodo = "Débito";
            break;

        case "3":
            metodo = "Crédito";
            break;

        case "4":
            metodo = "Transferencia bancaria";
            break;

        default:
            Console.WriteLine("Valor no válido. Presione una tecla para continuar...");
            Console.ReadKey();
            break;
    }

    // Toma todos los datos, crea un nuevo objeto Pagos y lo guarda en la lista de pagos existente
    listaPagos.Add(new Pagos(idTurno, fechaPago, monto, metodo));
    Console.WriteLine("\nPago registrado exitosamente. ");
    Volver();
}

// Metodo que genera un archivo de texto .txt con los datos del pago solicitado
void EmitirComprobante()
{
    Console.Clear();
    Console.WriteLine("=== Emitir comprobante de pago ===");

    int idPago = 0;

    // Si no hay pagos
    if (listaPagos.Count == 0)
    {
        Console.WriteLine("No hay pagos de los cuales emitir un comprobante.");
        Volver();
        return;
    }

    // Valida que el id del pago ingresado exista en la lista
    do
    {
        idPago = LeerEntero("Ingrese el Id del pago del cual emitir el comprobante");
        if (!listaPagos.Exists(pago => pago.IdPago == idPago))
            Console.WriteLine("No existe ese pago. Intente nuevamente.");
    } while (!listaPagos.Exists(pago => pago.IdPago == idPago));

    // Captura el pago con el mismo id que el ingresado
    Pagos pagoAEmitir = listaPagos.Find(pago => pago.IdPago == idPago)!;

    // Ruta del archivo donde se guarda el comprobante de pago por defecto -> string rutaArchivo = "compPagoX.txt";
    // Con esta variación los archivos se guardan en el escritorio
    // El nombre del archivo cambia dependiendo del id del comprobante solicitado
    string rutaArchivo = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
        $"compPago{pagoAEmitir.IdPago}.txt"
    );

    // Usamos StreamWriter para escribir el archivo
    using StreamWriter escritor = new(rutaArchivo);

    // Cada dato se separa con un salto de linea
    escritor.WriteLine($"Pago: \nID del pago: {pagoAEmitir.IdPago} \nID del turno a pagar: {pagoAEmitir.IdTurno} \nMonto total: {pagoAEmitir.Monto} \nMétodo de pago: {pagoAEmitir.MetodoPago} \nFecha de pago: {pagoAEmitir.FechaPago}");

    Console.WriteLine("");
    Console.Write("Comprobante emitido exitosamente, lo podrás encontrar en el escritorio. ");
    Volver();
}

//Metodo para consultar los pagos registrados de un paciente
void ConsultarPagos()
{
    Console.Clear();
    Console.WriteLine("=== Consultar pagos por paciente ===");
    //Verifica que hayan pagos registrados
    if (listaPagos.Count == 0)
    {
        Console.WriteLine("No hay pagos registrados en este momento.");
        Volver();
        return;
    }
    //Pide el ID del paciente a consultar
    int idPaciente = LeerEntero("Ingrese el id del paciente");
    if (!listaPacientes.Any(paciente => paciente.IdPaciente == idPaciente))
    {
        Console.WriteLine("No se encontro un paciente con ese ID");
        Volver();
        return;
    }
    //Crea una lista de los turnos del paciente
    List<Turnos> listaFiltrada = listaTurnos.FindAll(turno => turno.IdPaciente == idPaciente);
    //Crea una lista para agregarle solo las IDs de los turnos del paciente
    List<int> ListaIDs = new List<int>();
    foreach (Turnos turno in listaFiltrada)
    {
        ListaIDs.Add(turno.IdTurno);
    }
    //Crea una lista donde se guarda el pago que tenga el ID del turno
    List<Pagos> listaPagosF = new List<Pagos>();
    foreach (int id in ListaIDs)
    {
        Pagos pago = listaPagos.Find(pago => pago.IdTurno == id)!;
        listaPagosF.Add(pago);
    }
    //Verifica que hayan pagos con ese ID de turno
    if (listaPagosF.Count == 0)
    {
        Console.WriteLine("El paciente ingresado no tiene pagos registrados");
        Volver();
        return;
    }
    //Muestra todos los pagos
    foreach (Pagos pago in listaPagosF)
    {
        Console.WriteLine(pago + "\n");
    }

    Volver();
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

    Volver();
}

// Metodo para listar todos los medicos ordenados por especialidad
void ListadoMedicos()
{
    Console.Clear();
    Console.WriteLine("=== Listado de médicos ===");
    listaMedicos = listaMedicos.OrderBy(medico => medico.Especialidad).ToList();
    foreach (Medicos medico in listaMedicos)
       
    {
        Console.WriteLine($"Medico: {medico.Nombre} {medico.Apellido}, Matricula: {medico.Matricula}, Especialidad: {medico.Especialidad}");
    }

    Volver();
}

//Metodo para mostrar las consulas mas frecuentes por especialidad
void ConsultasFrecuentes()
{
    Console.Clear();
    Console.WriteLine("=== Consultas mas frecuentes por especialidad ===");

    //Diccionario para guardar la especialidad como clave y la cantidad de consultas como valor
    Dictionary<string, int> dEspecialidad = new();
    dEspecialidad.Add("Cardiología", 0);
    dEspecialidad.Add("Pediatría", 0);
    dEspecialidad.Add("Dermatología", 0);
    dEspecialidad.Add("Neurología", 0);

    //foreach para encontrar el medico que atiende en cada turno y guardar su especialidad para despues sumarle 1 al valor de esa especialidad en el diccionario
    foreach (var turno in listaTurnos)
    {
        int idMedicoTurno = turno.IdMedicos;
        Medicos medicoEncontrado = listaMedicos.Find(m => m.IdMedico == idMedicoTurno)!;
        string especialidad = medicoEncontrado.Especialidad!;

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

    Volver();
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
        Medicos medicoEncontrado = listaMedicos.Find(m => m.IdMedico == idMedicoTurno)!;
        medicoEncontrado.CantConsultas++;
    }
    //Ordena la lista de medicos en orden descendiente y muestra el nombre, apellido y cantidad de consultas de cada medico
    listaMedicos = listaMedicos.OrderByDescending(medico => medico.CantConsultas).ToList();
    listaMedicos.ForEach(medico => Console.WriteLine($"Medico: {medico.Nombre} {medico.Apellido} | Cantidad de consultas: {medico.CantConsultas}"));

    Volver();
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
        Console.Write("Ingrese el año: ");
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
        else if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && (dia < 1 || dia > 30))
            Console.WriteLine("El dia ingresado no puede ser mayor a 30. Intente nuevamente.");
        else if ((mes == 2) && DateTime.IsLeapYear(anio) && (dia < 1 || dia > 29))
            Console.WriteLine("El dia ingresado no puede ser mayor a 29. Intente nuevamente.");
        else if ((mes == 2) && (dia < 1 && dia > 28))
            Console.WriteLine("El dia ingresado no puede ser mayor a 28. Intente nuevamente.");
        else if (dia < 1 && dia > 31)
            Console.WriteLine("El mes ingresado no puede ser mayor a 31. Intente nuevamente.");
    } while (!resultado2 || ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && (dia < 1 || dia > 30)) || ((mes == 2) && DateTime.IsLeapYear(anio) && (dia < 1 || dia > 29)) ||
        ((mes == 2) && (dia < 1 || dia > 28)) || (dia < 1 || dia > 31));

    // Se necesita guardar en una variable tipo var el formato de calendario necesitado
    var calendarioGregoriano = new System.Globalization.GregorianCalendar();
    return new DateOnly(anio, mes, dia, calendarioGregoriano);
}

// Metodo para ingresar un string con formato de hora
string LeerHora()
{
    string? valor;
    do
    {
        Console.Write("Ingrese una hora con el siguiente formato => '12:30': ");
        valor = Console.ReadLine()?.Trim()!;

        if (!valor.Contains(':'))
            Console.WriteLine("Hora incorrectamente ingresada, intente nuevamente.");
        else if (!valor.EndsWith('0'))
            Console.WriteLine("Ingrese la hora en incrementos de 30 minutos, intente nuevamente.");
    } while (!valor.Contains(':') && !valor.EndsWith('0'));
    return valor;
}

// Metodo para ingresar un email, valida que la cadena ingresada contenga los caracteres '@' y '.'
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

// Metodo para ingresar una contraseña, valida que la cadena ingresada sea mayor a 8 digitos o que no este vacía
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

// Metodo para ingresar un documento de identidad, valida que la cadena ingresada sea exactamente de 8 digitos
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

#region Metodos Independientes
/* Metodo que devuelve un diccionario de clave string y valor string con los usuarios y contraseñas de todos los
 * recepcionistas administrativos presentes en la lista listaRecepcionistas 
 */
Dictionary<string, string> GuardarContrReps()
{
    Dictionary<string, string> contrReps = new Dictionary<string, string>();
    foreach (Recepcionistas rep in listaRecepcionistas)
    {
        contrReps.Add(rep.Usuario!, rep.Contrasenia!);
    }
    return contrReps;
}

/* Metodo que recorre todos los turnos precargados y actualiza las horas que cada uno ocupa, ya que
 * al inicializarse de esa forma los datos utilizados no cambian, llevando a poder agendar
 * dos turnos en la misma hora
 */
void ActualizarDatos()
{
    // Recorre la lista de turnos en listaTurnos
    foreach (Turnos turno in listaTurnos)
    {
        // Captura el id del paciente asignado en el turno
        int idPaciente = turno.IdPaciente;
        
        // Captura el medico asignado a el turno y extrae la lista de horas del mismo
        Medicos medicoAActualizar = listaMedicos.Find(medico => medico.IdMedico == turno.IdMedicos)!;
        List<Hora> listaHoras = medicoAActualizar.HorariosDisponibles!;

        // Obtiene el nombre del dia de la semana de la fecha del turno para verificar que el medico este atendiendo ese dia y lo pasa a español
        var idioma = new System.Globalization.CultureInfo("es-ES");
        var diaSemana = turno.FechaTurno.DayOfWeek;
        var nombreDia = idioma.DateTimeFormat.GetDayName(diaSemana);

        /* Solo hace el proceso en los turnos que tengan estado 1 (Agendado), ya que 2 indica que fue realizado el turno
            y 3 indica que fue cancelado, ambos liberando devuelta el horario asignado */
        if (turno.EstadoTurno == 1)
        {
            // Revisa si la hora existe y es del dia indicado
            if (listaHoras.Exists(hora => (hora.HoraConsulta == turno.HoraTurno) && (hora.DiaConsulta == nombreDia)))
            {
                var horaAModificar = listaHoras.FirstOrDefault(hora => (hora.HoraConsulta == turno.HoraTurno) && (hora.DiaConsulta == nombreDia))!;
                if (horaAModificar.IdPaciente == 0)
                {
                    horaAModificar.IdPaciente = idPaciente;
                }
            }
        }
    }
}

// Metodo para pausar el proceso, solo continua una vez la persona presiona cualquier tecla
static void Pausar()
{
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadKey();
}

// Metodo similar a pausar, pero con la palabra volver en vez de continuar
static void Volver()
{
    Console.WriteLine("Presione una tecla para volver...");
    Console.ReadKey();
}
#endregion