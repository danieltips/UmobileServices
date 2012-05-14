using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class CalificacionBC
    {
        public List<CalificacionBE> GetCalificacionesPorAlumno(string codigo, string periodo)
        {
            CalificacionDALC dalc = new CalificacionDALC();
            return dalc.GetCalificacionesPorAlumno(codigo, periodo);

        }
    }
}
