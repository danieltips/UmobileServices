using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;
using UMOBILE.SI.DataContracts;

namespace UMOBILE.SI.ServiceContracts
{
    public class ActividadSC
    {

        public List<Actividad> GetActividad(string periodo)
        {
            ActividadBC bc = new ActividadBC();
            List<ActividadBE> be = new List<ActividadBE>();
            Actividad dc;
            List<Actividad> lst = new List<Actividad>();

            be = bc.GetActividad(periodo);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Actividad();
                dc.id = be[i].id;
                dc.mensaje = be[i].mensaje;
                dc.fecha = be[i].fecha;
                dc.ciclo = be[i].ciclo;
                dc.titulo = be[i].titulo;
                lst.Add(dc);
            }


            return lst;

        }

    }
}
