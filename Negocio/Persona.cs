using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Negocio
{
    public abstract class Persona
    {
        // Atributos   
        protected private string apellido;
        protected private string nombre;
        protected private TipoDocumento tipo;
        protected private string documento;
        protected private Genero genero;
        protected private DateTime fechaNacimiento;
        protected private string email;
        protected private string telefono;
        protected private Barrio barrio;

        // Properties
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public TipoDocumento Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        public Genero Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public Barrio Barrio
        {
            get { return barrio; }
            set { barrio = value; }
        }
    }
}
