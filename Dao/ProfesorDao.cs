using Grupo06_TP_Programacion1.Datos;
using Grupo06_TP_Programacion1.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Dao
{
    internal class ProfesorDao
    {
        AccesoDatos oBdP;
        public ProfesorDao()
        {
            oBdP = new AccesoDatos();
        }
        internal List<Profesor> RecuperarProfesores(string filtroNombre, int filtroClase, int idProfesor)
        {
            List<Profesor> listaProfesores = new List<Profesor>();
            string query = @"SELECT DISTINCT P.id_profesor, P.nombre, P.apellido, P.documento, P.fecha_nacimiento, 
                             P.telefono, P.email, P.id_genero, P.id_documento, P.id_barrio, B.barrio
                             FROM PROFESORES P
                             LEFT JOIN BARRIOS B ON P.id_barrio = B.id_barrio
                             LEFT JOIN CLASES CL ON CL.id_profesor = P.id_profesor
                             LEFT JOIN TIPOS_ACTIVIDADES TA ON TA.id_actividad = CL.id_actividad
                             WHERE P.ACTIVO = 1";

            if (!string.IsNullOrEmpty(filtroNombre))
            {
                query += $" AND (P.nombre LIKE '%{filtroNombre}%' OR P.apellido LIKE '%{filtroNombre}%')";
            }

            if (filtroClase > 0)
            {
                query += $" AND TA.id_actividad = {filtroClase}";
            }

            if (idProfesor > 0)
            {
                query += $" AND P.id_profesor = {idProfesor}";
            }

            DataTable tabla = oBdP.ConsultarBD(query);
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
                profesor.Genero = new Genero { IdGenero = (int)fila["id_genero"] };
                profesor.Tipo = new TipoDocumento { IdTipo = (int)fila["id_documento"] };
                profesor.Barrio = new Barrio { IdBarrio = (int)fila["id_barrio"], Descripcion = fila["barrio"].ToString() };
                profesor.Activo = 1;
                listaProfesores.Add(profesor);
            }
            return listaProfesores;
        }

        internal Profesor RecuperarProfesorPorID(int idProfesor)
        {
            List<Profesor> profesores = RecuperarProfesores("", 0, idProfesor);
            if (profesores.Count == 0) { throw new ArgumentException("No se encontró el profesor con el ID especificado."); }
            return profesores[0];
        }
        // Metodo para insert un Profesor
        internal int InsertarProfesor(Profesor profesor)
        {
            int filasAfectadas = 0;

            string consultaSQL = @"INSERT INTO Profesores (nombre, apellido, documento, 
                                   fecha_nacimiento, telefono, email, id_genero, id_documento,  
                                   id_barrio)   VALUES (@Nombre, @Apellido, @Documento,  
                                   @Fecha_nacimiento, @Telefono, @Email, @Id_documento,  
                                   @Id_genero,  @Id_barrio)";
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

            filasAfectadas = oBdP.ActualizarBD(consultaSQL, parametros);

            return filasAfectadas;
        }

        internal List<Clase> TraerClasesPorProfesor(int idProfesor)
        {
            List<Clase> listaClases = new List<Clase>();
            string query = $@"SELECT C.id_clase, C.precio, C.id_actividad, TA.tipo, C.id_profesor, 
                              P.nombre, P.apellido, H.id_horario, H.frecuencia_semanal, H.hora_inicio, H.hora_fin
                              FROM CLASES C
                              JOIN TIPOS_ACTIVIDADES TA ON C.id_actividad = TA.id_actividad
                              JOIN HORARIOS H ON C.id_clase = H.id_clase
                              JOIN PROFESORES P ON C.id_profesor = P.id_profesor
                              WHERE C.id_profesor = {idProfesor}";

            DataTable tabla = oBdP.ConsultarBD(query);
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
        // METODO EDITAR PROFESOR 
        internal int EditarProfesor(int IdProfesor, Profesor profesor)
        {
            int filasAfectadas = 0;
            string consultaSQL = $@"UPDATE Profesores SET nombre = @Nombre, apellido = @Apellido, 
                                    fecha_nacimiento = @Fecha_nacimiento, telefono = @Telefono, 
                                    email = @Email, id_genero = @Id_genero, id_documento = @Id_documento, 
                                    id_barrio = @Id_barrio 
                                    WHERE id_profesor = {IdProfesor}";
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

            filasAfectadas = oBdP.ActualizarBD(consultaSQL, parametros);
            return filasAfectadas;
        }

        //METODO RECUPERAR PROFESOR POR ID
        internal DataTable RecuperarProfesorPorId(int IdProfesor)
        {
            string consulta = $@"SELECT p.*, pv.id_provincia, l.id_localidad 
                                 FROM Profesores p 
                                 JOIN BARRIOS b ON b.id_barrio = p.id_barrio 
                                 JOIN LOCALIDADES l ON l.id_localidad = b.id_localidad
                                 JOIN PROVINCIAS  pv ON pv.id_provincia = l.id_provincia 
                                 WHERE id_profesor = {IdProfesor}";
            DataTable dt = oBdP.ConsultarBD(consulta);
            return dt;
        }
        internal List<Socio> TraerSociosPorClase(int idClase, int idProfesor)
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

            DataTable tabla = oBdP.ConsultarBD(query);

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

        internal int EliminarProfesor(int id_profesor)
        {
            int filaAfectadas = 0;
            string query = $"DELETE FROM PROFESORES WHERE id_profesor = {id_profesor}";

            filaAfectadas = oBdP.ActualizarBD(query);

            return filaAfectadas;
        }
    }
}
