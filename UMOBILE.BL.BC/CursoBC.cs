using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class CursoBC
    {
        public List<CursoBE> GetCursosPorAlumno(string codigo, string periodo)
        {
            CursoDALC dalc = new CursoDALC();
            return dalc.GetCursosPorAlumno(codigo, periodo);
        }
    }
}
