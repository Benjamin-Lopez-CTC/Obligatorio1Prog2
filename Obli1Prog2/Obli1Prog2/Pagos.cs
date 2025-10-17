using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Pagos
    {
        private static int ContadorID = 1;

        #region Propiedades
        public int IdPago { get; private set; }
        #endregion

        #region Constructores
        public Pagos()
        {
            IdPago = ContadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Pago: ID: {IdPago}";
        }
        #endregion
    }
}
