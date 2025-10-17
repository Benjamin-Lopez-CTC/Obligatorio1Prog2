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
        public Turnos IdTurno { get; private set; }
        public DateOnly FechaPago { get; set; } //Tipo de dato a revisar.
        public int Monto { get; set; }
        public string MetodoPago { get; set; }
        #endregion

        #region Constructores
        public Pagos(Turnos idTurno, DateOnly fechaPago, int monto, string metodoPago)
        {
            IdPago = ContadorID++;
            IdTurno = idTurno;
            FechaPago = fechaPago;
            Monto = monto;
            MetodoPago = metodoPago;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Pago: ID Pago: {IdPago}, ID Turno: {IdTurno}, Fecha de pago: {FechaPago}, Monto: {Monto}, Metodo de pago: {MetodoPago}";
        }
        #endregion
    }
}
