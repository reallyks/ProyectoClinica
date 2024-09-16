using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class Usuarios
    {
        private int IdUsuario_US;
        private string NombreUsuario_US;
        private string Contraseña_US;
        private string TipoUsuario_US;
        private int IdMedico_US;
        private int IdAdmin_US;


        public Usuarios()
        {

        }

        public string GetNombreUsuario()
        {
            return NombreUsuario_US;
        }
        public void SetNombreUsuario(string u)
        {
            NombreUsuario_US = u;
        }

        public int GetIdUsuario()
        {
            return IdUsuario_US;
        }
        public void SetIdUsuario(int id)
        {
            IdUsuario_US = id;
        }

        public string GetContraseña()
        {
            return Contraseña_US;
        }

        public void SetContraseña(string c)
        {
            Contraseña_US = c;
        }

        public string GetTipoUsuario()
        {
            return TipoUsuario_US;
        }

        public void SetTipoUsuario(string tipo)
        {
            TipoUsuario_US = tipo;
        }

        public int GetIdMedico()
        {
            return IdMedico_US;
        }
        public void SetIdMedico(int id)
        {
            IdMedico_US = id;
        }

        public int GetIdAdmin()
        {
            return IdAdmin_US;
        }
        public void SetIdAdmin(int id)
        {
            IdAdmin_US = id;
        }




    }
}
