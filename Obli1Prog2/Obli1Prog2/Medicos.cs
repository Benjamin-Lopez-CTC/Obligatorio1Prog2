using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Medicos : Persona
    {
        private static int ContadorID = 1;
        public int CantConsultas = 0;

        #region Propiedades
        public int IdMedico { get; private set; }
        public string? Especialidad { get; set; }
        public string? Matricula { get; set; }
        public string[]? DiasAtencion { get; set; }
        public List<Hora>? HorariosDisponibles { get; set; }
        #endregion

        #region Constructores
        public Medicos(string nombre, string apellido, string especialidad, string matricula,
            string nombreUsuario, string contrasenia, string[] diasAtencion, List<Hora> horariosDisponibles) : base(nombre, apellido, nombreUsuario, contrasenia)
        {
            IdMedico = ContadorID++;
            Nombre = nombre;
            Apellido = apellido;
            Especialidad = especialidad;
            Matricula = matricula;
            Usuario = nombreUsuario;
            Contrasenia = contrasenia;
            DiasAtencion = diasAtencion;
            HorariosDisponibles = horariosDisponibles;
        }

        public Medicos()
        {
            IdMedico = ContadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            var dias = DiasAtencion != null ? string.Join(", ", DiasAtencion) : "No especificado";
            var horas = HorariosDisponibles != null ? string.Join(", ", HorariosDisponibles) : "No especificado";
            return $"Médico: ID: {IdMedico}, Nombre: {Nombre}, Apellido {Apellido}, Especialidad: {Especialidad}, Matricula: {Matricula}, Dias de atención: {dias}, Horarios: {horas}";
        }

        private static List<Hora> GenerarHorarios(string[] dias, TimeSpan inicio, TimeSpan fin)
        {
            var lista = new List<Hora>();
            for (var t = inicio; t <= fin; t = t.Add(TimeSpan.FromMinutes(30)))
            {
                string horaStr = t.ToString(@"h\:mm");
                foreach (var dia in dias)
                {
                    lista.Add(new Hora(horaStr, dia, 0));
                }
            }
            return lista;
        }

        public static List<Medicos> CargarMedicos()
        {
            return new List<Medicos>
            {
                new Medicos
                {
                    Nombre = "Lucas",
                    Apellido = "Barroso",
                    Especialidad = "Cardiología",
                    Matricula = "64574",
                    Usuario = "lucasb",
                    Contrasenia = "luc4s574",
                    DiasAtencion = new string[] {"lunes", "miercoles", "viernes" },
                    HorariosDisponibles = GenerarHorarios(new string[] {"lunes", "miercoles", "viernes"}, TimeSpan.FromHours(9), TimeSpan.FromHours(15))
                },
                new Medicos
                {
                    Nombre = "María",
                    Apellido = "Gómez",
                    Especialidad = "Pediatría",
                    Matricula = "98765",
                    Usuario = "mariag",
                    Contrasenia = "m4ri@g987",
                    DiasAtencion = new string[] { "martes", "jueves" },
                    HorariosDisponibles = GenerarHorarios(new string[] {"lunes", "martes"}, TimeSpan.FromHours(7), TimeSpan.FromHours(13))
                },
                new Medicos
                {
                    Nombre = "Alejandro",
                    Apellido = "Ruiz",
                    Especialidad = "Cardiología",
                    Matricula = "11223",
                    Usuario = "aleruiz",
                    Contrasenia = "al3ru!z",
                    DiasAtencion = new string[] { "lunes", "martes", "miercoles" },
                    HorariosDisponibles = GenerarHorarios(new string[] {"lunes", "martes", "miercoles"}, TimeSpan.FromHours(9), TimeSpan.FromHours(16).Add(TimeSpan.FromMinutes(30)))
                },
                new Medicos
                {
                    Nombre = "Sofía",
                    Apellido = "Martínez",
                    Especialidad = "Dermatología",
                    Matricula = "55440",
                    Usuario = "sofiam",
                    Contrasenia = "s0fi@554",
                    DiasAtencion = new string[] { "miércoles", "viernes" },
                    HorariosDisponibles = GenerarHorarios(new string[] {"miercoles", "viernes"}, TimeSpan.FromHours(7).Add(TimeSpan.FromMinutes(30)), TimeSpan.FromHours(13))
                },
                new Medicos
                {
                    Nombre = "Javier",
                    Apellido = "Álvarez",
                    Especialidad = "Neurología",
                    Matricula = "77881",
                    Usuario = "javialv",
                    Contrasenia = "j4vi@778",
                    DiasAtencion = new string[] { "lunes", "jueves" },
                    HorariosDisponibles = GenerarHorarios(new string[] {"lunes", "jueves"}, TimeSpan.FromHours(10), TimeSpan.FromHours(17).Add(TimeSpan.FromMinutes(30)))
                }
            };
        }
        #endregion
    }
}
