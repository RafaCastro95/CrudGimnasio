using Grupo06_TP_Programacion1.Datos;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
