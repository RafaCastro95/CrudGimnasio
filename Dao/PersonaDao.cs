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

        // Metodo para insert un Profesor
        public int InsertarProfesor(Profesor profesor)
        {
            int filasAfectadas = 0;

            string consultaSQL = "INSERT INTO Profesores (nombre, apellido, documento, fecha_nacimiento, telefono, email, id_genero, id_documento,  id_barrio) " +
                                 "VALUES (@Nombre, @Apellido, @Documento,  @Fecha_nacimiento,  @Telefono, @Email, @Id_documento,  @Id_genero,  @Id_barrio)";

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Nombre", profesor.Nombre),
                new Parametro("@Apellido", profesor.Apellido),
                new Parametro("@Documento", profesor.Documento),
                new Parametro("@Fecha_nacimiento", profesor.FechaNacimiento),
                new Parametro("@Telefono", profesor.Telefono),
                new Parametro("@Email", profesor.Email),
                new Parametro("@Id_documento", profesor.Tipo.IdTipo),
                new Parametro("@Id_genero", profesor.Genero.IdGenero),
                new Parametro("@Id_barrio", profesor.Barrio.IdBarrio)
            };
            
            filasAfectadas = oBd.ActualizarBD(consultaSQL, parametros);
            
            return filasAfectadas;
        }

        // Metodo para insertar un Socio
        public int InsertarSocio(Socio socio)
        {
            int filasAfectadas = 0;
            string consultaSQL = "INSERT INTO Socios (nombre, apellido, documento, fecha_nacimiento, telefono, email,  id_barrio, id_documento, id_genero, id_contextura, id_sangre) " +
                                 "VALUES (@Nombre, @Apellido, @Documento,  @Fecha_nacimiento,  @Telefono, @Email, @Id_barrio, @Id_documento, @Id_genero, @Id_contextura, @Id_sangre)";
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Nombre", socio.Nombre),
                new Parametro("@Apellido", socio.Apellido),
                new Parametro("@Documento", socio.Documento),
                new Parametro("@Fecha_nacimiento", socio.FechaNacimiento),
                new Parametro("@Telefono", socio.Telefono),
                new Parametro("@Email", socio.Email),
                new Parametro("@Id_barrio", socio.Barrio.IdBarrio),
                new Parametro("@Id_documento", socio.Tipo.IdTipo),
                new Parametro("@Id_genero", socio.Genero.IdGenero),
                new Parametro("@Id_contextura", socio.Contextura.IdContextura),
                new Parametro("@Id_sangre", socio.TipoSangre.IdTipoSangre)
            };
            
            filasAfectadas = oBd.ActualizarBD(consultaSQL, parametros);
            
            return filasAfectadas;
        }

        // Recuperar Socios desde la BD con nombre completo concatenado
        public List<Socio> RecuperarSocios(string filtro, ComboBox combo)
        {
            List<Socio> listaSocios = new List<Socio>();

            string consultaSQL = @"SELECT S.apellido,
                                          S.nombre,
                                          S.documento,
                                          TA.tipo AS NombreCurso,
                                          C.fecha_inicio,
                                          C.fecha_fin,
                                          DC.monto
                                      FROM SOCIOS S
                                      JOIN CONTRATOS C ON C.id_socio = S.id_socio
                                      JOIN DETALLES_CONTRATO DC ON DC.id_contrato = C.id_contrato
                                      JOIN CLASES CL ON CL.id_clase = C.id_clase
                                      JOIN TIPOS_ACTIVIDADES TA ON TA.id_actividad = CL.id_actividad";

            bool tieneWhere = false;

            // Filtro por nombre o apellido
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                if (!tieneWhere)
                {
                    consultaSQL += " WHERE ";
                    tieneWhere = true;
                }
                else
                {
                    consultaSQL += " AND ";
                }

                consultaSQL += $"(S.apellido LIKE '%{filtro}%' OR S.nombre LIKE '%{filtro}%')";
            }

            // Filtro por curso (ComboBox)
            if (combo.SelectedIndex != -1 && combo.SelectedValue != null)
            {
                if (!tieneWhere)
                {
                    consultaSQL += " WHERE ";
                    tieneWhere = true;
                }
                else
                {
                    consultaSQL += " AND ";
                }

                consultaSQL += $"TA.id_actividad = {combo.SelectedValue}";
            }


            DataTable tabla = oBd.ConsultarBD(consultaSQL);

            foreach (DataRow fila in tabla.Rows)
            {
                Socio oSocio = new Socio();
                oSocio.Apellido = fila[0].ToString();
                oSocio.Nombre = fila[1].ToString(); // Asignar el nombre
                oSocio.Documento = fila[2].ToString();
                oSocio.Curso = new Curso();
                oSocio.Curso.Nombre = fila[3].ToString();
                oSocio.FechaInicio = DateTime.Parse(fila[4].ToString());
                oSocio.FechaFin = DateTime.Parse(fila[5].ToString());
                oSocio.Monto = decimal.Parse(fila[6].ToString());
                listaSocios.Add(oSocio);
            }

            return listaSocios;
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
