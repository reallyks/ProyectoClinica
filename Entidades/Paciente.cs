using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string Dni_PA;
        private int IdLocalidad_PA;
        private string Nombre_PA;
        private string Apellido_PA;
        private string Sexo_PA;
        private string Nacionalidad_PA;
        private DateTime FechaNac_PA;
        private string Direccion_PA;
        private string CorreoElectronico_PA;
        private string Telefono_PA;
        private bool Estado_PA;

        public Paciente()
        {

        }

        public string getDni()
        {
            return Dni_PA;
        }
        public void setDni(string d)
        {
            Dni_PA = d;
        }

        public int getIdLocalidad()
        {
            return IdLocalidad_PA;
        }

        public void setIdLocalidad(int d)
        {
            IdLocalidad_PA = d;
        }

        public string getNombre()
        {
            return Nombre_PA;
        }

        public void setNombre(string n)
        {
            Nombre_PA = n;
        }

        public string getApellido()
        {
            return Apellido_PA;
        }
        public void setApellido(string a)
        {
            Apellido_PA = a;
        }

        public string getSexo()
        {
            return Sexo_PA;
        }

        public void setSexo(string s)
        {
            Sexo_PA = s;
        }

        public string getNacionalidad()
        {
            return Nacionalidad_PA;
        }

        public void setNacionalidad(string n)
        {
            Nacionalidad_PA = n;
        }

        public DateTime getFechaNac()
        {
            return FechaNac_PA;
        }
        public void setFechaNac(DateTime fecha)
        {
            FechaNac_PA = fecha;
        }

        public string getDireccion()
        {
            return Direccion_PA;
        }

        public void setDireccion(string d)
        {
            Direccion_PA = d;
        }

        public string getCorreoElectronico()
        {
            return CorreoElectronico_PA;
        }

        public void setCorreoElectronico(string correo)
        {
            CorreoElectronico_PA = correo;
        }

        public string getTelefono()
        {
            return Telefono_PA;


        }
        public void setTelefono(string t)
        {
            Telefono_PA = t;
        }

        public bool getEstado()
        {
            return Estado_PA;
        }

        public void setEstado(bool e)
        {
            Estado_PA = e;
        }




    }
}
