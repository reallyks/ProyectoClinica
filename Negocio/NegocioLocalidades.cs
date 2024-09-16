using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioLocalidades
    {
    DaoLocalidades dl = new DaoLocalidades();
        public SqlDataReader ObtenerLocalidades(string sv)
        {
            return dl.obtenerLocalidades(sv);
        }
    }
}
