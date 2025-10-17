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
        public string ObraSocial { get; set; }
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
        return$"Paciente: ID: {IdPaciente}, Nombre: {NombreP}, Apellido: {ApellidoP}, Numero de documento {NumDocumento,} Fecha de nacimiento: {FechaNacimiento}, Telefono: {Telefono}, Email: {Email}, Obra social: {ObraSocial}";
        }
        #endregion
    }
}