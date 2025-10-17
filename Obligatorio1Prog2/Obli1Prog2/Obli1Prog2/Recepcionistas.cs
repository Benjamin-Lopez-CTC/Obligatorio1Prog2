using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Recepcionistas
    {
        private static int contadorID = 1;

        #region Propiedades
        public int IdRecepcionista { get; private set; }
        public string NombreR { get; set; }
        public string ApellidoR { get; set; }
        public int NumDocumentoR { get; set; }
        public string NombreUsuarioR { get; set; }
        public string ConstraseniaR { get; set; }
        #endregion

        #region Constructores
        public Recepcionistas(string nombre, string apellido, int numDocumento, string nombreUsuario, string contrasenia)
        {
            IdRecepcionista = contadorID++;
            NombreR = nombre;
            ApellidoR = apellido;
            NumDocumentoR = numDocumento;
            NombreUsuarioR = nombreUsuario;
            ConstraseniaR = contrasenia;
        }
        #endregion

        #region Metodos
        public override string ToString() 
        {
            return $"Recepcionista: ID: {IdRecepcionista}, Nombre {NombreR}, Apellido: {ApellidoR}, Numero de documento: {NumDocumentoR}";
        }
        #endregion
    }
}
