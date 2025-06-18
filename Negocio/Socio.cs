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
    }
}
