using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Medicos
    {
        private int IdMedico_ME;
        private int IdLocalidad_ME;
        private int IdEspecialidad_ME;
        private string Nombre_ME;
        private string Apellido_ME;
        private string Sexo_ME;
        private DateTime FechaNac_ME;
        private string Nacionalidad_ME;
        private string Direccion_ME;
        private string CorreoElectronico_ME;
        private string Telefono_ME;
        private bool Estado_ME;

        public Medicos()
        {

        }

        public int getIdMedico()
        {
            return IdMedico_ME;
        }
        public void setIdMedico(int idmedico)
        {
            IdMedico_ME = idmedico;
        }

        public int getIdLocalidad()
        {
            return IdLocalidad_ME;
        }

        public void setIdLocalidad(int idlocalidad)
        {
            IdLocalidad_ME = idlocalidad;

        }

        public int getIdEspecialidad()
        {
            return IdEspecialidad_ME;
        }

        public void setIdEspecialidad(int idEspecialidad)
        {
            IdEspecialidad_ME = idEspecialidad;
        }

        public string getNombre()
        {
            return Nombre_ME;
        }

        public void setNombre(string nombre)
        {
            Nombre_ME = nombre;
        }

        public string getApellido()
        {
            return Apellido_ME;
        }

        public void setApellido(string apellido)
        {
            Apellido_ME = apellido;
        }

        public string getSexo()
        {
            return Sexo_ME;
        }
        public void setSexo(string sexo)
        {
            Sexo_ME = sexo;
        }

        public DateTime getFechanacimiento()
        {
            return FechaNac_ME;
        }

        public void setFechanacimiento(DateTime fecha)
        {
            FechaNac_ME = fecha;
        }


        public  string getNacionalidad()
        {
            return Nacionalidad_ME;
        }
        public void setNacionalidad(string nac)
        {
            Nacionalidad_ME = nac;
        }
        public string getDireccion()
        {
            return Direccion_ME;
        }

        public void setDireccion(string dir)
        {
            Direccion_ME = dir;
        }

        public string getCorreoElectronico()
        {
            return CorreoElectronico_ME;
        }

        public void setCorreoElectronico(string correo)
        {
            CorreoElectronico_ME = correo;
        }



       public string getTelefono()
        {
            return Telefono_ME;

        }
        public void setTelefono(string tel)
        {
            Telefono_ME = tel;
        }


        public bool getEstado()
        {
            return Estado_ME;
        }
        public void setEstado(bool estado)
        {
            Estado_ME = estado;
        }


    }




}
