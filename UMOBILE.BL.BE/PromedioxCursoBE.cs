using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMOBILE.BL.BE
{
    public class PromedioxCursoBE
    {
        private decimal _Promedio;

        public decimal Promedio
        {
            get { return _Promedio; }
            set { _Promedio = value; }
        }
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

    }
}
