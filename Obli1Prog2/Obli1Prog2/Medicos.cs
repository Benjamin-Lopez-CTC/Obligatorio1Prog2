using System;
using System.Collections.Generic;
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
        #endregion

        #region Constructores
        public Medicos()
        {
            IdMedico = ContadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Medico: ID: {IdMedico}";
        }
        #endregion
    }
}
