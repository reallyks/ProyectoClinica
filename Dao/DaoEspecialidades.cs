using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoEspecialidades
    {
        AccesoDatos ad = new AccesoDatos();
        public SqlDataReader obtenerEspecialidades()
        {
            SqlCommand cmd = new SqlCommand("Select IdEspecialidad_ES,Nombre_ES from Especialidades", ad.Conectar());
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        public SqlDataReader buscarEspecialidades(string sv)
        {
            SqlCommand cmd = new SqlCommand("Select IdEspecialidad_ES,Nombre_ES from Especialidades where IdEspecialidad_ES = @sv", ad.Conectar());
            cmd.Parameters.AddWithValue("@sv", sv);
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
    }
}
