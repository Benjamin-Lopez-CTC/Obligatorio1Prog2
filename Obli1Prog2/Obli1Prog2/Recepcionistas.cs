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
        #endregion

        #region Constructores
        public Recepcionistas() 
        {
            IdRecepcionista = contadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString() 
        {
            return $"ID: {IdRecepcionista},";
        }
        #endregion
    }
}
