using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Pacientes
    {
        private static int contadorID = 1;

        #region Propiedades
        public int IdPaciente { get; private set; }
        #endregion

        #region Constructores
        public Pacientes()
        {
            IdPaciente = contadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
        return$"ID: {IdPaciente},";
        }
        #endregion
    }
}