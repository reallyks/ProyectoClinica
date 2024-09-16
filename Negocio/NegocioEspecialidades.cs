using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioEspecialidades
    {
            DaoEspecialidades dl = new DaoEspecialidades();
            public SqlDataReader ObtenerEspecialidades()
            {
                return dl.obtenerEspecialidades();
            }
        public SqlDataReader buscarEspecialidades(string sv)
        {
            return dl.buscarEspecialidades(sv);
        }
    }
   
}
