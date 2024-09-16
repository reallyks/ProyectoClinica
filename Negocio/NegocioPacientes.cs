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
    public class NegocioPacientes
    {
        DaoPacientes DaoPac = new DaoPacientes();

        public bool AgregarPaciente(Paciente paciente)
        {
            DaoPacientes daoPac = new DaoPacientes();
            if (!daoPac.Existe(paciente.getDni()))
            {
                if (daoPac.AgregarPaciente(paciente) == 1)
                {
                    return true;
                }

            }
            return false;
        }

        public bool DarDeBajaPaciente(string dni)
        {
            if (DaoPac.DarDeBajaPaciente(dni) == 1)
            {
                return true;
            }
            return false;
        }

        public bool DarDeAltaPaciente(string dni)
        {
            if (DaoPac.DarDeAltaPaciente(dni) == 1)
            {
                return true;
            }
            return false;
        }

        public bool ObtenerEstadoPaciente(string dni)
        {
            return DaoPac.ObtenerEstadoPaciente(dni);
        }

        public DataTable ListadoPacientes()
        {
            return DaoPac.ListadoPacientes();
        }

        public DataTable ListadoPacientesDeBaja()
        {
            return DaoPac.ListadoPacientesDeBaja();
        }

        public DataTable BuscarPaciente(string busqueda)
        {
            return DaoPac.BuscarPaciente(busqueda);
        }

        public bool ExistePaciente(string dni)
        {
            return DaoPac.Existe(dni);
        }

        public bool ExistePacienteDadoDeBaja(string dni)
        {
            return DaoPac.ExistePacienteDadoDeBaja(dni);
        }
        public bool VerificarNacimiento(int anio)
        {
            DateTime fechaActual = DateTime.Now;
            int restaAnio = fechaActual.Year - anio;

            if(restaAnio >=1 && restaAnio <= 120)
            {
                return true;
            }
            return false;
        }
        public bool ActualizarPaciente(Paciente paciente)
        {
            if (DaoPac.ActualizarPaciente(paciente) == 1) return true;
            return false;
        }

        public bool ConfirmarActualizacion(string nombre, string apellido, string sexo, string nacionalidad, string fecha, string direccion, string correo, string telefono)
        {
            if (nombre != "" && apellido != "" && sexo != "" && nacionalidad != "" && fecha != "" && direccion != "" && correo != "" && telefono != "")
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