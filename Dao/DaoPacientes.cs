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
    public class DaoPacientes
    {
        AccesoDatos ad = new AccesoDatos();

        public bool Existe(string dni)
        {
            string consulta = "select Dni_PA from Pacientes where Dni_PA = @Dni";
            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@Dni", SqlDbType.VarChar, 20);
            cmd.Parameters["@Dni"].Value = dni;
            SqlDataAdapter dp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            //si la datatable tiene una fila entonces encontro un paciente.
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int AgregarPaciente(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Dni_PA", paciente.getDni());
            cmd.Parameters.AddWithValue("@IdLocalidad_PA", paciente.getIdLocalidad());
            cmd.Parameters.AddWithValue("@Nombre_PA", paciente.getNombre());
            cmd.Parameters.AddWithValue("@Apellido_PA", paciente.getApellido());
            cmd.Parameters.AddWithValue("@Sexo_PA", paciente.getSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad_PA", paciente.getNacionalidad());
            cmd.Parameters.Add("@Direccion_PA", SqlDbType.Char, 25).Value = paciente.getDireccion();
            cmd.Parameters.AddWithValue("@FechaNac_PA", paciente.getFechaNac());
            cmd.Parameters.AddWithValue("@CorreoElectronico_PA", paciente.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@Telefono_PA", paciente.getTelefono());
            cmd.Parameters.AddWithValue("@Estado_PA", paciente.getEstado());
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_AgregarPaciente");
            return filas;
        }

        public int DarDeBajaPaciente(string dni)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DNI", dni);
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_DarDeBajaPaciente");
            return filas;

        }

        public int DarDeAltaPaciente(string dni)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@DNI", dni);
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_DarDeAltaPaciente");
            return filas;
        }

        public DataTable ListadoPacientes()
        {
            string consulta = "SELECT Dni_PA, Nombre_PA, Apellido_PA, Sexo_PA, Nacionalidad_PA, FechaNac_PA, Direccion_PA, CorreoElectronico_PA, Telefono_PA FROM pacientes WHERE Estado_PA='True'";
            return ad.ObtenerTabla("pacientes", consulta);
        }

        public DataTable ListadoPacientesDeBaja()
        {
            string consulta = "SELECT Dni_PA, Nombre_PA, Apellido_PA, Sexo_PA, Nacionalidad_PA, FechaNac_PA, Direccion_PA, CorreoElectronico_PA, Telefono_PA FROM pacientes WHERE Estado_PA='False'";
            return ad.ObtenerTabla("pacientes", consulta);
        }

        public DataTable BuscarPaciente(string busqueda)
        {
            string consulta = "SELECT Dni_PA, Nombre_PA, Apellido_PA, Sexo_PA, Nacionalidad_PA, FechaNac_PA, Direccion_PA, CorreoElectronico_PA, Telefono_PA FROM pacientes WHERE Nombre_PA LIKE '%" + busqueda + "%'";
            return ad.ObtenerTabla("Pacientes", consulta);
        }

        public bool ObtenerEstadoPaciente(string dni)
        {
            string consulta = "SELECT Estado_PA FROM Pacientes where Dni_PA = @dni";

            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20);
            cmd.Parameters["@dni"].Value = dni;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                bool estado = bool.Parse(dr["Estado_PA"].ToString());
                return estado;
            }
            return false;
        }

        public bool ExistePacienteDadoDeBaja(string dni)
        {
            string consulta = "SELECT Estado_PA FROM Pacientes where Dni_PA = @dni";

            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20);
            cmd.Parameters["@dni"].Value = dni;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                bool estado = bool.Parse(dr["Estado_PA"].ToString());

                if (estado == true)
                {
                    return false;
                }
            }
            return true;
        }
        public int ActualizarPaciente(Paciente paciente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Dni_PA", paciente.getDni());
            cmd.Parameters.AddWithValue("@Nombre_PA", paciente.getNombre());
            cmd.Parameters.AddWithValue("@Apellido_PA", paciente.getApellido());
            cmd.Parameters.AddWithValue("@Sexo_PA", paciente.getSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad_PA", paciente.getNacionalidad());
            cmd.Parameters.Add("@Direccion_PA", SqlDbType.Char, 25).Value = paciente.getDireccion();
            cmd.Parameters.AddWithValue("@FechaNac_PA", paciente.getFechaNac());
            cmd.Parameters.AddWithValue("@CorreoElectronico_PA", paciente.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@Telefono_PA", paciente.getTelefono());
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_ActualizarPaciente");
            return filas;
        }
    }
}
