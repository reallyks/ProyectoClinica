using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
        private int IdTurno_TU;
        private int IdMedico_TU;
        private string DniPac_TU;
        private string Horario_TU;
        private string Fecha_TU;
        private bool Asistencia_TU;

        public Turnos()
        {

        }

        public int getIdTurno()
        {
            return IdTurno_TU;
        }

        public void setIdTurno(int id)
        {
            IdTurno_TU = id;
        }


        public int getIdMedico()
        {
            return IdMedico_TU;
        }

        public void setIdMedico(int id)
        {
            IdMedico_TU = id;
        }

        public string getDniPac()
        {
            return DniPac_TU;
        }

        public void setDniPac(string d)
        {
            DniPac_TU = d;
        }

        public string getHorario()
        {
            return Horario_TU;
        }
        public void setHorario(string h)
        {
            Horario_TU = h;
        }

        public string getFechaTurno()
        {
            return Fecha_TU;
        }

        public void setFechaTurno(string d)
        {
            Fecha_TU = d;
        }

        public bool getAsistencia()
        {
            return Asistencia_TU;
        }
        public void setAsistencia(bool a)
        {
            Asistencia_TU = a;
        }
    }
}
