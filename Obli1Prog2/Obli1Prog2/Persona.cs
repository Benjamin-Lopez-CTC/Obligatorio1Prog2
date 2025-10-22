using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal abstract class Persona
    {
        #region Propiedades
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasenia { get; set; }
        #endregion

        #region Constructores
        public Persona(string _nombre, string _apellido, string _usuario, string _contrasenia)
        {
            Nombre = _nombre;
            Apellido = _apellido;
            Usuario = _usuario;
            Contrasenia = _contrasenia;
        }

        public Persona()
        {

        }
        #endregion

    }
}
