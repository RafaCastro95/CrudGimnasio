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
        ProfesorDao oDaoProfesor;

        public ProfesorServicio()
        {
            oDaoProfesor = new ProfesorDao();
        }
        public List<Profesor> RecuperarProfesores(string filtroNombre, int filtroClase)
        {
            return oDaoProfesor.RecuperarProfesores(filtroNombre, filtroClase, 0);
        }

        public Profesor RecuperarProfesorPorID(int idProfesor)
        {
            return oDaoProfesor.RecuperarProfesorPorID(idProfesor);
        }
       
        public int GuardarProfesor(Profesor profesor)
        {
            
            return oDaoProfesor.InsertarProfesor(profesor);
        }
        public List<Clase> TraerClasesPorProfesor(int idProfesor)
        {
            return oDaoProfesor.TraerClasesPorProfesor(idProfesor);
        }

        public List<Socio> TraerSociosPorClase(int idClase, int idProfesor)
        {
            return oDaoProfesor.TraerSociosPorClase(idClase, idProfesor);
        }
        public int ElimianarProfesor(int id_profesor)
        {
            return oDaoProfesor.EliminarProfesor(id_profesor);
        }
        
        public int ActualizarProfesor(int IdProfesor, Profesor profesor)
        {
            return oDaoProfesor.EditarProfesor(IdProfesor, profesor);
        }

        public DataTable RecuperarProfesor(int IdProfesor)
        {
            return oDaoProfesor.RecuperarProfesorPorId(IdProfesor);
        }
    }
}
