using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;
using UMOBILE.SI.DataContracts;

namespace UMOBILE.SI.ServiceContracts
{
    public class CalificacionSC
    {

        public List<Calificacion> GetCalificacion(string codigo, string periodo)
        {
            CalificacionBC bc = new CalificacionBC();
            List<CalificacionBE> be = new List<CalificacionBE>();
            Calificacion dc;
            List<Calificacion> lst = new List<Calificacion>();

            be = bc.GetCalificacionesPorAlumno(codigo,periodo);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Calificacion();
                dc.id = be[i].Id;
                dc.idcurso = be[i].Idcurso;
                dc.nota = be[i].Nota;
                dc.numero = be[i].Numero;
                dc.peso = be[i].Peso;
                dc.tipo = be[i].Tipo;
                dc.evaluacion = be[i].Evaluacion;
                lst.Add(dc);
            }


            return lst;

        }

    }
}
