using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Dao
{
    public class DaoUsuarios
    {
        AccesoDatos ad = new AccesoDatos();

        public string ObtenerNombre(int IdUsuario)
        {
            string consulta = "SELECT CASE WHEN TipoUsuario_US = 'MEDICO' THEN Nombre_ME WHEN TipoUsuario_US = 'ADMIN' THEN Nombre_AD ELSE 'Usuario no encontrado' END AS nombre FROM usuarios u LEFT JOIN Administrador a ON u.IdAdmin_US = IdAdministrador_AD LEFT JOIN Medicos m ON u.IdMedico_US = IdMedico_ME WHERE u.IdUsuario_US = @id";

            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@id", SqlDbType.VarChar, 20);
            cmd.Parameters["@id"].Value = IdUsuario;
            SqlDataReader dr = cmd.ExecuteReader();

            Administrador adm = new Administrador();

            while (dr.Read())
            {
                adm.setNombre(dr["nombre"].ToString());
            }

            string nombre = adm.getNombre();

            return nombre;
        }

        public string ObtenerTipoUsuario(string nombreUsuario)
        {
            string consulta = "select TipoUsuario_US from Usuarios where NombreUsuario_US = @nombreUsuario";

            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 20);
            cmd.Parameters["@nombreUsuario"].Value = nombreUsuario;

            SqlDataReader dr = cmd.ExecuteReader();

            Usuarios usuario = new Usuarios();

            while (dr.Read())
            {
                usuario.SetTipoUsuario(dr["TipoUsuario_US"].ToString());
            }

            string tipo = usuario.GetTipoUsuario();

            return tipo;
        }

        public string ObtenerConsultaSegunTipoUsuario(string tipo)
        {
            string consulta;
            if (tipo.Trim() == "ADMIN")
            {
                consulta = "SELECT IdUsuario_US, IdMedico_US, IdAdmin_US, NombreUsuario_US, Contraseña_US, TipoUsuario_US FROM Usuarios INNER JOIN Administrador ON IdAdministrador_AD = IdAdmin_US WHERE NombreUsuario_US = @Usuario AND Contraseña_US = @Contra";
            }
            else
            {
                consulta = "SELECT IdUsuario_US, IdMedico_US, IdAdmin_US, NombreUsuario_US, Contraseña_US, TipoUsuario_US FROM Usuarios INNER JOIN Medicos ON IdMedico_ME = IdMedico_US WHERE NombreUsuario_US = @Usuario AND Contraseña_US = @Contra";
            }

            return consulta;
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            string consulta = "select NombreUsuario_US from Usuarios where NombreUsuario_US = @Usuario";
            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20);
            cmd.Parameters["@Usuario"].Value = nombreUsuario;
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            //si la datatable tiene una fila entonces encontro un usuario.
            if(dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UsuarioCorrecto(string nombre, string contra)
        {
            if (ExisteUsuario(nombre))
            {
                string consulta = "select NombreUsuario_US, Contraseña_US from Usuarios where NombreUsuario_US = @Usuario AND Contraseña_US = @Contra";
                SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20);
                cmd.Parameters["@Usuario"].Value = nombre;
                cmd.Parameters.Add("@Contra", SqlDbType.VarChar, 20);
                cmd.Parameters["@Contra"].Value = contra;
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Usuarios ObtenerUsuario(Usuarios usuario)
        {
            if(UsuarioCorrecto(usuario.GetNombreUsuario(), usuario.GetContraseña()))
            {

                string tipo = ObtenerTipoUsuario(usuario.GetNombreUsuario());

                SqlCommand cmd = new SqlCommand(ObtenerConsultaSegunTipoUsuario(tipo), ad.Conectar());
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20);
                cmd.Parameters["@Usuario"].Value = usuario.GetNombreUsuario();
                cmd.Parameters.Add("@Contra", SqlDbType.VarChar, 20);
                cmd.Parameters["@Contra"].Value = usuario.GetContraseña();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuario.SetTipoUsuario(reader["TipoUsuario_US"].ToString().Trim());
                    usuario.SetIdUsuario(Convert.ToInt32(reader["IdUsuario_US"]));
                    usuario.SetNombreUsuario(reader["NombreUsuario_US"].ToString());
                    usuario.SetContraseña(reader["Contraseña_US"].ToString());
                    if (usuario.GetTipoUsuario() == "ADMIN")
                    {
                        usuario.SetIdAdmin(Convert.ToInt32(reader["IdAdmin_US"]));
                    }
                    else if (usuario.GetTipoUsuario() == "MEDICO")
                    {
                        usuario.SetIdMedico(Convert.ToInt32(reader["IdMedico_US"]));
                    }
                }
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
