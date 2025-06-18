using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Negocio
{
    public class Socio : Persona
    {
        //Atributos
        private Contextura contextura;
        private TipoSangre tipoSangre;


        //Properties
        public int IdSocio { get; set; }
        public Contextura Contextura
        {
            get { return contextura; }
            set { contextura = value; }
        }
        public TipoSangre TipoSangre
        {
            get { return tipoSangre; }
            set { tipoSangre = value; }
        }

        public Curso Curso { get;  set; }
        public DateTime FechaInicio { get;  set; }
        public DateTime FechaFin { get; set; }
        public decimal Monto { get; set; }

        public Socio() : base()
        {
            contextura = new Contextura();
            tipoSangre = new TipoSangre();
            Curso = new Curso();
            FechaInicio = DateTime.Now;
            FechaFin = DateTime.Now;
            Monto = 0;
        }

    }
}
