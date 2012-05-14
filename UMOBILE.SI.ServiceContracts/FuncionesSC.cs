using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.SI.DataContracts;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;

namespace UMOBILE.SI.ServiceContracts
{
    public class FuncionesSC
    {
        FuncionesBC dalc;

        public decimal Promedio_Uno(string codigo)
        {
            dalc = new FuncionesBC();
            return dalc.Promedio_Uno(codigo);
        }

        public decimal Peso_Uno(string codigo)
        {
            dalc = new FuncionesBC();
            return dalc.Peso_Uno(codigo);
        }
    }
}
