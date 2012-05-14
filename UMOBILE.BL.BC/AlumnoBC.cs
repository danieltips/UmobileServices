using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.DALC;
using UMOBILE.BL.BE;

namespace UMOBILE.BL.BC
{
    public class AlumnoBC
    {

        AlumnoDALC dalc;

        public List<AlumnoBE> GetAlumno(string codigo)
        {
            dalc = new AlumnoDALC();
            return dalc.GetAlumno(codigo);
        }

        public List<AlumnoBE> GetCompaneros(string Curso_id, string Periodo_id, string Seccion_id)
        {
            dalc = new AlumnoDALC();
            return dalc.GetCompaneros(Curso_id, Periodo_id, Seccion_id);
        }
    }
}
