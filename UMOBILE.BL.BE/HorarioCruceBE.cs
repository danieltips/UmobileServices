using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMOBILE.BL.BE
{
    public class HorarioCruceBE
    {
        public int id { get; set; }
        public int dia { get; set; }
        public string horario { get; set; }
        public int semana { get; set; }
        public double horainicio { get; set; }
        public double horafin { get; set; }
        public List<HorarioBE> horarios { get; set; }

        public HorarioCruceBE()
        {
            horarios = new List<HorarioBE>();
        }

    }
}
