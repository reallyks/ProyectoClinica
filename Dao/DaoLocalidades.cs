using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoLocalidades
    {
        AccesoDatos ad = new AccesoDatos();

        public SqlDataReader obtenerLocalidades(string sv)
        {

            SqlCommand cmd = new SqlCommand("Select IdProvincia_LO,Nombre_LO from Localidades where IdProvincia_LO = @sv", ad.Conectar());
            cmd.Parameters.AddWithValue("@sv", sv);
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }

    }
}
