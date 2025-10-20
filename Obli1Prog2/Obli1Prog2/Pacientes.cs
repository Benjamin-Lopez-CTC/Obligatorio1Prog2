using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Obli1Prog2
{
    internal class Pacientes
    {
        private static int contadorID = 1;

        #region Propiedades
        public int IdPaciente { get; private set; }
        public string NombreP { get; set; }
        public string ApellidoP { get; set; }
        public int NumDocumento { get; set; }
        public DateOnly FechaNacimiento { get; set; } //Tipo de dato a revisar.
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string? ObraSocial { get; set; }
        public string NombreUsuarioP { get; set; }
        public string ContraseniaP { get; set; }
        #endregion

        #region Constructores
        public Pacientes(string nombre, string apellido, int numDocumento, DateOnly fechaNacimiento,
            int telefono, string email, string obraSocial, string nombreUsuarioP, string contraseniaP)
        {
            IdPaciente = contadorID++;
            NombreP = nombre;
            ApellidoP = apellido;
            NumDocumento = numDocumento;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            Email = email;
            ObraSocial = obraSocial;
            NombreUsuarioP = nombreUsuarioP;
            ContraseniaP = contraseniaP;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
        return$"Paciente: ID: {IdPaciente}, Nombre: {NombreP}, Apellido: {ApellidoP}, Numero de documento: {NumDocumento}, Fecha de nacimiento: {FechaNacimiento}, Telefono: {Telefono}, Email: {Email}, Obra social: {ObraSocial}";
        }

        // Metodo de carga de datos para el arranque
        public static List<Pacientes> CargarPacientes()
        {
            return new List<Pacientes> {
                new Pacientes("María", "González", 34567891, new DateOnly(1985, 4, 12), 114567890, "maria.gonzalez@gmail.com", "OSDE", "mariagon", "M4r!a2023"),
                new Pacientes("Santiago", "Fernández", 27894563, new DateOnly(1992, 11, 3), 299412345, "santiago.fernandez@gmail.com", "Swiss Medical", "santi_f", "Santi#92"),
                new Pacientes("Lucía", "Martínez", 41235678, new DateOnly(2000, 6, 21), 115123456, "lucia.martinez@gmail.com", "Galeno", "luciam", "Luci@2000"),
                new Pacientes("Diego", "Rossi", 19876543, new DateOnly(1978, 1, 9), 298412399, "diego.rossi@gmail.com", "Sin Obra Social", "drossi", "D!e9go78")
            };
        }
        #endregion
    }
}