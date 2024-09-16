using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Informes
    {
        private int IdInforme_IN;
        private DateTime RangodeInicio_IN;
        private DateTime RangodeFin_IN;
        private int Presente_IN;
        private int Ausente_IN;

        public Informes()
        {

        }

        public int getIdInforme()
        {
            return IdInforme_IN;
        }
        public void setIdInforme(int id)
        {
            IdInforme_IN = id;
        }

        public DateTime getRangoInicio()
        {
            return RangodeInicio_IN;
        }
        public void setRangoInicio(DateTime r)
        {
            RangodeInicio_IN = r;
        }

        public DateTime getRangoFin()
        {
            return RangodeFin_IN;
        }

        public void setRangoFin(DateTime r)
        {
            RangodeFin_IN = r;
        }

        public int getPresente()
        {
            return Presente_IN;
        }

        public void setPresente(int p)
        {
            Presente_IN = p;
        }

        public int getAusente()
        {
            return Ausente_IN;
        }
        public void setAusente(int a)
        {
            Ausente_IN = a;
        }

    }
}
