using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;

namespace Negocio
{
    public class NegocioUsuarios
    {
        DaoUsuarios DaoUs = new DaoUsuarios();

        public Usuarios ObtenerUsuario(Usuarios usuario)
        {
            usuario = DaoUs.ObtenerUsuario(usuario);
            if(usuario == null)
            {
                return null;
            }
            else
            {
                return usuario;
            }
        }

        public string ObtenerNombre(int id)
        {
            return DaoUs.ObtenerNombre(id);
        }

        public bool existeUsuario(string nombreUsuario)
        {
            return DaoUs.ExisteUsuario(nombreUsuario);
        }
    }
}

