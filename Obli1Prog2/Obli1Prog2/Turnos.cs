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
        public Pacientes IdPaciente { get; private set; }
        public Medicos IdMedicos { get; private set; }
        public DateOnly FechaTurno { get; set; } //Tipo de dato a revisar.
        public TimeOnly HoraTurno { get; set; } //Tipo de dato a revisar.
        public string EstadoTurno { get; set; }
        #endregion

        #region Constructores
        public Turnos(Pacientes idPaciente, Medicos idMedico, DateOnly fechaTurno, TimeOnly horaTurno, string estadoTurno)
        {
            IdTurno = contadorID++;
            IdPaciente = idPaciente;
            IdMedicos = idMedico;
            FechaTurno = fechaTurno;
            HoraTurno = horaTurno;
            EstadoTurno = estadoTurno;
            
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Turno: ID Turno: {IdTurno}, ID Paciente: {IdPaciente}, ID Medico: {IdMedicos}, Fecha: {FechaTurno}, Hora: {HoraTurno}, Estado: {EstadoTurno}";
        }
        #endregion
    }
}
