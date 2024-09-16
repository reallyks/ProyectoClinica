using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class Localidades
    {
        private int IdProvincia_LO;
        private int IdLocalidad_LO;
        private string Nombre_LO;
public Localidades ()
    {

    }
  public int getIdProvincia()
        {
            return IdProvincia_LO;
        }
public void setIdProvincia(int idProvincia)
        {
            IdProvincia_LO = idProvincia;
        }

    public int getIdLocalidad()
        {
            return IdLocalidad_LO;
        }

        public void setIdLocalidad(int idlocalidad)
        {
            IdLocalidad_LO = idlocalidad;
        }


    public void setNombre(string nombre)
        {
            Nombre_LO = nombre;
        }

        public string getNombre()
        {
            return Nombre_LO;
        }


    }
    
}
