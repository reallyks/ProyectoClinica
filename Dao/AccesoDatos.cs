using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    class AccesoDatos
    {
        private string Ruta = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=BDClinica; Integrated Security=True";

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection(Ruta);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public int EjecutarConsulta(string consultaSql)
        {
            SqlCommand cmd = new SqlCommand(consultaSql, Conectar());
            int filas = cmd.ExecuteNonQuery();
            return filas;
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand cmd, string NombreSP)
        {
            int filasCambiadas;
            SqlCommand comando = new SqlCommand();
            comando = cmd;
            comando.Connection = Conectar();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = NombreSP;
            filasCambiadas = comando.ExecuteNonQuery();
            return filasCambiadas;
        }

        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, Conectar());
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(string nombreTabla, string consultaSql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = ObtenerAdaptador(consultaSql);
            adp.Fill(ds, nombreTabla);
            return ds.Tables[nombreTabla];
        }
        public object cantFilasQueBusco(string consultaSql)
        {
            SqlCommand cmd = new SqlCommand(consultaSql, Conectar());
            object filas = cmd.ExecuteScalar();
            return filas;
        }
    }
}
