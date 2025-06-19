using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Negocio
{
    public class Clase
    {
        public int IdClase { get; set; }
        public decimal Precio { get; set; }

        public Curso Curso { get; set; }

        public Profesor Profesor { get; set; }
    }
}
