// Program.cs
using System.Collections.Generic;

bool salir = false;

do
{
    MostrarMenuPrincipal();

    Console.WriteLine("Seleccione una opción: ");
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
            Pagos();
            break;

        case "4":
            EstadisticasReportes();
            break;

        case "0":
            salir = true;
            break;

        default:
            Console.WriteLine("Opción invalida. Presione una tecla para continuar...");
            Console.ReadKey().KeyChar.ToString();
            break;
    }
}
while (!salir);

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

void GestionUsuarios()
{
    bool volver1 = false;

    do
    {
        Console.Clear();
        Console.WriteLine("===== Gestión de usuarios =====");
        Console.WriteLine("1. Registrar nuevo paciente");
        Console.WriteLine("2. Login de administrativos");
        Console.WriteLine("3. Cambiar contraseña");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.WriteLine("Seleccione una opción: ");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion)
        {
            case "1":
                //RegistrarUsuario();
                break;

            case "2":
                //LoginAdmin();
                break;

            case "3":
                //CambiarPassWord();
                break;

            case "0":
                volver1 = true;
                break;

            default:
                Console.WriteLine("Valor no valido. Presione una tecla para continuar...");
                Console.ReadKey();
                break;
        }
    } while (!volver1);
}

void GestionTurnos() 
{
    bool volver2 = false;
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

        Console.WriteLine("Seleccione una opción: ");
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
                volver2 = true;
                break;
            default:
                Console.WriteLine("Valor no valido. Presione una tecla para continuar...");
                Console.ReadKey().KeyChar.ToString();
                break;
        }
    } while (!volver2);

}

void Pagos() 
{
    bool volver3 = false;
    do
    {
        Console.Clear();
        Console.WriteLine("===== Menu de Pagos =====");
        Console.WriteLine("1. Registrar pago de consulta");
        Console.WriteLine("2. Emitir comprobante");
        Console.WriteLine("3. Consultar pagos");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.WriteLine("Seleccione una opción: ");
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
                volver3 = true;
                break;

            default:
                Console.WriteLine("Valor no valido. Presione una tecla para continuar...");
                Console.ReadKey().KeyChar.ToString();
                break;
        }
    } while (!volver3);
}

void EstadisticasReportes() 
{
    bool volver4 = false;
    do
    {
        Console.Clear();
        Console.WriteLine("===== Estadísticas y reportes =====");
        Console.WriteLine("1. Listado de pacientes");
        Console.WriteLine("2. Listado de médicos");
        Console.WriteLine("3. Consultas frecuentes");
        Console.WriteLine("4. Médicos mas consultados");
        Console.WriteLine("0. Volver");
        Console.WriteLine("");

        Console.WriteLine("Seleccione una opción.");
        string opcion = Console.ReadKey().KeyChar.ToString();
        switch (opcion) 
        {
            case "1":
                //ListadoPacientes();
                break;
            case "2":
                //ListadoMedicos();
                break;
            case "3":
                //ConsultasFrecuentes();
                break;
            case "4":
                //MedicosConsultados();
                break;
            case "0":
                volver4 = true;
                break;
            default:
                Console.WriteLine("Valor no valido. Presiona una tecla para continuar...");
                Console.ReadKey();
                break;

        }
    } while (!volver4);
}