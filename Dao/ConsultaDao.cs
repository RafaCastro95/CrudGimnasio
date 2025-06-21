using Grupo06_TP_Programacion1.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Grupo06_TP_Programacion1.Dao
{
    public class ConsultaDao
    {
        AccesoDatos oBdC;
        public ConsultaDao()
        {
            oBdC = new AccesoDatos();
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
                                    TA.tipo AS  'CLASE', 
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
            DataTable dt = oBdC.ConsultarBD(consulta);
            return dt;
        }


        //SEGUNDA CONSULTA
        public DataTable Consulta2()
        {
            string consulta = @"SELECT PR.provincia AS PROVINCIAS, 
                                       COUNT(DISTINCT S.id_socio) AS ""CANTIDAD DE SOCIOS"", 
                                       FORMAT(SUM(DC.monto), 'C', 'es-AR') AS ""TOTAL RECAUDADO"" 
                               FROM DETALLES_CONTRATO DC 
                               JOIN CONTRATOS C ON C.id_contrato = DC.id_contrato 
                               JOIN SOCIOS S ON S.id_socio = C.id_socio 
                               JOIN BARRIOS B ON B.id_barrio = S.id_barrio 
                               JOIN LOCALIDADES L ON L.id_localidad = B.id_localidad 
                               JOIN PROVINCIAS PR ON PR.id_provincia = L.id_provincia 
                               GROUP BY PR.provincia 
                               ORDER BY  [TOTAL RECAUDADO] DESC;";

            DataTable dt = oBdC.ConsultarBD(consulta);
            return dt;
        }


        //TERCERA CONSULTA
        public DataTable Consulta3()
        {
            string consulta = @"SELECT
                                      s.nombre + ' ' + s.apellido AS SOCIOS,
                                      ctx.contextura AS CONTEXTURA,
                                      ts.tipo AS 'TIPO DE SANGRE',
                                      p.provincia AS PROVINCIA,
                                      convert(VARCHAR, c.fecha_vencimiento, 103) AS 'VENCIMIENTO CONTRATO',
                                      FORMAT(cl.precio, 'C', 'es-AR') AS 'PRECIO CLASE',
                                      ta.tipo AS CLASE,
                                      pr.nombre + ' ' + pr.apellido AS PROFESOR
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
                                ORDER BY SOCIOS ASC";
            DataTable dt = oBdC.ConsultarBD(consulta);
            return dt;
        }

        //CUARTA CONSULTA
        public DataTable Consulta4()
        {
            string consulta = @"SELECT
                                    S.nombre + ' ' + S.apellido as 'SOCIO', 
                                    CONVERT(VARCHAR, C.fecha_inicio, 103) as 'FECHA INSCRIPCCION', 
                                    P.provincia as 'PROVINCIA', TA.tipo as 'CLASE'
                                FROM SOCIOS S 
                                JOIN CONTRATOS C on C.id_socio = S.id_socio 
                                JOIN CLASES CA on CA.id_clase = C.id_clase 
                                JOIN TIPOS_ACTIVIDADES TA on TA.id_actividad = CA.id_actividad 
                                JOIN BARRIOS B on B.id_barrio = S.id_barrio 
                                JOIN LOCALIDADES L on L.id_localidad = B.id_localidad 
                                JOIN PROVINCIAS P on P.id_provincia = L.id_provincia 
                                where DATEDIFF(YEAR, C.fecha_inicio, GETDATE()) between 1 and 2 
                                    and P.provincia in  ('Córdoba', 'Mendoza', 'Buenos Aires') 
                                    and (TA.tipo = 'zumba' 
                                    or TA.tipo = 'Spinning') 
                                ORDER BY SOCIO";
            DataTable dt = oBdC.ConsultarBD(consulta);
            return dt;
        }

        //QUINTA CONSULTA
        public DataTable Consulta5()
        {
            string consulta = @"SELECT DISTINCT S.nombre + SPACE(2)+ S.apellido AS 'SOCIO', S.documento AS 'DOCUMENTO',
                                TA.tipo AS 'ACTIVIDAD', P.mes AS 'MES',  FORMAT(CL.precio, 'C', 'es-AR') AS 'PRECIO', H.frecuencia_semanal AS 
                                'FRECUENCIA SEMANAL' 
                                FROM SOCIOS AS S 
                                JOIN CONTRATOS AS C ON S.id_socio = C.id_socio 
                                JOIN DETALLES_CONTRATO AS DC ON C.id_contrato = DC.id_contrato 
                                JOIN PERIODOS AS P ON DC.id_mes = P.id_mes 
                                JOIN CLASES AS CL on C.id_clase = CL.id_clase 
                                JOIN HORARIOS AS H ON CL.id_clase = H.id_clase 
                                JOIN TIPOS_ACTIVIDADES AS TA on CL.id_actividad = TA.id_actividad 
                                WHERE P.mes in('Agosto', 'Septiembre','Noviembre')
                                        and TA.tipo in('Pilates','Musculación') 
                                        and  H.frecuencia_semanal >= 2 
                                order by SOCIO asc";
            DataTable dt = oBdC.ConsultarBD(consulta);
            return dt;
        }

        //SEXTA CONSULTA
        public DataTable Consulta6()
        {
            string consulta = @"SELECT trim(S.nombre) + space(1) + trim(S.apellido) 'SOCIOS', 
                                        S.telefono 'Telefono', 
                                        O.descripcion 'Operación realizada', 
                                        CONVERT(varchar ,DO.fecha, 105) 'Fecha de operación', 
                                        DFM.observaciones 'Observaciones', 
                                        CONVERT(varchar ,C.fecha_inicio, 105) 'Inicio Contrato', 
                                        CONVERT(varchar ,C.fecha_fin, 105) 'Fin Contrato', 
                                        CONCAT(DATEDIFF(month, C.fecha_fin, GETDATE()), ' Meses') AS 'Ultimo contrato' 
                                FROM SOCIOS S 
                                JOIN FICHAS_MEDICAS FM on S.id_socio = FM.id_socio 
                                JOIN DETALLES_FICHA_MEDICA DFM on FM.id_ficha_medica = DFM.id_detalle_ficha 
                                JOIN DETALLES_OPERACIONES DO on DFM.id_detalle_ficha = DO.id_detalle_ficha 
                                JOIN OPERACIONES O on DO.id_operacion = O.id_operacion 
                                JOIN CONTRATOS C on S.id_socio = C.id_socio 
                                WHERE (observaciones LIKE '%ehabilitación%' OR observaciones LIKE '%ecuperación%') 
                                AND observaciones NOT LIKE '%satisfactoria' 
                                AND DATEDIFF(month, C.fecha_fin, getdate()) < 18 
                                ORDER BY  DATEDIFF(MONTH, C.fecha_fin, GETDATE()) ";
            DataTable dt = oBdC.ConsultarBD(consulta);
            return dt;
        }
    }
}
