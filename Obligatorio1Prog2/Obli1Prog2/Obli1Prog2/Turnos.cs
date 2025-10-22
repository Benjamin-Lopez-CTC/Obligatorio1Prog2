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
        public int IdPaciente { get; private set; }
        public int IdMedicos { get; private set; }
        public DateOnly FechaTurno { get; set; } 
        public float HoraTurno { get; set; } 
        public int EstadoTurno { get; set; }
        #endregion

        #region Constructores
        public Turnos(int idPaciente, int idMedico, DateOnly fechaTurno, float horaTurno, int estadoTurno)
        {
            IdTurno = contadorID++;
            IdPaciente = idPaciente;
            IdMedicos = idMedico;
            FechaTurno = fechaTurno;
            HoraTurno = horaTurno;
            EstadoTurno = estadoTurno;
        }

        public Turnos()
        {
            IdTurno = contadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            var estado = EstadoTurno == 1 ? "Agendada" : EstadoTurno == 2 ? "Realizada" : EstadoTurno == 3 ? "Cancelada" : "Invalido"; 
            return $"Turno: ID Turno: {IdTurno}, ID Paciente: {IdPaciente}, ID Medico: {IdMedicos}, Fecha: {FechaTurno}, Hora: {HoraTurno}, Estado: {estado}";
        }

        public static List<Turnos> CargarTurnos()
        {
            return new List<Turnos>
            {
                new Turnos
                {
                    IdPaciente = 1,
                    IdMedicos = 2,
                    FechaTurno = new DateOnly(2025, 11, 20),
                    HoraTurno = 09.30f,
                    EstadoTurno = 1
                },
                new Turnos
                {
                    IdPaciente = 2,
                    IdMedicos = 1,
                    FechaTurno = new DateOnly(2025, 10, 24),
                    HoraTurno = 10.00f,
                    EstadoTurno = 1
                },
                new Turnos
                {
                    IdPaciente = 3,
                    IdMedicos = 3,
                    FechaTurno = new DateOnly(2025, 12, 01),
                    HoraTurno = 14.30f,
                    EstadoTurno = 2
                },
                new Turnos
                {
                    IdPaciente = 4,
                    IdMedicos = 4,
                    FechaTurno = new DateOnly(2026, 5, 15),
                    HoraTurno = 08.00f,
                    EstadoTurno = 3
                },
                new Turnos
                {
                    IdPaciente = 1,
                    IdMedicos = 2,
                    FechaTurno = new DateOnly(2025, 10, 23),
                    HoraTurno = 16.00f,
                    EstadoTurno = 1
                }
            };

        }
        #endregion
    }
}
