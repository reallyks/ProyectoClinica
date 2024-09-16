using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administrador
    {
        private int IdAdministrador_AD;
        private string Nombre_AD;

        public Administrador()
        {

        }

        public int getIdAdministrador()
        {
            return IdAdministrador_AD;
        }

        public void setIdAdministrador(int id)
        {
            IdAdministrador_AD = id;
        }

        public string getNombre()
        {
            return Nombre_AD;
        }

        public void setNombre(string n)
        {
            Nombre_AD = n;
        }


    }
}
