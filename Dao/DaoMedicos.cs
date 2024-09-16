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
    public class DaoMedicos
    {
        AccesoDatos ad = new AccesoDatos();

        public int AgregarMedico(Medico medico, Usuarios usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdMedico_ME", medico.getIdMedico());
            cmd.Parameters.AddWithValue("@Nombre_ME", medico.getNombre());
            cmd.Parameters.AddWithValue("@Apellido_ME", medico.getApellido());
            cmd.Parameters.AddWithValue("@Sexo_ME", medico.getSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad_ME", medico.getNacionalidad());
            cmd.Parameters.AddWithValue("@FechaNac_ME", medico.getFechanacimiento());
            cmd.Parameters.Add("@Direccion_ME", SqlDbType.Char, 25).Value = medico.getDireccion();
            cmd.Parameters.AddWithValue("@IdLocalidad_ME", medico.getIdLocalidad());
            cmd.Parameters.AddWithValue("@CorreoElectronico_ME", medico.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@Telefono_ME", medico.getTelefono());
            cmd.Parameters.AddWithValue("@IdEspecialidad_ME", medico.getIdEspecialidad());
            cmd.Parameters.AddWithValue("@Estado_ME", medico.getEstado());
            cmd.Parameters.AddWithValue("@NombreUsuario_US", usuario.GetNombreUsuario());
            cmd.Parameters.AddWithValue("@Contraseña_US", usuario.GetContraseña());
            cmd.Parameters.AddWithValue("@TipoUsuario_US", usuario.GetTipoUsuario());
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_AgregarMedicos");
            return filas;
        }

        public DataTable ObtenerDiasLaboralesMedico(int id)
        {
            string consulta = " select distinct NombreDia_Dias as DIAS from Dias inner join DiasXHoras on IdDia_Dias = IdDia_DiasXHoras inner join DiasXHorasXMedicos on IdDia_DiasXHoras = IdDia_DiasXHorasXMedicos where IdMedico_DiasXHorasXMedicos = " + id + " and IdDia_DiasXHorasXMedicos = IdDia_DiasXHoras ";
            DataTable dt = ad.ObtenerTabla("HorariosMedicos", consulta);
            return dt;
        }

        public DataTable ObtenerHorariosMedicos(int id, string dia)
        {
            string consulta = "SELECT IdDia_Dias AS DIAS, Hora_Horas AS HORARIOS " +
                              "FROM Horas " +
                              "INNER JOIN DiasXHoras ON IdHora_DiasXHoras = IdHora_Horas " +
                              "INNER JOIN Dias ON IdDia_Dias = IdDia_DiasXHoras " +
                              "INNER JOIN DiasXHorasXMedicos ON IdDia_Dias = IdDia_DiasXHorasXMedicos " +
                              "WHERE IdHora_DiasXHoras = IdHora_DiasXHorasXMedicos " +
                              "AND IdMedico_DiasXHorasXMedicos = " + id + " " +
                              "AND NombreDia_Dias = '" + dia.Trim() + "'";
            DataTable dt = ad.ObtenerTabla("HorariosMedicos", consulta);
            return dt;
        }


        public DataTable ObtenerNombre(int id)
        {
            string consulta = "SELECT Nombre_ME + Apellido_ME as NombreCompleto_ME from Medicos where IdMedico_ME = " + id;
            DataTable dt = ad.ObtenerTabla("Medicos", consulta);
            return dt;
        }

        public int DarDeBajaMedico(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IDMEDICO", Id);
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_DarDeBajaMedico");
            return filas;

        }

        public int DarDeAltaMedico(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IDMEDICO", Id);
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_DarDeAltaMedico");
            return filas;
        }

        public DataTable ListadoMedico()
        {
            string consulta = "SELECT IdMedico_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, FechaNac_ME, Direccion_ME, CorreoElectronico_ME, Telefono_ME FROM Medicos WHERE Estado_ME='True'";
            return ad.ObtenerTabla("medicos", consulta);
        }

        public DataTable ListadoMedicosDeBaja()
        {
            string consulta = "SELECT IdMedico_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, FechaNac_ME, Direccion_ME, CorreoElectronico_ME, Telefono_ME FROM Medicos WHERE Estado_ME='False'";
            return ad.ObtenerTabla("medicos", consulta);
        }

        public DataTable BuscarMedico(string busqueda)
        {
            string consulta = "SELECT IdMedico_ME, Nombre_ME, Apellido_ME, Sexo_ME, Nacionalidad_ME, FechaNac_ME, Direccion_ME, CorreoElectronico_ME, Telefono_ME FROM Medicos WHERE Nombre_ME LIKE '%" + busqueda + "%'";
            return ad.ObtenerTabla("medicos", consulta);
        }
        public DataTable BuscarMedicoPorEspecialidad(string busqueda)
        {
            string consulta = "SELECT IdMedico_ME, Nombre_ME + Apellido_ME AS NombreCompleto_ME, Sexo_ME, Nacionalidad_ME, FechaNac_ME, Direccion_ME, CorreoElectronico_ME, Telefono_ME FROM Medicos WHERE IdEspecialidad_ME LIKE '%" + busqueda + "%'";
            return ad.ObtenerTabla("medicos", consulta);
        }

        public bool ObtenerEstadoMedico(int Id)
        {
            string consulta = "SELECT Estado_ME FROM Medicos where IdMedico_ME = @Id";

            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@Id", SqlDbType.Int, 20);
            cmd.Parameters["@Id"].Value = Id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                bool estado = bool.Parse(dr["Estado_ME"].ToString());
                return estado;
            }
            return false;
        }

        public bool ExisteMedicoDadoDeBaja(int Id)
        {
            string consulta = "SELECT Estado_ME FROM Medicos where IdMedico_ME = @Id";

            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            cmd.Parameters.Add("@Id", SqlDbType.VarChar, 20);
            cmd.Parameters["@Id"].Value = Id;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                bool estado = bool.Parse(dr["Estado_ME"].ToString());

                if (estado == true)
                {
                    return false;
                }
            }
            return true;
        }
        public int ActualizarMedico(Medico medico)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdMedico_ME", medico.getIdMedico());
            cmd.Parameters.AddWithValue("@Nombre_ME", medico.getNombre());
            cmd.Parameters.AddWithValue("@Apellido_ME", medico.getApellido());
            cmd.Parameters.AddWithValue("@Sexo_ME", medico.getSexo());
            cmd.Parameters.AddWithValue("@Nacionalidad_ME", medico.getNacionalidad());
            cmd.Parameters.Add("@Direccion_ME", SqlDbType.Char, 25).Value = medico.getDireccion();
            cmd.Parameters.AddWithValue("@FechaNac_ME", medico.getFechanacimiento());
            cmd.Parameters.AddWithValue("@CorreoElectronico_ME", medico.getCorreoElectronico());
            cmd.Parameters.AddWithValue("@Telefono_ME", medico.getTelefono());
            int filas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_ActualizarMedico");
            return filas;
        }
        public int GenerarIdMedico()
        {
            string consulta = "SELECT COALESCE(MAX(IdMedico_ME) + 1, 1) AS UltimoIdMedico FROM Medicos";
            SqlCommand cmd = new SqlCommand(consulta, ad.Conectar());
            int idMedico = Convert.ToInt32(cmd.ExecuteScalar());
            return idMedico;
        }
    }
}
