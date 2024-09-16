using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoDiasXHorasXMedicos
    {
        AccesoDatos ad = new AccesoDatos();
        public int AgregarHorario(DiasXHorasXMedicos horario)
        {
            int filas = 0;
            int IdHora = horario.getIdHora();
            for(int i=0; i <= 8; i++)
            {
                if (i != 0) {
                    IdHora++;
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@IdMedico", horario.getIdMedico());
                cmd.Parameters.AddWithValue("@IdDia", horario.getIdDia());
                cmd.Parameters.AddWithValue("@IdHora", IdHora);
                filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_AgregarHorario") + filas;
            }
            return filas;
        }
    }
}
