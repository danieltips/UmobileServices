using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;
using UMOBILE.SI.DataContracts;

namespace UMOBILE.SI.ServiceContracts
{
    public class CursoSC
    {

        public List<Curso> GetCurso(string codigo, string periodo)
        {
            CursoBC bc = new CursoBC();
            List<CursoBE> be = new List<CursoBE>();
            Curso dc;
            List<Curso> lst = new List<Curso>();

            be = bc.GetCursosPorAlumno(codigo,periodo);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Curso();
                dc.id = be[i].Id;
                dc.codigo = be[i].Codigo;
                dc.nombre = be[i].Nombre;
                dc.creditos = be[i].Creditos;
                dc.nivel = be[i].Nivel;
                dc.peso = be[i].Peso;
                dc.promedio = be[i].Promedio;
                dc.seccion = be[i].Seccion;
                lst.Add(dc);
            }


            return lst;

        }

    }
}
