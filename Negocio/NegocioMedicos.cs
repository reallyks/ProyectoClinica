using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;

namespace Negocio
{
    public class NegocioMedicos
    {
        DaoMedicos DaoMed = new DaoMedicos();

        public bool AgregarMedico(Medico medico, Usuarios usuarios)
        {
            if (DaoMed.AgregarMedico(medico, usuarios) > 0)
            {
                return true;
            }
            return false;
        }

        public string ObtenerNombre(int idMedico)
        {
            DataTable tabla = DaoMed.ObtenerNombre(idMedico);
            string nombre = "";
            foreach (DataRow row in tabla.Rows)
            {
                nombre = row["NombreCompleto_ME"].ToString();
            }
            return nombre;
        }

        public DataTable ObtenerDiasLaboralesMedico(int idMedico)
        {
            DataTable horarios = DaoMed.ObtenerDiasLaboralesMedico(idMedico);
            return horarios;
        }

        public DataTable ObtenerHorarioMedico(int idMedico, string dia)
        {
            DataTable horarios = DaoMed.ObtenerHorariosMedicos(idMedico, dia);
            return horarios;
        }


        public bool DarDeBajaMedico(int Id)
        {
            if (DaoMed.DarDeBajaMedico(Id) == 1)
            {
                return true;
            }
            return false;
        }

        public bool DarDeAltaMedico(int Id)
        {
            if (DaoMed.DarDeAltaMedico(Id) == 1)
            {
                return true;
            }
            return false;
        }

        public bool ObtenerEstadoMedico(int Id)
        {
            return DaoMed.ObtenerEstadoMedico(Id);
        }

        public DataTable ListadoMedicos()
        {
            return DaoMed.ListadoMedico();
        }

        public DataTable ListadoMedicosDeBaja()
        {
            return DaoMed.ListadoMedicosDeBaja();
        }

        public DataTable BuscarMedico(string busqueda)
        {
            return DaoMed.BuscarMedico(busqueda);
        }

        public DataTable buscarMedicoPorEspecialidad(string busqueda)
        {
            return DaoMed.BuscarMedicoPorEspecialidad(busqueda);
        }

        public bool ExisteMedicoDadoDeBaja(int Id)
        {
            return DaoMed.ExisteMedicoDadoDeBaja(Id);
        }
        public bool VerificarNacimiento(int anio)
        {
            DateTime fechaActual = DateTime.Now;
            int restaAnio = fechaActual.Year - anio;

            if (restaAnio >= 1 && restaAnio <= 120)
            {
                return true;
            }
            return false;
        }

        public int generarIdMedico()
        {
            return DaoMed.GenerarIdMedico();
        }

        public string ConfirmarMedico(int anioNacimiento, string contraseña, string confirmarContra)
        {
            string confirmacion = "";
            if (VerificarNacimiento(anioNacimiento))
            {
                if (ContraseñaSegura(contraseña))
                {
                    if (contraseña == confirmarContra)
                    {
                        return confirmacion;
                    }
                    else
                    {
                        confirmacion = "LAS CONTRASEÑAS NO SON IGUALES";
                        return confirmacion;
                    }
                }
                else
                {
                    confirmacion = "LA CONTRASEÑA DEBE CONTENER 8 CARACTERES UN '.' Y UNA MAYUS";
                    return confirmacion;
                }
            }
            else
            {
                confirmacion = "INGRESE UNA FECHA VALIDA";
                return confirmacion;
            }
        }
        public bool ContraseñaSegura(string contraseña)
        {
            if (contraseña.Length >= 8)
            {
                bool mayuscula = false;
                bool punto = false;

                foreach (char c in contraseña)
                {
                    if (char.IsUpper(c))
                    {
                        mayuscula = true;
                    }
                    if (c == '.')
                    {
                        punto = true;
                    }
                }

                return mayuscula && punto;
            }
            else
            {
                return false;
            }
        }
        public bool ActualizarMedico(Medico medico)
        {
            if (DaoMed.ActualizarMedico(medico) == 1) return true;
            return false;
        }

        public bool ConfirmarActualizacion(string nombre, string apellido, string sexo, string nacionalidad, string fecha, string direccion, string correo, string telefono)
        {
            if(nombre!="" && apellido != "" && sexo != "" && nacionalidad != "" && fecha != "" && direccion != "" && correo != "" && telefono != "")
            {
            return true;
            }
            else
            {
                return false;
            }
        }
    }
}
