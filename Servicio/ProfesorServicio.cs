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
        public List<Provincia> RecuperarProvincias()
        {
            return oDao.RecuperarProvincias();
        }
        public List<Localidad> RecuperarLocalidades(int idProvincia)
        {
            return oDao.RecuperarLocalidades(idProvincia);
        }
        public List<Barrio> RecuperarBarrios(int idLocalidad)
        {
            return oDao.RecuperarBarrios(idLocalidad);
        }

    }
}
