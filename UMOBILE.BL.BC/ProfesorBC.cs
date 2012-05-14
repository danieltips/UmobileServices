using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class ProfesorBC
    {
        public List<ProfesorBE> GetProfesor(string Curso_id, string Periodo_id, string Seccion_id)
        {
            ProfesorDALC dalc = new ProfesorDALC();
            return dalc.GetProfesor(Curso_id, Periodo_id, Seccion_id);
        }
    }
}
