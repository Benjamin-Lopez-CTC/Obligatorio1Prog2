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
        public string Especialidad { get; set; }
        public string Matricula { get; set; }
        public string[] DiasAtencion { get; set; }
        public float[] HorariosDisponibles { get; set; }
        #endregion

        #region Constructores
        public Medicos(string nombre, string apellido, string especialidad, string matricula,
            string nombreUsuario, string contrasenia, string[] diasAtencion, float[] horariosDisponibles) : base(nombre, apellido, nombreUsuario, contrasenia)
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
                    HorariosDisponibles = new float [] { 9.30f, 10.00f, 10.30f, 11.00f, 11.30f, 12.00f, 12.30f, 13.00f, 13.30f, 14.00f, 14.30f, 15.00f, 15.30f }
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
                    HorariosDisponibles = new float[] { 8.00f, 8.30f, 9.00f, 9.30f, 10.00f, 10.30f, 11.00f, 11.30f, 12.00f, 12.30f, 13.00f, 13.30f }
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
                    HorariosDisponibles = new float[] { 9.00f, 9.30f, 10.00f, 10.30f, 11.00f, 11.30f, 12.00f, 12.30f, 13.00f, 13.30f, 14.00f, 14.30f, 15.00f, 15.30f, 16.00f, 16.30f }
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
                    HorariosDisponibles = new float[] { 7.30f, 8.00f, 8.30f, 9.00f, 9.30f, 10.00f, 10.30f, 11.00f, 11.30f, 12.00f, 12.30f, 13.00f }
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
                    HorariosDisponibles = new float[] { 10.00f, 10.30f, 11.00f, 11.30f, 12.00f, 12.30f, 13.00f, 13.30f, 14.00f, 14.30f, 15.00f, 15.30f, 16.00f, 16.30f, 17.00f, 17.30f }
                }
            };
        }
        #endregion
    }
}
