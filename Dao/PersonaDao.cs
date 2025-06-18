using Grupo06_TP_Programacion1.Datos;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Grupo06_TP_Programacion1.Dao
{
    public class PersonaDao
    {
        AccesoDatos oBd;

        public PersonaDao()
        {
            oBd = new AccesoDatos();
        }

        //Metodo para cargar comboBox TipoDocumento
        public List<TipoDocumento> RecuperarTiposDocumentos()
        {
            List<TipoDocumento> listaTipos = new List<TipoDocumento>();

            DataTable tabla = oBd.ConsultarTabla("Tipos_Documento");

            foreach (DataRow fila in tabla.Rows)
            {
                TipoDocumento tipo = new TipoDocumento();
                tipo.IdTipo = (int)fila[0];
                tipo.Descripcion = fila[1].ToString();
                listaTipos.Add(tipo);
            }
            return listaTipos;
        }

        //Metodo para cargar comboBox Genero
        public List<Genero> RecuperarGeneros()
        {
            List<Genero> listaGeneros = new List<Genero>();
            DataTable tabla = oBd.ConsultarTabla("Generos");
            foreach (DataRow fila in tabla.Rows)
            {
                Genero genero = new Genero();
                genero.IdGenero = (int)fila[0];
                genero.Descripcion = fila[1].ToString();
                listaGeneros.Add(genero);
            }
            return listaGeneros;
        }

        public List<Profesor> RecuperarProfesores(string filtroNombre, int filtroClase, int idProfesor)
        {
            List<Profesor> listaProfesores = new List<Profesor>();
            string query = "SELECT P.id_profesor, nombre, apellido, documento, fecha_nacimiento, telefono, email, P.id_genero, G.genero, P.id_documento, TD.tipo, P.id_barrio, B.barrio" +
                " FROM PROFESORES P" + 
                " JOIN GENEROS G ON P.id_genero = G.id_genero" +
                " JOIN TIPOS_DOCUMENTO TD ON P.id_documento = TD.id_documento" +
                " JOIN BARRIOS B ON P.id_barrio = B.id_barrio" +
                " JOIN CLASES C ON P.id_profesor = C.id_profesor" +
                " JOIN TIPOS_ACTIVIDADES TA ON C.id_actividad = TA.id_actividad";

            string where = "";
            if(!string.IsNullOrEmpty(filtroNombre))
            {
                where += $" WHERE P.nombre LIKE '%{filtroNombre}%' OR P.apellido LIKE '%{filtroNombre}%'";
            }

            if(filtroClase > 0)
            {
                if (string.IsNullOrEmpty(where)) { where += " WHERE";} else { where += " AND"; } 
                where += $" TA.id_actividad = {filtroClase}";
            }

            if (idProfesor > 0)
            {
                if (string.IsNullOrEmpty(where)) { where += " WHERE"; } else { where += " AND"; }
                where += $" P.id_profesor = {idProfesor}";
            }

            DataTable tabla = oBd.ConsultarBD(query + where);
            foreach (DataRow fila in tabla.Rows)
            {
                Profesor profesor = new Profesor();
                profesor.IdProfesor = (int)fila["id_profesor"];
                profesor.Nombre = fila["nombre"].ToString();
                profesor.Apellido = fila["apellido"].ToString();
                profesor.Documento = fila["documento"].ToString();
                profesor.FechaNacimiento = (DateTime)fila["fecha_nacimiento"];
                profesor.Telefono = fila["telefono"].ToString();
                profesor.Email = fila["email"].ToString();
                profesor.Genero = new Genero
                {
                    IdGenero = (int)fila["id_genero"],
                    Descripcion = fila["genero"].ToString()
                };
                profesor.Tipo = new TipoDocumento
                {
                    IdTipo = (int)fila["id_documento"],
                    Descripcion = fila["tipo"].ToString()
                };
                profesor.Barrio = new Barrio
                {
                    IdBarrio = (int)fila["id_barrio"],
                    Descripcion = fila["barrio"].ToString()
                };

                listaProfesores.Add(profesor);
            }
            return listaProfesores;
        }

        public Profesor RecuperarProfesorPorID(int idProfesor)
        {
            List<Profesor> profesores = RecuperarProfesores("", 0, idProfesor);
            if (profesores.Count == 0) { throw new ArgumentException("No se encontró el profesor con el ID especificado."); }
            return profesores[0];
        }
    }
}
