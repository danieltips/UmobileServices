using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.SI.DataContracts;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;

namespace UMOBILE.SI.ServiceContracts
{
    public class ProfesorSC
    {
        public List<Profesor> GetProfesor(string Curso_id, string Periodo_id, string Seccion_id)
        {
            ProfesorBC bc = new ProfesorBC();
            List<ProfesorBE> be = new List<ProfesorBE>();
            Profesor dc;
            List<Profesor> lst = new List<Profesor>();

            be = bc.GetProfesor(Curso_id,Periodo_id,Seccion_id);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Profesor();
                dc.id = be[i].id;
                dc.correo = be[i].correo;
                dc.nombre = be[i].nombre;
                dc.idcurso = be[i].cursoid;
                dc.seccionid = be[i].seccion;
                lst.Add(dc);
            }


            return lst;
        }
    }
}
