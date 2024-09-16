using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Dao;
using Entidades;

namespace Negocio
{
    public class NegocioHorario 
    {
        DaoDiasXHorasXMedicos DaoDXHXM = new DaoDiasXHorasXMedicos();
        DiasXHorasXMedicos horario = new DiasXHorasXMedicos();

        public bool AgregarHorario(DiasXHorasXMedicos horarios)
        {
            if (DaoDXHXM.AgregarHorario(horarios) > 0)
            {
                return true;
            }
            return false;
        }

        public void AsignarHorario(Medico medico,int Horario, int dia)
        {
            if (Horario == 1)
            {
                int horarioInicio = 8;
                horario.setIdMedico(medico.getIdMedico());
                horario.setIdDia(dia);
                int idHora = horario.ConvertirHoraEnId(horarioInicio);
                horario.setIdHora(idHora);
                AgregarHorario(horario);
            }
            else if (Horario == 2)
            {
                int horarioInicio = 10;
                horario.setIdMedico(medico.getIdMedico());
                horario.setIdDia(dia);
                int idHora = horario.ConvertirHoraEnId(horarioInicio);
                horario.setIdHora(idHora);
                AgregarHorario(horario);
            }
        }

    }
}
