using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Medicos
    {
        private static int ContadorID = 1;

        #region Propiedades
        public int IdMedico { get; private set; }
        public string NombreM { get; set; }
        public string ApellidoM { get; set; }
        public string Especialidad { get; set; }
        public string Matricula { get; set; }
        public string NombreUsuarioM { get; set; }
        public string ContraseniaM { get; set; }
        public string DiasAtencion { get; set; }
        public int HorariosDisponibles { get; set; } //Tipo de dato a revisar.
        #endregion

        #region Constructores
        public Medicos(string nombre, string apellido, string especialidad, string matricula,
            string nombreUsuario, string contrasenia, string diasAtencion, int horariosDisponibles)
        {
            IdMedico = ContadorID++;
            NombreM = nombre;
            ApellidoM = apellido;
            Especialidad = especialidad;
            Matricula = matricula;
            NombreUsuarioM = nombreUsuario;
            ContraseniaM = contrasenia;
            DiasAtencion = diasAtencion;
            HorariosDisponibles = horariosDisponibles;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Médico: ID: {IdMedico}, Nombre: {NombreM}, Apellido{ApellidoM}, Especialidad: {Especialidad}, Matricula: {Matricula}, Dias de atención: {DiasAtencion}, Horarios disponible: {HorariosDisponibles}";
        }
        #endregion
    }
}
