using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.SI.DataContracts;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;

namespace UMOBILE.SI.ServiceContracts
{
    public class CruceSC
    {
        public List<Cruce> GetCruce(string curso1_id, string curso2_id, string dia, string horainicio, string horafin)
        {
            CruceBC bc = new CruceBC();
            List<CruceBE> be = new List<CruceBE>();
            Cruce dc;
            List<Cruce> lst = new List<Cruce>();

            be = bc.GetCruce(curso1_id,curso2_id,dia,horainicio,horafin);
            string cruce = null;

            if (be.Count > 1)
                cruce = min_inicio(be[0].horainicio, be[1].horainicio) + ":00 - " + min_fin(be[0].horafin, be[1].horafin) + ":00";
            else
                cruce = " - ";

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Cruce();
                dc.id = be[i].id;
                dc.nombre = be[i].nombre;
                dc.salon = be[i].salon;
                dc.cruce = cruce;
                dc.tipo = be[i].tipo;
                dc.horainicio = be[i].horainicio;
                dc.horafin = be[i].horafin;
                lst.Add(dc);
            }
            return lst;
        }

        public string min_inicio(double inicio1, double inicio2)
        {
            if (inicio1 >= inicio2)
                return inicio1.ToString();
            else
            return inicio2.ToString();
        }

        public string min_fin(double fin1, double fin2)
        {
            if (fin2 >=  fin1)
                return fin1.ToString();
            else
                return fin2.ToString();
        }
    }
}
