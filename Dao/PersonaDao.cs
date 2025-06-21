using Grupo06_TP_Programacion1.Datos;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        // Metodo para cargar comboBox Provincia
        public List<Provincia> RecuperarProvincias()
        {
            List<Provincia> listaProvincias = new List<Provincia>();
            DataTable tabla = oBd.ConsultarTabla("Provincias");
            foreach (DataRow fila in tabla.Rows)
            {
                Provincia provincia = new Provincia();
                provincia.IdProvincia = (int)fila[0];
                provincia.Descripcion = fila[1].ToString();
                listaProvincias.Add(provincia);
            }
            return listaProvincias;
        }


        // Metodo para cargar comboBox Localidad
        public List<Localidad> RecuperarLocalidades(int idProvincia)
        {
            List<Localidad> listaLocalidades = new List<Localidad>();
            string consultaSQL = "SELECT * FROM Localidades WHERE id_provincia = " + idProvincia;
            DataTable tabla = oBd.ConsultarBD(consultaSQL);
            foreach (DataRow fila in tabla.Rows)
            {
                Localidad localidad = new Localidad();
                localidad.IdLocalidad = (int)fila[0];
                localidad.Descripcion = fila[1].ToString();
                listaLocalidades.Add(localidad);
            }
            return listaLocalidades;
        }

        // Metodo para cargar ComboBox Barrio
        public List<Barrio> RecuperarBarrios(int idLocalidad)
        {
            List<Barrio> listaBarrios = new List<Barrio>();
            string consultaSQL = "SELECT * FROM Barrios WHERE id_localidad = " + idLocalidad;
            DataTable tabla = oBd.ConsultarBD(consultaSQL);
            foreach (DataRow fila in tabla.Rows)
            {
                Barrio barrio = new Barrio();
                barrio.IdBarrio = (int)fila[0];
                barrio.Descripcion = fila[1].ToString();
                listaBarrios.Add(barrio);
            }
            return listaBarrios;
        }

        //Metodo para cargar ComboBox Contextura
        public List<Contextura> RecuperarContexturas()
        {
            List<Contextura> listaContexturas = new List<Contextura>();
            DataTable tabla = oBd.ConsultarTabla("Tipos_Contextura");
            foreach (DataRow fila in tabla.Rows)
            {
                Contextura contextura = new Contextura();
                contextura.IdContextura = (int)fila[0];
                contextura.Descripcion = fila[1].ToString();
                listaContexturas.Add(contextura);
            }
            return listaContexturas;
        }

        // Metodo para cargar ComboBox TipoSangre
        public List<TipoSangre> RecuperarTiposSangre()
        {
            List<TipoSangre> listaTiposSangre = new List<TipoSangre>();
            DataTable tabla = oBd.ConsultarTabla("Tipos_Sangre");
            foreach (DataRow fila in tabla.Rows)
            {
                TipoSangre tipoSangre = new TipoSangre();
                tipoSangre.IdTipoSangre = (int)fila[0];
                tipoSangre.Descripcion = fila[1].ToString();
                listaTiposSangre.Add(tipoSangre);
            }
            return listaTiposSangre;
        }

        // Metodo para cargar ComboBox Cursos
        public List<Curso> RecuperarCursos()
        {
            List<Curso> listaCursos = new List<Curso>();
            String consultaSQL = "SELECT id_actividad, tipo FROM Tipos_Actividades ORDER BY 2 ASC";
            DataTable tabla = oBd.ConsultarBD(consultaSQL);
            foreach (DataRow fila in tabla.Rows)
            {
                Curso curso = new Curso();
                curso.IdCurso = (int)fila[0];
                curso.Nombre = fila[1].ToString();
                listaCursos.Add(curso);
            }
            return listaCursos;
        }
    }
}
