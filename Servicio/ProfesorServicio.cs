using Grupo06_TP_Programacion1.Dao;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Profesor> RecuperarProfesores(string filtroNombre, int filtroClase)
        {
            return oDao.RecuperarProfesores(filtroNombre, filtroClase, 0);
        }

        public Profesor RecuperarProfesorPorID(int idProfesor)
        {
            return oDao.RecuperarProfesorPorID(idProfesor);
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

        public List<Socio> TraerSocios(string filtro, int valorCurso)
        {
            return oDao.RecuperarSocios(filtro, valorCurso);
        }

        public List<Clase> TraerClasesPorProfesor(int idProfesor)
        {
            return oDao.TraerClasesPorProfesor(idProfesor);
        }

        public List<Socio> TraerSociosPorClase(int idClase, int idProfesor)
        {
            return oDao.TraerSociosPorClase(idClase, idProfesor);
        }
        public int ElimianarProfesor(int id_profesor)
        {
            return oDao.EliminarProfesor(id_profesor);
        }
        public int EliminarSocio(int id_socio)
        {
            return oDao.EliminarSocio(id_socio);
        }
        public int ActualizarProfesor(int IdProfesor, Profesor profesor)
        {
            return oDao.EditarProfesor(IdProfesor, profesor);
        }

        public DataTable RecuperarProfesor(int IdProfesor)
        {
            return oDao.RecuperarProfesorPorId(IdProfesor);
        }

        public DataTable RecuperarSocio(string Documento)
        {
            return oDao.RecuperarSocioPorDocumento(Documento);
        }

        public DataTable Resultado1()
        {
            return oDao.Consulta1();
        }

        public DataTable Resultado2()
        {
            return oDao.Consulta2();
        }

        public DataTable Resultado3()
        {
            return oDao.Consulta3();
        }
        public DataTable Resultado4()
        {
            return oDao.Consulta4();
        }
        public DataTable Resultado5()
        {
            return oDao.Consulta5();
        }
        public DataTable Resultado6()
        {
            return oDao.Consulta6();
        }
    }
}
