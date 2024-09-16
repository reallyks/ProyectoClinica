using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Provincias
    {

        private int IdProvincia_PR;
        private string Nombre_PR;

            public Provincias()
            {}
        public int getIdProvincia()
        {
            return IdProvincia_PR;
        }
        public string getNombre()
        {
            return Nombre_PR;
        }
        public void setIdProvincia(int idProvincia)
        {
            IdProvincia_PR = idProvincia;
        }

        public void setNombre(string nombre)
        {
            Nombre_PR = nombre;
        }

    }
}
