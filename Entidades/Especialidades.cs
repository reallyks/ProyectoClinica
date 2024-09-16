using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Especialidades
    {
        private  int  Id_Especialidad_ES;
        private string Nombre_ES;

        public Especialidades()
        {

        }
         public int  getId_Especialidad()
        {
            return Id_Especialidad_ES;
        }
        public void setId_Especialidad(int i)
        {
            Id_Especialidad_ES = i;
        }

        public string getNombre()
        {
            return Nombre_ES;
        }

        public void setNombre(string n)
        {
            Nombre_ES = n;
        }




    }
}
