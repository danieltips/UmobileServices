using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class FuncionesBC
    {
        FuncionesDALC dalc;

        public decimal Promedio_Uno(string codigo)
        {
            dalc = new FuncionesDALC();
            return dalc.Promedio_Uno(codigo);
        }

        public decimal Peso_Uno(string codigo)
        {
            dalc = new FuncionesDALC();
            return dalc.Peso_Uno(codigo);
        }
    }
}
