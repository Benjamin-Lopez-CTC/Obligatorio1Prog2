using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Hora
    {
        #region Propiedades
        public string HoraConsulta { get; set; }
        public string DiaConsulta { get; set; }
        public int IdPaciente { get; set; }
        #endregion

        #region Constructores
        public Hora(string _horaConsulta, string _diaConsulta, int _idPaciente)
        {
            HoraConsulta = _horaConsulta;
            DiaConsulta = _diaConsulta;
            IdPaciente = _idPaciente;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Hora: {HoraConsulta}, Dia: {DiaConsulta}, ID del paciente: {IdPaciente}.";
        }
        #endregion
    }
}
