using Grupo06_TP_Programacion1.Dao;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Servicio
{
    public class PersonaServicio
    {
        PersonaDao oDaoP;
        public PersonaServicio()
        {
            oDaoP = new PersonaDao();
        }

        public List<TipoDocumento> TraerTiposDocumentos()
        {
            return oDaoP.RecuperarTiposDocumentos();
        }

        public List<Genero> TraerGeneros()
        {
            return oDaoP.RecuperarGeneros();
        }

        public List<Provincia> TraerProvincias()
        {
            return oDaoP.RecuperarProvincias();
        }
        public List<Localidad> TraerLocalidades(int idProvincia)
        {
            return oDaoP.RecuperarLocalidades(idProvincia);
        }
        public List<Barrio> TraerBarrios(int idLocalidad)
        {
            return oDaoP.RecuperarBarrios(idLocalidad);
        }
        public List<Curso> TraerCursos()
        {
            return oDaoP.RecuperarCursos();
        }
        public List<Contextura> TraerContexturas()
        {
            return oDaoP.RecuperarContexturas();
        }
        public List<TipoSangre> TraerTiposSangre()
        {
            return oDaoP.RecuperarTiposSangre();
        }

    }
}
