using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class ActividadBC
    {
        public List<ActividadBE> GetActividad(string periodo)
        {
            ActividadDALC dalc = new ActividadDALC();
            return dalc.GetActividades(periodo);
        }
    }
}
