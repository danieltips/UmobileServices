using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.SI.DataContracts;
using UMOBILE.BL.BC;
using UMOBILE.BL.BE;

namespace UMOBILE.SI.ServiceContracts
{
    public class AlumnoSC
    {
        public List<Alumno> GetAlumno(string codigo)
        {
            AlumnoBC bc = new AlumnoBC();
            List<AlumnoBE> be = new List<AlumnoBE>();
            Alumno dc;
            List<Alumno> lst = new List<Alumno>();

            be = bc.GetAlumno(codigo);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Alumno();
                dc.id = be[i].id;
                dc.carrera = be[i].carrera;
                dc.ciclo = be[i].ciclo;
                dc.codigo = be[i].codigo;
                dc.correo = be[i].correo;
                dc.foto = be[i].foto;
                dc.nombre = be[i].nombre;
                lst.Add(dc);
            }
            

            return lst;
        }

        public List<Companero> GetCompaneros(string Curso_id, string Periodo_id, string Seccion_id)
        {
            AlumnoBC bc = new AlumnoBC();
            List<AlumnoBE> be = new List<AlumnoBE>();
            Companero dc;
            List<Companero> lst = new List<Companero>();

            be = bc.GetCompaneros(Curso_id,Periodo_id,Seccion_id);

            for (int i = 0; i < be.Count; i++)
            {
                dc = new Companero();
                dc.id = be[i].id;
                dc.codigo = be[i].codigo;
                dc.correo = be[i].correo;
                dc.nombre = be[i].nombre;
                dc.idcurso = be[i].cursoid;
                dc.seccion = be[i].seccionid;
                lst.Add(dc);
            }


            return lst;
        }

    }
}
