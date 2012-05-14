using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMOBILE.BL.BE
{
    public class HorarioBE
    {
        public int id { get; set; }
        public int dia { get; set; }
        public double horainicio { get; set; }
        public double horafin { get; set; }
        public string horario { get; set; }
        public string salon { get; set; }
        public int tipo { get; set; }
        public string nombre { get; set; }
        public bool cruce { get; set; }
        public int frec { get; set; }
        public String fechainicio { get; set; }
        public String fechafin { get; set; }
        public int curso_id { get; set; }
        public int semana { get; set; }
        public HorarioCruceBE horarioCruce { get; set; }
    }
}
