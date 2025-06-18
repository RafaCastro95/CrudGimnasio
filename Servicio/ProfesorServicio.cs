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



        public List<TipoDocumento> TraerTiposDocumentos()
        {
            return oDao.RecuperarTiposDocumentos();
        }

        public List<Genero> TraerGeneros()
        {
            return oDao.RecuperarGeneros();
        }
        public List<Provincia> TraerProvincias()
        {
            return oDao.RecuperarProvincias();
        }
        public List<Localidad> TraerLocalidades(int idProvincia)
        {
            return oDao.RecuperarLocalidades(idProvincia);
        }
        public List<Barrio> TraerBarrios(int idLocalidad)
        {
            return oDao.RecuperarBarrios(idLocalidad);
        }
        public List<Curso> TraerCursos()
        {
            return oDao.RecuperarCursos();
        }
        public List<Contextura> TraerContexturas()
        {
            return oDao.RecuperarContexturas();
        }
        public List<TipoSangre> TraerTiposSangre()
        {
            return oDao.RecuperarTiposSangre();
        }

        public int GuardarProfesor(Profesor profesor)
        {
            
            return oDao.InsertarProfesor(profesor);
        }

        public int GuardarSocio (Socio socio)
        {
            return oDao.InsertarSocio(socio);
        }

        public List<Socio> TraerSocios(string filtro, ComboBox combo)
        {
            return oDao.RecuperarSocios(filtro, combo);
        }

        public List<Profesor> TraerProfesores(string filtroNombre, int filtroClase)
        {
            return oDao.RecuperarProfesores(filtroNombre, filtroClase, 0);
        }

        public Profesor TraerProfesorPorID(int idProfesor)
        {
            return oDao.RecuperarProfesorPorID(idProfesor);
        }
    }
}
