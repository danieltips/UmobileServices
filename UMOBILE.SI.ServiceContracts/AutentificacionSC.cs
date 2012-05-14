using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.SI.DataContracts;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;

namespace UMOBILE.SI.ServiceContracts
{
    public class AutentificacionSC
    {
        public Autentificacion AutentificacionBC(string codigo, string password)
        {
            AutentificacionBC bc = new AutentificacionBC();
            AutentificacionBE be = new AutentificacionBE();
            Autentificacion dc = new Autentificacion();

            be = bc.Autentificacion(codigo, password);

            dc.codigo = be.codigo;
            dc.id = be.id;
            dc.nombre = be.nombre;
            dc.periodo = be.periodo;

            return dc;
        }
    }
}
