
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Pacientes : Persona
    {
        private static int contadorID = 1;

        #region Propiedades
        public int IdPaciente { get; private set; }        
        public int NumDocumentoP { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string? Email { get; set; }
        public string? ObraSocial { get; set; }       
        #endregion

        #region Constructores
        public Pacientes(string nombre, string apellido, int numDocumento, DateOnly fechaNacimiento,
            int telefono, string email, string obraSocial, string nombreUsuarioP, string contraseniaP) : base(nombre, apellido, nombreUsuarioP, contraseniaP)
        {
            IdPaciente = contadorID++;
            NumDocumentoP = numDocumento;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            Email = email;
            ObraSocial = obraSocial;
        }

        public Pacientes()
        {
            IdPaciente = contadorID++;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
        return$"Paciente: ID: {IdPaciente}, Nombre: {Nombre}, Apellido: {Apellido}, Numero de documento: {NumDocumentoP}, Fecha de nacimiento: {FechaNacimiento}, Telefono: {Telefono}, Email: {Email}, Obra social: {ObraSocial}";
        }

        // Metodo de carga de datos para el arranque
        public static List<Pacientes> CargarPacientes()
        {
            return new List<Pacientes> {
                new Pacientes("María", "González", 34567891, new DateOnly(1985, 4, 12), 114567890, "maria.gonzalez@gmail.com", "OSDE", "mariagon", "M4r!a2023"),
                new Pacientes("Santiago", "Fernández", 27894563, new DateOnly(1992, 11, 3), 299412345, "santiago.fernandez@gmail.com", "Swiss Medical", "santi_f", "Santi#92"),
                new Pacientes("Lucía", "Martínez", 41235678, new DateOnly(2000, 6, 21), 115123456, "lucia.martinez@gmail.com", "Galeno", "luciam", "Luci@2000"),
                new Pacientes("Diego", "Rossi", 19876543, new DateOnly(1978, 1, 9), 298412399, "diego.rossi@gmail.com", "Sin Obra Social", "drossi", "D!e9go78"),
                new Pacientes("Laura", "Méndez", 43215678, new DateOnly(1985, 3, 12), 098456732, "laura.mendez85@gmail.com", "Médica Uruguaya", "lauram85", "LauM@1985"),
                new Pacientes("Martín", "Rodríguez", 56789123, new DateOnly(1990, 7, 25), 091223884, "martin.rodriguez90@gmail.com", "BlueCross", "martinr90", "MaR#1990"),
                new Pacientes("Sofía", "Pereira", 59872341, new DateOnly(1998, 11, 3), 097512600, "sofia.pereira98@gmail.com", "CASMU", "sofiap98", "SofP*1998"),
                new Pacientes("Diego", "Fernandez", 37654219, new DateOnly(1982, 1, 19), 092667433, "diego.fernandez82@gmail.com", "Sin Obra Social", "diegof82", "Df82@Med"),
                new Pacientes("Camila", "Alvarez", 62105340, new DateOnly(2001, 9, 8), 099873251, "camila.alvarez01@outlook.com", "CASMU", "camilaa01", "CamA#2001"),
                new Pacientes("Andrés", "Silva", 29871105, new DateOnly(1975, 5, 30), 094320899, "andres.silva75@gmail.com", "Circulo Católico", "andress75", "As75$Med"),
            };
        }
        #endregion
    }
}