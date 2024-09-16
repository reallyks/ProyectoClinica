using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Dao;

namespace Negocio
{
    public class NegocioTurnos
    {
        DaoTurnos dt = new DaoTurnos();
        NegocioMedicos nm = new NegocioMedicos();

        public void ObtenerPorcentajePresenciaMes(List<float> lista, int mes, int anio)
        {
            DataTable tablaPorcentajes = new DataTable();
            tablaPorcentajes = dt.ObtenerPorcentajePresenciaMes(mes, anio);
            foreach (DataRow dr in tablaPorcentajes.Rows)
            {
                if (dr["Porcentaje_Presentes"] != DBNull.Value && dr["Porcentaje_Ausentes"] != DBNull.Value)
                {
                    float porcentajePresentes = Convert.ToSingle(dr["Porcentaje_Presentes"]);
                    float porcentajeAusentes = Convert.ToSingle(dr["Porcentaje_Ausentes"]);
                    lista.Add(porcentajePresentes);
                    lista.Add(porcentajeAusentes);
                }
                else
                {
                    lista.Add(0);
                    lista.Add(0);
                }
            }
        }

        public void ObtenerPorcentajePresenciaAnio(float[,] lista, int anio)
        {
            DataTable tablaPorcentajes = new DataTable();
            tablaPorcentajes = dt.ObtenerPorcentajePresenciaAnio(anio);
            foreach (DataRow dr in tablaPorcentajes.Rows)
            {
                int mes = Convert.ToInt32(dr["Mes"]);
                if (dr["Porcentaje_Presentes"] != DBNull.Value && dr["Porcentaje_Ausentes"] != DBNull.Value)
                {
                    float porcentajePresentes = Convert.ToSingle(dr["Porcentaje_Presentes"]);
                    float porcentajeAusentes = Convert.ToSingle(dr["Porcentaje_Ausentes"]);

                    lista[0, mes - 1] = porcentajePresentes;
                    lista[1, mes - 1] = porcentajeAusentes;
                }
                else
                {
                    lista[0, mes - 1] = 0;
                    lista[1, mes - 1] = 0;
                }
            }
        }

        public bool AgregarTurno(Turnos turno)
        {
            if (dt.AgregarTurno(turno)> 0)
            {
                return true;
            }
            return false;
        }

        public DataTable ObtenerHorarioMedico(int idMedico, string dia)
        {
            DataTable Horarios = nm.ObtenerHorarioMedico(idMedico, dia);
            return Horarios;
        }

        public List<DateTime> GenerarTurnos(int idMedico)
        {
            DataTable diasLaboralesMedico = nm.ObtenerDiasLaboralesMedico(idMedico);
            List<DayOfWeek> Dias = new List<DayOfWeek>();
            List<DateTime> fechas = new List<DateTime>();
            foreach (DataRow fila in diasLaboralesMedico.Rows)
            {
                if (Enum.TryParse(fila["DIAS"].ToString(), out DayOfWeek dia))
                {
                    Dias.Add(dia);
                }
            }

            DateTime fechaActual = DateTime.Today;
            DayOfWeek diaActual = fechaActual.DayOfWeek;

            foreach (DayOfWeek dia in Dias)
            {
                int diasRestantes = ((int)dia - (int)diaActual + 7) % 7;
                DateTime fechaTurno = fechaActual.AddDays(diasRestantes);
                fechas.Add(fechaTurno);

                for (int i = 1; i <= 4; i++) 
                {
                    fechaTurno = fechaTurno.AddDays(7);
                    fechas.Add(fechaTurno);
                }

            }

            fechas.Sort();

            return fechas;
        }

        public void InformarTurno(int idTurno, bool estado, string observacion)
        {
            dt.InformarTurno(idTurno, estado, observacion);
        }

        public DataTable ObtenerTablaTurnosDisponibles(int idMedico)
        {
            List<DateTime> turnos = GenerarTurnos(idMedico);

            DataTable tablaTurnos = new DataTable();
            tablaTurnos.Columns.Add("id");
            tablaTurnos.Columns.Add("nombre");
            tablaTurnos.Columns.Add("dia");
            tablaTurnos.Columns.Add("fecha");

            for (int i = 0; i < turnos.Count; i++)
            {
                DataRow fila = tablaTurnos.NewRow();
                string dia = turnos[i].DayOfWeek.ToString();
                string diaTraducido = traducirDiasIngles(dia);
                fila["id"] = idMedico;
                fila["dia"] = diaTraducido;
                fila["fecha"] = turnos[i].Date.ToString("dd-MM-yyyy");
                fila["nombre"] = nm.ObtenerNombre(idMedico);
                tablaTurnos.Rows.Add(fila);
            }
            return tablaTurnos;
        }

        public string traducirDiasEspanol(string diaSemana)
        {
            switch (diaSemana.Trim())
            {
                case "Lunes":
                    diaSemana = "Monday";
                    return diaSemana;
                case "Martes":
                    diaSemana = "Tuesday";
                    return diaSemana;
                case "Miercoles":
                    diaSemana = "Wednesday";
                    return diaSemana;
                case "Jueves":
                    diaSemana = "Thursday";
                    return diaSemana;
                case "Viernes":
                    diaSemana = "Friday";
                    return diaSemana;
                case "Sabado":
                    diaSemana = "Saturday";
                    return diaSemana;
                case "Domingo":
                    diaSemana = "Sunday";
                    return diaSemana;
                default:
                    diaSemana = "";
                    return diaSemana;
            }
        }

        public string traducirDiasIngles(string diaSemana)
        {
            switch (diaSemana.Trim())
            {
                case "Monday":
                    diaSemana = "Lunes";
                    return diaSemana;
                case "Tuesday":
                    diaSemana = "Martes";
                    return diaSemana;
                case "Wednesday":
                    diaSemana = "Miercoles";
                    return diaSemana;
                case "Thursday":
                    diaSemana = "Jueves";
                    return diaSemana;
                case "Friday":
                    diaSemana = "Viernes";
                    return diaSemana;
                case "Saturday":
                    diaSemana = "Sabado";
                    return diaSemana;
                case "Sunday":
                    diaSemana = "Domingo";
                    return diaSemana;
                default:
                    diaSemana = "";
                    return diaSemana;
            }
        }

        public DataTable ListadoTurnos(string idmedico)
        {
            return dt.ListadoTurnos(idmedico);
        }

        public int cantRegistrosTurnos()
        {
            return dt.cantRegistrosTurnos();
        }

        public void actualizarEstadoPresenteAusente(int idTurno, bool estado)
        {
            dt.actualizarEstadoPresenteAusente(idTurno, estado);
        }

        public DataTable buscarTurnoxPaciente(string busqueda, string idmedico, bool aplicarFiltrosAdicionales)
        {
            return dt.buscarTurnoxPaciente(busqueda, idmedico, aplicarFiltrosAdicionales);
        }
    }
}