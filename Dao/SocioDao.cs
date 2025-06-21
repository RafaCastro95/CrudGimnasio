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
    public class SocioDao
    {
        AccesoDatos oBdS;
        public SocioDao()
        {
            oBdS = new AccesoDatos();
        }

        //Insertar Socio
        public int InsertarSocio(Socio socio)
        {
            int filasAfectadas = 0;
            string consultaSQL = @"INSERT INTO Socios (nombre, apellido, documento, 
                                   fecha_nacimiento, telefono, email, id_barrio, id_documento, 
                                   id_genero, id_contextura, id_sangre)VALUES (@Nombre, 
                                   @Apellido, @Documento, @Fecha_nacimiento, @Telefono, @Email,@Id_barrio, 
                                   @Id_documento, @Id_genero , @Id_contextura, @Id_sangre)";
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
            filasAfectadas = oBdS.ActualizarBD(consultaSQL, parametros);
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

            DataTable tabla = oBdS.ConsultarBD(consultaSQL);

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
        public int EliminarSocio(int id_socio)
        {
            // Soft delete: marcar el socio como inactivo
            string query = $"UPDATE Socios SET Activo = 0 WHERE id_socio = {id_socio}";
            return oBdS.ActualizarBD(query);
        }



        //Metodo para recuperar Socio por Documento
        public DataTable RecuperarSocioPorDocumento(string Documento)
        {
            string consulta = $@"SELECT S.*, L.id_localidad, P.id_provincia FROM SOCIOS S 
                                JOIN BARRIOS B ON S.id_barrio = B.id_barrio 
                                JOIN LOCALIDADES L ON B.id_localidad = L.id_localidad 
                                JOIN PROVINCIAS P ON L.id_provincia = P.id_provincia 
                                WHERE S.documento = '{Documento}'";
            DataTable dt = oBdS.ConsultarBD(consulta);
            return dt;
        }


        // Metodo para editar Socio
        public int EditarSocio(string documento, Socio socio)
        {
            int filasAfectadas = 0;
            string consultaSQL = @"UPDATE Socios SET idSocio = @IdSocio, nombre = @Nombre, 
                                   apellido = @Apellido, fecha_nacimiento = @Fecha_nacimiento, 
                                   telefono = @Telefono, email = @Email, id_barrio = @Id_barrio, 
                                   id_documento = @Id_documento, id_genero = @Id_genero, 
                                   id_contextura = @Id_contextura, id_sangre = @Id_sangre 
                                   WHERE documento = @Documento";
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Documento", documento),
                new Parametro("@IdSocio", socio.IdSocio),
                new Parametro("@Nombre", socio.Nombre),
                new Parametro("@Apellido", socio.Apellido),
                new Parametro("@Fecha_nacimiento", socio.FechaNacimiento),
                new Parametro("@Telefono", socio.Telefono),
                new Parametro("@Email", socio.Email),
                new Parametro("@Id_barrio", socio.Barrio.IdBarrio),
                new Parametro("@Id_documento", socio.Tipo.IdTipo),
                new Parametro("@Id_genero", socio.Genero.IdGenero),
                new Parametro("@Id_contextura", socio.Contextura.IdContextura),
                new Parametro("@Id_sangre", socio.TipoSangre.IdTipoSangre)
            };
            filasAfectadas = oBdS.ActualizarBD(consultaSQL, parametros);
            return filasAfectadas;
        }
    }
}
