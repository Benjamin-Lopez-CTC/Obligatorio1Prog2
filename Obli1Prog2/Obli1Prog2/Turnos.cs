using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Turnos
    {
        private static int contadorID = 1;

        #region Propiedades
        public int IdTurno { get; private set; }
        #endregion

        #region Constructores
        public Turnos() 
        {
            IdTurno = contadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"ID: {IdTurno},";
        }
        #endregion
    }
}
