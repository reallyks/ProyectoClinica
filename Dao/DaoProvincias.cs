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
    public class DaoProvincias
    {
        AccesoDatos ad = new AccesoDatos();

        public SqlDataReader obtenerProvincias()
        {
            SqlCommand cmd = new SqlCommand("Select * from Provincias", ad.Conectar());
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
    }
}