using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class HorarioBC
    {
        HorarioDALC dalc;
        HorarioCursoDALC curso;

        public List<HorarioBE> GetHorario(string codigo,string periodo)
        {
            dalc = new HorarioDALC();
            return dalc.GetHorario(codigo,periodo);
        }

        public List<EvaluacionBE> GetEvaluacion(string codigo, string periodo)
        {
            dalc = new HorarioDALC();
            return dalc.GetEvaluacion(codigo, periodo);
        }

        public List<HorarioCursoBE> GetHorarioCurso(string codigo, string periodo)
        {
            curso = new HorarioCursoDALC();
            return curso.GetHorarioCurso(codigo, periodo);
        }
    }
}
