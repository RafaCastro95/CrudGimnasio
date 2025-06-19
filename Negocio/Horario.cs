using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Negocio
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public int FrecueciaSemanal { get; set; } 
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }    
    }
}
