using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoTurnos
    {
        AccesoDatos ad = new AccesoDatos();

        public int AgregarTurno(Turnos turno)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdMedico", turno.getIdMedico());
            cmd.Parameters.AddWithValue("@dni", turno.getDniPac());
            cmd.Parameters.AddWithValue("@FechaTurno", turno.getFechaTurno());
            cmd.Parameters.AddWithValue("@horarioTurno", turno.getHorario());

            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_AgregarTurnos");
            return filas;
        }

        public void InformarTurno(int idTurno, bool estado, string observacion)
        {
            string consulta = "UPDATE turnos SET Asistencia_TU = '" + estado + "', Observacion_TU = '" + observacion + "' WHERE idTurno_TU = " + idTurno;
            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            ad.EjecutarConsulta(consulta);
        }

        public DataTable ListadoTurnos(string idmedico)
        {
            string consulta = " SELECT t.idturno_tu AS idturno, t.dnipac_tu AS dnidelpaciente, p.nombre_pa AS nombre, p.apellido_pa AS apellido , t.Asistencia_TU AS asistencia FROM turnos t INNER JOIN pacientes p ON t.dnipac_tu = p.dni_pa WHERE t.IdMedico_TU = '" + idmedico + "' AND t.Asistencia_TU IS NULL ";
            return ad.ObtenerTabla("medicos", consulta);
        }

        public void actualizarEstadoPresenteAusente(int idTurno, bool estado)
        {
            string consulta = " UPDATE turnos SET Asistencia_TU = '" + estado + "' WHERE idTurno_TU  = " + idTurno;
            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            ad.EjecutarConsulta(consulta);
        }


        public int cantRegistrosTurnos()
        {
            int cantRegistros = 0;
            string consulta = " SELECT COUNT(*) FROM Turnos";
            object resultado = ad.cantFilasQueBusco(consulta);


            if (resultado != null && int.TryParse(resultado.ToString(), out cantRegistros))
            {
                return cantRegistros;
            }
            else
            {
                return 0;
            }
        }

        public DataTable buscarTurnoxPaciente(string busqueda, string idmedico, bool aplicarFiltrosAdicionales)
        {

            if (aplicarFiltrosAdicionales)
            {
                string consulta = "SELECT t.idturno_tu AS idturno, t.dnipac_tu AS dnidelpaciente, p.nombre_pa AS nombre, p.apellido_pa AS apellido , t.Asistencia_TU AS asistencia FROM turnos t INNER JOIN pacientes p ON t.dnipac_tu = p.dni_pa WHERE t.IdMedico_TU = '" + idmedico + "' AND t.Asistencia_TU IS NULL AND p.Apellido_PA LIKE '%" + busqueda + "%' AND Fecha_TU <= DATEADD(hour, 1, GETDATE())";
                return ad.ObtenerTabla("turnos", consulta);
            }
            else
            {
                string consulta = "SELECT t.idturno_tu AS idturno, t.dnipac_tu AS dnidelpaciente, p.nombre_pa AS nombre, p.apellido_pa AS apellido , t.Asistencia_TU AS asistencia  FROM turnos t INNER JOIN pacientes p ON t.dnipac_tu = p.dni_pa  WHERE t.IdMedico_TU = '" + idmedico + "' AND t.Asistencia_TU IS NULL AND p.Apellido_PA LIKE '%" + busqueda + "%'";
                return ad.ObtenerTabla("turnos", consulta);
            }
        }
        public DataTable ObtenerPorcentajePresenciaMes(int mes, int anio)
        {
            int mesAux = mes + 1;
            int anioAux = anio;
            if (mes == 12)
            {
                mesAux = 1;
                anioAux = anio + 1;
            }

            string consulta = " SELECT COALESCE(SUM(CASE WHEN Asistencia_TU = 1 THEN 1 ELSE 0 END), 0) AS Presentes, COALESCE(SUM(CASE WHEN Asistencia_TU = 0 THEN 1 ELSE 0 END), 0) AS Ausentes, COALESCE(CAST(ROUND((SUM(CASE WHEN Asistencia_TU = 1 THEN 1 ELSE 0 END) * 100.0) / NULLIF(COUNT(Asistencia_TU), 0), 2) AS DECIMAL(10, 2)), 0) AS Porcentaje_Presentes, COALESCE(CAST(ROUND((SUM(CASE WHEN Asistencia_TU = 0 THEN 1 ELSE 0 END) * 100.0) / NULLIF(COUNT(Asistencia_TU), 0), 2) AS DECIMAL(10, 2)), 0) AS Porcentaje_Ausentes FROM Turnos WHERE Fecha_TU >= '" + anio + "- " + mes.ToString() + "-01' AND Fecha_TU < '" + anioAux + "-" + mesAux.ToString() + "-01'";

            DataTable dt = ad.ObtenerTabla("Porcentajes", consulta);
            return dt;
        }

        public DataTable ObtenerPorcentajePresenciaAnio(int anio)
        {
            string consulta = " SELECT MONTH(Fecha_TU) AS Mes, COALESCE(SUM(CASE WHEN Asistencia_TU = 1 THEN 1 ELSE 0 END), 0) AS Presentes, COALESCE(SUM(CASE WHEN Asistencia_TU = 0 THEN 1 ELSE 0 END), 0) AS Ausentes, CAST(ROUND((SUM(CASE WHEN Asistencia_TU = 1 THEN 1 ELSE 0 END) * 100.0) / NULLIF(COALESCE(COUNT(Asistencia_TU), 0), 0), 2) AS DECIMAL(10, 2)) AS Porcentaje_Presentes, CAST(ROUND((SUM(CASE WHEN Asistencia_TU = 0 THEN 1 ELSE 0 END) * 100.0) / NULLIF(COALESCE(COUNT(Asistencia_TU), 0), 0), 2) AS DECIMAL(10, 2)) AS Porcentaje_Ausentes FROM Turnos WHERE Fecha_TU >= '" + anio.ToString() + "-01-01' AND Fecha_TU< '" + (anio + 1).ToString() + "-01-01' GROUP BY MONTH(Fecha_TU) ORDER BY MONTH(Fecha_TU);";

            DataTable dt = ad.ObtenerTabla("Porcentajes", consulta);
            return dt;
        }
    }
}
