using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Recepcionistas : Persona
    {
        private static int contadorID = 1;

        #region Propiedades
        public int IdRecepcionista { get; private set; }
        public int NumDocumentoR { get; set; }
        #endregion

        #region Constructores
        public Recepcionistas(string nombre, string apellido, int numDocumento, string nombreUsuario, string contrasenia) : base(nombre, apellido, nombreUsuario, contrasenia)
        {
            IdRecepcionista = contadorID++;
            NumDocumentoR = numDocumento;
        }
        #endregion

        #region Metodos
        public override string ToString() 
        {
            return $"Recepcionista: ID: {IdRecepcionista}, Nombre {Nombre}, Apellido: {Apellido}, Numero de documento: {NumDocumentoR}";
        }

        // Metodo de carga de datos para el arranque
        public static List<Recepcionistas> CargarReps()
        {
            return new List<Recepcionistas>
            {
                new Recepcionistas("Ana", "López", 30123456, "ana.lopez", "An@L0pez2025"),
                new Recepcionistas("Martín", "Pérez", 28765432, "martin.p", "M4rt!nP87"),
                new Recepcionistas("Carolina", "Garcia", 32987654, "cgarcia", "C@ro2024"),
                new Recepcionistas("Javier", "Sosa", 24567891, "javi_sosa", "J4v!er91"),
                new Recepcionistas("Florencia", "Ramos", 31415926, "flor.ramos", "Fl0r#159"),
                new Recepcionistas("prueba", "login", 31234324, "prueba", "pruebacontra")
            };

        }
        #endregion
    }
}
