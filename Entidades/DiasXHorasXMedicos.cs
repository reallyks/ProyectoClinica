using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public  class DiasXHorasXMedicos
    {
        private int IdMedico;
        private int IdDia;
        private int IdHora;

        public DiasXHorasXMedicos()
        {

        }

        public int getIdMedico()
        {
            return IdMedico;
        }
        public void setIdMedico(int idmed)
        {
            IdMedico = idmed;
        }

        public int getIdDia()
        {
            return IdDia;
        }
        public void setIdDia(int idDia)
        {
            IdDia = idDia;
        }

        public int getIdHora()
        {
            return IdHora;
        }
        public void setIdHora(int idHora)
        {
            IdHora= idHora;
        }

        public int ConvertirHoraEnId(int hora)
        {
            int id = hora - 7; // a la hora recibida le restamos 7 para obtener el id respectivo. ej: 8am - id1 tiene diferencia de 7.
            return id;
        }

    }
}
