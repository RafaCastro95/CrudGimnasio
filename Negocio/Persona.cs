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
        protected  string apellido;
        protected  string nombre;
        protected  TipoDocumento tipo;
        protected  string documento;
        protected  Genero genero;
        protected  DateTime fechaNacimiento;
        protected  string email;
        protected  string telefono;
        protected  Barrio barrio;
        protected int activo;
        private Curso curso;

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
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }
        public Curso Curso
        {
            get { return curso; }
            set { curso = value; }
        }

        public Persona()
        {
            apellido = string.Empty;
            nombre = string.Empty;
            tipo = new TipoDocumento();
            documento = string.Empty;
            genero = new Genero();
            fechaNacimiento = DateTime.Now;
            email = string.Empty;
            telefono = string.Empty;
            barrio = new Barrio();
            activo = 1;
            curso = new Curso();
        }
    }
}
