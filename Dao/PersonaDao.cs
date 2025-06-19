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

        public List<Profesor> RecuperarProfesores(string filtroNombre, int filtroClase, int idProfesor)
        {
            List<Profesor> listaProfesores = new List<Profesor>();
            string query = "SELECT P.id_profesor, nombre, apellido, documento, fecha_nacimiento, telefono, email, P.id_genero, G.genero, P.id_documento, TD.tipo, P.id_barrio, B.barrio" +
                " FROM PROFESORES P" +
                " JOIN GENEROS G ON P.id_genero = G.id_genero" +
                " JOIN TIPOS_DOCUMENTO TD ON P.id_documento = TD.id_documento" +
                " JOIN BARRIOS B ON P.id_barrio = B.id_barrio";

            string where = "";
            if (!string.IsNullOrEmpty(filtroNombre))
            {
                where += $" WHERE (P.nombre LIKE '%{filtroNombre}%' OR P.apellido LIKE '%{filtroNombre}%')";
            }

            if (filtroClase > 0)
            {
                if (string.IsNullOrEmpty(where)) { where += " WHERE"; } else { where += " AND"; }
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

        //Insertar Socio
        public int InsertarSocio(Socio socio)
        {
            int filasAfectadas = 0;
            string consultaSQL = "INSERT INTO Socios (nombre, apellido, documento, fecha_nacimiento, telefono, email, id_barrio, id_documento, id_genero, id_contextura, id_sangre) " +
                                 "VALUES (@Nombre, @Apellido, @Documento, @Fecha_nacimiento, @Telefono, @Email,@Id_barrio , @Id_documento, @Id_genero , @Id_contextura, @Id_sangre)";
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
        public List<Socio> RecuperarSocios(string filtro, int valor)
        {
            List<Socio> listaSocios = new List<Socio>();

            string consultaSQL = @"SELECT DISTINCT S.documento,
                                          S.apellido,
                                          S.nombre,
                                          S.id_socio,
                                          S.fecha_nacimiento,
                                          B.barrio AS barrio,        
                                          TA.tipo AS NombreCurso
                                   FROM SOCIOS S
                                   LEFT JOIN CONTRATOS C ON C.id_socio = S.id_socio
                                   LEFT JOIN BARRIOS B ON S.id_barrio = B.id_barrio
                                   LEFT JOIN DETALLES_CONTRATO DC ON DC.id_contrato = C.id_contrato
                                   LEFT JOIN CLASES CL ON C.id_clase = CL.id_clase
                                   LEFT JOIN TIPOS_ACTIVIDADES TA ON TA.id_actividad = CL.id_actividad
                                   WHERE S.Activo = 1";

            // Filtro por nombre o apellido
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                consultaSQL += $" AND (S.apellido LIKE '%{filtro}%' OR S.nombre LIKE '%{filtro}%')";
            }

            // Filtro por curso (ComboBox)
            if (valor != 0)
            {
                consultaSQL += $" AND TA.id_actividad = {valor}";
            }

            DataTable tabla = oBd.ConsultarBD(consultaSQL);

            foreach (DataRow fila in tabla.Rows)
            {
                Socio oSocio = new Socio();
                oSocio.IdSocio = (int)fila["id_socio"];
                oSocio.Apellido = fila["apellido"].ToString();
                oSocio.Nombre = fila["nombre"].ToString();
                oSocio.Documento = fila["documento"].ToString();
                oSocio.FechaNacimiento = (DateTime)fila["fecha_nacimiento"];
                oSocio.Barrio = new Barrio();
                oSocio.Barrio.Descripcion = fila["barrio"].ToString();
                listaSocios.Add(oSocio);
            }

            return listaSocios;
        }

        public List<Clase> TraerClasesPorProfesor(int idProfesor)
        {
            List<Clase> listaClases = new List<Clase>();
            string query = @"SELECT C.id_clase, C.precio, C.id_actividad, TA.tipo, C.id_profesor, P.nombre, P.apellido, H.id_horario, H.frecuencia_semanal, H.hora_inicio, H.hora_fin
                            FROM CLASES C
                            JOIN TIPOS_ACTIVIDADES TA ON C.id_actividad = TA.id_actividad
                            JOIN HORARIOS H ON C.id_clase = H.id_clase
                            JOIN PROFESORES P ON C.id_profesor = P.id_profesor
                            WHERE C.id_profesor = " + idProfesor;

            DataTable tabla = oBd.ConsultarBD(query);
            foreach (DataRow row in tabla.Rows)
            {
                Clase clase = new Clase
                {
                    IdClase = (int)row["id_clase"],
                    Precio = (decimal)row["precio"],
                    Curso = new Curso
                    {
                        IdCurso = (int)row["id_actividad"],
                        Nombre = row["tipo"].ToString()
                    },
                    Profesor = new Profesor
                    {
                        IdProfesor = (int)row["id_profesor"],
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString()
                    },
                    Horario = new Horario
                    {
                        IdHorario = (int)row["id_horario"],
                        FrecueciaSemanal = (int)row["frecuencia_semanal"],
                        HoraInicio = TimeSpan.Parse(row["hora_inicio"].ToString()),
                        HoraFin = TimeSpan.Parse(row["hora_fin"].ToString())
                    }
                };
                listaClases.Add(clase);
            }
            return listaClases;
        }

        public List<Socio> TraerSociosPorClase(int idClase, int idProfesor)
        {
            List<Socio> listaSocios = new List<Socio>();
            string query = $@"SELECT S.id_socio,
                                    S.apellido,
                                    S.nombre
                            FROM SOCIOS S
                            JOIN CONTRATOS C ON S.id_socio = C.id_socio
                            JOIN CLASES CL ON C.id_clase = CL.id_clase
                            JOIN PROFESORES P ON CL.id_profesor = P.id_profesor
                            WHERE CL.id_profesor = {idProfesor} AND C.id_clase = {idClase}";

            DataTable tabla = oBd.ConsultarBD(query);

            foreach (DataRow row in tabla.Rows)
            {
                Socio socio = new Socio
                {
                    IdSocio = (int)row["id_socio"],
                    Apellido = row["apellido"].ToString(),
                    Nombre = row["nombre"].ToString()
                };
                listaSocios.Add(socio);
            }

            return listaSocios;
        }

        public int EliminarProfesor(int id_profesor)
        {
            // Soft delete: marcar el profesor como inactivo
            string query = $"UPDATE Profesores SET Activo = 0 WHERE id_profesor = {id_profesor}";
            return oBd.ActualizarBD(query);
        }

        public int EliminarSocio(int id_socio)
        {
            // Soft delete: marcar el socio como inactivo
            string query = $"UPDATE Socios SET Activo = 0 WHERE id_socio = {id_socio}";
            return oBd.ActualizarBD(query);
        }

        // METODO EDITAR PROFESOR 
        public int EditarProfesor(int IdProfesor, Profesor profesor)
        {
            int filasAfectadas = 0;
            string consultaSQL = "UPDATE Profesores SET nombre = @Nombre, apellido = @Apellido, fecha_nacimiento = @Fecha_nacimiento, " +
                                 "telefono = @Telefono, email = @Email, id_genero = @Id_genero, id_documento = @Id_documento, id_barrio = @Id_barrio " +
                                 "WHERE id_profesor = @IdProfesor";

            List<Parametro> parametros = new List<Parametro>
    {
        new Parametro("@IdProfesor", profesor.IdProfesor),
        new Parametro("@Nombre", profesor.Nombre),
        new Parametro("@Apellido", profesor.Apellido),
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

        //METODO RECUPERAR PROFESOR POR ID
        public DataTable RecuperarProfesorPorId(int IdProfesor)
        {
            string consulta = $"SELECT p.*, pv.id_provincia, l.id_localidad " +
                $" FROM Profesores p " +
                $" JOIN BARRIOS b ON b.id_barrio = p.id_barrio " +
                $" JOIN LOCALIDADES l ON l.id_localidad = b.id_localidad " +
                $" JOIN PROVINCIAS  pv ON pv.id_provincia = l.id_provincia " +
                $" WHERE id_profesor = {IdProfesor}";
            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }

        //Metodo para recuperar Socio por Documento
        public DataTable RecuperarSocioPorDocumento(string Documento)
        {
            string consulta = $"SELECT S.*, L.id_localidad, P.id_provincia " +
                              $"FROM SOCIOS S " +
                              $"JOIN BARRIOS B ON S.id_barrio = B.id_barrio " +
                              $"JOIN LOCALIDADES L ON B.id_localidad = L.id_localidad " +
                              $"JOIN PROVINCIAS P ON L.id_provincia = P.id_provincia " +
                              $"WHERE S.documento = '{Documento}'";
            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }


        // Metodo para editar Socio
        public int EditarSocio(int idSocio, Socio socio)
        {
            int filasAfectadas = 0;
            string consultaSQL = "UPDATE Socios SET nombre = @Nombre, apellido = @Apellido, documento = @Documento, fecha_nacimiento = @Fecha_nacimiento, " +
                                 "telefono = @Telefono, email = @Email, id_barrio = @Id_barrio, id_documento = @Id_documento, id_genero = @Id_genero, " +
                                 "id_contextura = @Id_contextura, id_sangre = @Id_sangre WHERE id_socio = @IdSocio";
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@IdSocio", idSocio),
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

        


        // Formulario Consultas
        // 
        //PRIMERA CONSULTA
        public DataTable Consulta1()
        {
            string consulta = @"SELECT 
                                    S.apellido + SPACE(2) + S.nombre AS 'SOCIOS', 
                                    CONVERT(VARCHAR, C.fecha_emision, 103) AS 'FECHA EMISIÓN CREDENCIAL', 
                                    P.provincia AS 'PROVINCIA', 
                                    CONVERT(VARCHAR, CO.fecha_fin, 103) AS 'FECHA VENCIMIENTO CONTRATO', 
                                    TA.tipo AS  'Tipo', 
                                    PR.apellido + SPACE(2) + PR.nombre AS 'PROFESORES' 
                                FROM SOCIOS S 
                                JOIN CREDENCIALES C ON C.id_socio = S.id_socio 
                                JOIN CONTRATOS CO ON CO.id_socio = S.id_socio 
                                JOIN BARRIOS B ON B.id_barrio = S.id_barrio 
                                JOIN LOCALIDADES L ON L.id_localidad = B.id_localidad 
                                JOIN PROVINCIAS P ON P.id_provincia = L.id_provincia 
                                JOIN CLASES CL ON CL.id_clase = CO.id_clase 
                                JOIN PROFESORES PR ON PR.id_profesor = CL.id_profesor 
                                JOIN TIPOS_ACTIVIDADES TA ON TA.id_actividad = CL.id_actividad 
                                WHERE   YEAR(C.fecha_emision) BETWEEN 2023 AND 2025 
                                    AND (TA.tipo = 'Musculacion' OR TA.tipo = 'Spinning') 
                                    AND (P.provincia = 'Córdoba' OR P.provincia = 'Mendoza') 
                                ORDER BY [FECHA EMISIÓN CREDENCIAL]  ASC, SOCIOS ASC, PROFESORES ASC";
            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }


        //SEGUNDA CONSULTA
        public DataTable Consulta2()
        {
            string consulta = @"SELECT
                                       PR.provincia AS Provincia, 
                                       COUNT(DISTINCT S.id_socio) AS Cantidad_Socios, 
                                       FORMAT(SUM(DC.monto), 'C', 'es-AR') AS Total_Recaudado 
                               FROM DETALLES_CONTRATO DC 
                               JOIN CONTRATOS C ON C.id_contrato = DC.id_contrato 
                               JOIN SOCIOS S ON S.id_socio = C.id_socio 
                               JOIN BARRIOS B ON B.id_barrio = S.id_barrio 
                               JOIN LOCALIDADES L ON L.id_localidad = B.id_localidad 
                               JOIN PROVINCIAS PR ON PR.id_provincia = L.id_provincia 
                               GROUP BY PR.provincia 
                               ORDER BY SUM(DC.monto) DESC;";

            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }


        //TERCERA CONSULTA
        public DataTable Consulta3()
        {
            string consulta = @"SELECT
                                      s.nombre + ' ' + s.apellido AS NombreCompleto,
                                      ctx.contextura AS Contextura,
                                      ts.tipo AS TipoSangre,
                                      p.provincia AS Provincia,
                                      convert(VARCHAR, c.fecha_vencimiento, 103) AS FechaVencimiento,
                                      FORMAT(cl.precio, 'C', 'es-AR') AS PrecioClase,
                                      ta.tipo AS TipoActividad,
                                      pr.nombre + ' ' + pr.apellido AS Profesor
                                FROM SOCIOS s
                                JOIN TIPOS_CONTEXTURA ctx ON s.id_contextura = ctx.id_contextura
                                JOIN TIPOS_SANGRE ts ON s.id_sangre = ts.id_sangre
                                JOIN BARRIOS b ON s.id_barrio = b.id_barrio
                                JOIN LOCALIDADES l ON b.id_localidad = l.id_localidad
                                JOIN PROVINCIAS p ON l.id_provincia = p.id_provincia
                                JOIN CREDENCIALES c ON s.id_socio = c.id_socio
                                JOIN CONTRATOS ct ON s.id_socio = ct.id_socio
                                JOIN CLASES cl ON ct.id_clase = cl.id_clase
                                JOIN TIPOS_ACTIVIDADES ta ON cl.id_actividad = ta.id_actividad
                                JOIN PROFESORES pr ON cl.id_profesor = pr.id_profesor
                                WHERE
                                p.provincia = 'Córdoba'
                                AND YEAR(c.fecha_vencimiento) > YEAR(GETDATE())
                                AND ts.tipo IN ('A+', 'B+','B-')
                                AND ctx.contextura IN ('Ectomorfo', 'Endomorfo')
                                AND (ta.tipo IN ('Funcional', 'Zumba', 'Musculacion', 'Crossfit')
                                OR cl.precio < 10000)
                                AND pr.nombre NOT LIKE 'Juan'
                                ORDER BY NombreCompleto ASC";
            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }

        //CUARTA CONSULTA
        public DataTable Consulta4()
        {
            string consulta = @"SELECT
                                    S.nombre + ' ' + S.apellido as 'SOCIO', 
                                    CONVERT(VARCHAR, C.fecha_inicio, 103) as 'FECHA INSCRIPCCION', 
                                    P.provincia as 'PROVINCIA', TA.tipo as 'ACTIVIDAD'
                                FROM SOCIOS S 
                                join CONTRATOS C on C.id_socio = S.id_socio 
                                join CLASES CA on CA.id_clase = C.id_clase 
                                join TIPOS_ACTIVIDADES TA on TA.id_actividad = CA.id_actividad 
                                join BARRIOS B on B.id_barrio = S.id_barrio 
                                join LOCALIDADES L on L.id_localidad = B.id_localidad 
                                join PROVINCIAS P on P.id_provincia = L.id_provincia 
                                where DATEDIFF(YEAR, C.fecha_inicio, GETDATE()) between 1 and 2 
                                    and P.provincia in  ('Córdoba', 'Mendoza', 'Buenos Aires') 
                                    and (TA.tipo = 'zumba' 
                                    or TA.tipo = 'Spinning') 
                                ORDER BY SOCIO";
            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }

        //QUINTA CONSULTA
        public DataTable Consulta5()
        {
            string consulta = @"select distinct s.nombre + space(2)+ s.apellido as 'SOCIO', s.documento as 'DOCUMENTO',
                                ta.tipo as 'ACTIVIDAD', p.mes as 'MES',  cl.precio as 'PRECIO', h.frecuencia_semanal as 
                                'FRECUENCIA SEMANAL' 
                                from SOCIOS as s 
                                join CONTRATOS as c on s.id_socio = c.id_socio 
                                join DETALLES_CONTRATO as dc on c.id_contrato = dc.id_contrato 
                                join PERIODOS as p on dc.id_mes = p.id_mes 
                                join CLASES as cl on c.id_clase = cl.id_clase 
                                join HORARIOS as h on cl.id_clase = h.id_clase 
                                join TIPOS_ACTIVIDADES as ta on cl.id_actividad = ta.id_actividad 
                                where p.mes in('Agosto', 'Septiembre','Noviembre')
                                        and ta.tipo in('Pilates','Musculación') 
                                        and  h.frecuencia_semanal >= 2 
                                order by SOCIO asc";
            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }

        //SEXTA CONSULTA
        public DataTable Consulta6()
        {
            string consulta = @"select
                            S.id_socio 'ID de Socio', 
                            trim(S.nombre) + space(1) + trim(S.apellido) 'Nombre y Apellido', 
                            S.telefono 'Telefono', 
                            O.descripcion 'Operación realizada', 
                            CONVERT(varchar ,DO.fecha, 105) 'Fecha de operación', 
                            DFM.observaciones 'Observaciones', 
                            CONVERT(varchar ,C.fecha_inicio, 105) 'Inicio Contrato', 
                            CONVERT(varchar ,C.fecha_fin, 105) 'Fin Contrato', 
                            CONCAT(DATEDIFF(month, C.fecha_fin, GETDATE()), ' Meses') AS 'Ultimo contrato' 
                            from socios S 
                            join FICHAS_MEDICAS FM on S.id_socio = FM.id_socio 
                            join DETALLES_FICHA_MEDICA DFM on FM.id_ficha_medica = DFM.id_detalle_ficha 
                            join DETALLES_OPERACIONES DO on DFM.id_detalle_ficha = DO.id_detalle_ficha 
                            join OPERACIONES O on DO.id_operacion = O.id_operacion 
                            join CONTRATOS C on S.id_socio = C.id_socio 
                            where
                            (observaciones like '%ehabilitación%' or observaciones like '%ecuperación%') 
                            and observaciones not like '%satisfactoria' 
                            and DATEDIFF(month, C.fecha_fin, getdate()) < 18 
                            order by DATEDIFF(MONTH, C.fecha_fin, GETDATE()) ";
            DataTable dt = oBd.ConsultarBD(consulta);
            return dt;
        }
    }
}
