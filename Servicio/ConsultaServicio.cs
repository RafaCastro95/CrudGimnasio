using Grupo06_TP_Programacion1.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Servicio
{
    public class ConsultaServicio
    {
        ConsultaDao oDaoC;
        public ConsultaServicio()
        {
            oDaoC = new ConsultaDao();
        }

        public DataTable Resultado1()
        {
            return oDaoC.Consulta1();
        }

        public DataTable Resultado2()
        {
            return oDaoC.Consulta2();
        }

        public DataTable Resultado3()
        {
            return oDaoC.Consulta3();
        }
        public DataTable Resultado4()
        {
            return oDaoC.Consulta4();
        }
        public DataTable Resultado5()
        {
            return oDaoC.Consulta5();
        }
        public DataTable Resultado6()
        {
            return oDaoC.Consulta6();
        }
    }
}
