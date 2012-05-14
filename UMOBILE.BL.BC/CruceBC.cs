using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using UMOBILE.DL.DALC;

namespace UMOBILE.BL.BC
{
    public class CruceBC
    {
        public List<CruceBE> GetCruce(string curso1, string curso2, string dia, string hora_inicio, string hora_fin)
        {
            CruceDALC dalc = new CruceDALC();
            return dalc.GetCruce(curso1, curso2, dia, hora_inicio, hora_fin);
        }
    }
}
