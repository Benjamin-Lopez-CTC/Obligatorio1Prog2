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
        public int IdTurno { get; private set; }
        public DateOnly FechaPago { get; set; }
        public double Monto { get; set; }
        public string? MetodoPago { get; set; }
        #endregion

        #region Constructores
        public Pagos(int idTurno, DateOnly fechaPago, double monto, string metodoPago)
        {
            IdPago = ContadorID++;
            IdTurno = idTurno;
            FechaPago = fechaPago;
            Monto = monto;
            MetodoPago = metodoPago;
        }

        public Pagos() 
        {
            IdPago = ContadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Pago: ID Pago: {IdPago}, ID Turno: {IdTurno}, Fecha de pago: {FechaPago}, Monto: {Monto}, Metodo de pago: {MetodoPago}";
        }

        // Metodo de carga de datos para el arranque
        public static List<Pagos> CargarPagos() 
        {
            return new List<Pagos>()
            {
                new Pagos
                {
                    IdTurno = 1,
                    FechaPago = new DateOnly(2025, 2, 12),
                    Monto = 1000,
                    MetodoPago = "Efectivo"
                },
                new Pagos
                {
                    IdTurno = 2,
                    FechaPago = new DateOnly(2025, 1, 6),
                    Monto = 4000,
                    MetodoPago = "Efectivo"
                }
            };
        }
        #endregion
    }
}
