using Grupo06_TP_Programacion1.Dao;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Servicio
{
    public class SocioServicio
    {
        SocioDao oDaoSocio;
        public SocioServicio()
        {
            oDaoSocio = new SocioDao();
        }

        public List<Socio> TraerSocios(string filtro, int valorCurso)
        {
            return oDaoSocio.RecuperarSocios(filtro, valorCurso);
        }
        public int GuardarSocio(Socio socio)
        {
            return oDaoSocio.InsertarSocio(socio);
        }
        public int EliminarSocio(int id_socio)
        {
            return oDaoSocio.EliminarSocio(id_socio);
        }

        public DataTable RecuperarSocio(string Documento)
        {
            return oDaoSocio.RecuperarSocioPorDocumento(Documento);
        }
        public int EditarSocio(string documento, Socio socio)
        {
            return oDaoSocio.EditarSocio(documento, socio);
        }
    }
}
