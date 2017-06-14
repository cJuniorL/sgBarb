using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Agenda
    {
        public int id { get; set; }

        public string horarioInicio { get; set; }

        public string duracao { get; set; }

        public DateTime data { get; set; }

        public bool encaixe { get; set; }

        public int clienteID { get; set; }

        public int funcionarioID { get; set; }

        public string sHorarioInicio { get; set; }

        public string sDuracao { get; set; }

        public string horarioFimCalc()
        {
            int hora = Convert.ToInt32(horarioInicio.Substring(0, 2)) + Convert.ToInt32(duracao.Substring(0, 2));
            int minuto = Convert.ToInt32(horarioInicio.Substring(3, 2)) + Convert.ToInt32(duracao.Substring(3, 2));
            if (minuto > 59)
            {
                hora++;
                minuto -= 60;
            }
            if (hora > 23)
            {
                hora -= 24;
            }
            return hora.ToString("00") + ":" + minuto.ToString("00");
        }

        public int getHora()
        {
            return Convert.ToInt32(horarioInicio.Substring(0, 2));
        }

        public int getMinuto()
        {
            return Convert.ToInt32(horarioInicio.Substring(3, 2));
        }
    }
}