using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class AutentificacionBC
    {
        public AutentificacionBE Autentificacion(string codigo, string password)
        {
            AutentificacionDALC dalc = new AutentificacionDALC();
            return dalc.Autentificacion(codigo, password);
        }
    }
}
