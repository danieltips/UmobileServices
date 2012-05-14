using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMOBILE.BL.BE
{
    public class PeriodoBE
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Periodo;

        public string Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }
        private string _Inicio;

        public string Inicio
        {
            get { return _Inicio; }
            set { _Inicio = value; }
        }
        private string _Fin;

        public string Fin
        {
            get { return _Fin; }
            set { _Fin = value; }
        }

    }
}
