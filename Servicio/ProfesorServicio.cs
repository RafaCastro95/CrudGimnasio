using Grupo06_TP_Programacion1.Dao;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo06_TP_Programacion1.Servicio
{
    public class ProfesorServicio
    {
        PersonaDao oDao;

        public ProfesorServicio()
        {
            oDao = new PersonaDao();
        }



        public List<TipoDocumento> RecuperarTiposDocumentos()
        {
            return oDao.RecuperarTiposDocumentos();
        }

        public List<Genero> RecuperarGeneros()
        {
            return oDao.RecuperarGeneros();
        }

        public List<Profesor> RecuperarProfesores(string filtroNombre, int filtroClase)
        {
            return oDao.RecuperarProfesores(filtroNombre, filtroClase, 0);
        }

        public Profesor RecuperarProfesorPorID(int idProfesor)
        {
            return oDao.RecuperarProfesorPorID(idProfesor);
        }
    }
}
