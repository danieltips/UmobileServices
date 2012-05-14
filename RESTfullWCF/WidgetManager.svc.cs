using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UMOBILE.SI.DataContracts;
using UMOBILE.BL.BC;
using UMOBILE.SI.ServiceContracts;

namespace RESTfullWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WidgetManager" in code, svc and config file together.
    public class WidgetManager : IWidgetManager
    {
        public Autentificaciones[] GetAutentificacion(string codigo, string password)
        {
            try
            {
                AutentificacionSC alumno;
                alumno = new AutentificacionSC();
                Autentificacion dc = new Autentificacion();

                dc = alumno.AutentificacionBC(codigo, password);

                List<Autentificaciones> widgets = new List<Autentificaciones>();
                Autentificaciones objeto = new Autentificaciones();
                objeto.autentificacion = dc;
                widgets.Add(objeto);
                return widgets.ToArray();
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public Alumnos[] GetAlumno(string codigo)
        {
            try
            {
                AlumnoSC alumno;
                alumno = new AlumnoSC();
                List<Alumno> dc = new List<Alumno>();

                dc = alumno.GetAlumno(codigo);

                List<Alumnos> widgets = new List<Alumnos>();

                Alumnos objeto = new Alumnos();
                objeto.alumno = dc[0];
                widgets.Add(objeto);
                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public Horarios[] GetHorario(string codigo, string periodo, string fecha)
        {

            try
            {
                string ba = "";
                String[] split_inicio = fecha.Split('-');

                ba = split_inicio[1] + "/" + split_inicio[0] + "/" + split_inicio[2];

                List<Horario> dc = new List<Horario>();
                HorarioSC Horario;
                Horario = new HorarioSC();

                dc = Horario.GetHorario(codigo, periodo, ba);

                List<Horarios> widgets = new List<Horarios>();

                Horarios lstcursos;
                for (int i = 0; i < dc.Count; i++)
                {
                    lstcursos = new Horarios();
                    lstcursos.horario = dc[i];
                    widgets.Add(lstcursos);
                }

                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public Cruces[] GetCruce(string curso1, string curso2, string dia, string horainicio, string horafin)
        {
            try
            {
                CruceSC Cruce;
                Cruce = new CruceSC();
                List<Cruce> dc = new List<Cruce>();

                dc = Cruce.GetCruce(curso1, curso2, dia, horainicio, horafin);

                List<Cruces> widgets = new List<Cruces>();

                Cruces lstcursos;
                for (int i = 0; i < dc.Count; i++)
                {
                    lstcursos = new Cruces();
                    lstcursos.cruce = dc[i];
                    widgets.Add(lstcursos);
                }

                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Cursos[] GetCursos(string codigo, string periodo)
        {

            try
            {
                CursoSC Curso;
                Curso = new CursoSC();
                List<Curso> dc = new List<Curso>();

                dc = Curso.GetCurso(codigo, periodo);

                List<Cursos> widgets = new List<Cursos>();

                Cursos lstcursos;
                for (int i = 0; i < dc.Count; i++)
                {
                    lstcursos = new Cursos();
                    lstcursos.curso = dc[i];
                    widgets.Add(lstcursos);
                }
                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Calificaciones[] GetCalificaciones(string codigo, string periodo)
        {

            try
            {

                CalificacionSC Calificacion;
                Calificacion = new CalificacionSC();
                List<Calificacion> dc = new List<Calificacion>();

                dc = Calificacion.GetCalificacion(codigo, periodo);

                Calificaciones lst;
                List<Calificaciones> lstCalificaciones = new List<Calificaciones>();

                for (int i = 0; i < dc.Count; i++)
                {
                    lst = new Calificaciones();
                    lst.calificacion = dc[i];
                    lstCalificaciones.Add(lst);
                }

                return lstCalificaciones.ToArray();

            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public HorariosCurso[] GetHorarioCurso(string codigo, string periodo)
        {
            try
            {

                HorarioSC HorarioCurso;
                HorarioCurso = new HorarioSC();
                List<HorarioCurso> dc = new List<HorarioCurso>();

                dc = HorarioCurso.GetHorarioCurso(codigo, periodo);

                HorariosCurso lst;
                List<HorariosCurso> lsthorarios = new List<HorariosCurso>();


                for (int i = 0; i < dc.Count; i++)
                {
                    lst = new HorariosCurso();
                    lst.horariocurso = dc[i];
                    lsthorarios.Add(lst);
                }

                return lsthorarios.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public Companeros[] GetCompanero(string curso, string seccion, string periodo)
        {
            try
            {
                AlumnoSC alumno;
                alumno = new AlumnoSC();
                List<Companero> dc = new List<Companero>();

                dc = alumno.GetCompaneros(curso, periodo, seccion);

                List<Companeros> widgets = new List<Companeros>();

                Companeros lstcursos;
                for (int i = 0; i < dc.Count; i++)
                {
                    lstcursos = new Companeros();
                    lstcursos.companero = dc[i];
                    widgets.Add(lstcursos);
                }
                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Profesores[] GetProfesor(string curso, string seccion, string periodo)
        {
            try
            {
                ProfesorSC alumno;
                alumno = new ProfesorSC();
                List<Profesor> dc = new List<Profesor>();

                dc = alumno.GetProfesor(curso, periodo, seccion);

                List<Profesores> widgets = new List<Profesores>();

                Profesores lstcursos;
                for (int i = 0; i < dc.Count; i++)
                {
                    lstcursos = new Profesores();
                    lstcursos.profesor = dc[i];
                    widgets.Add(lstcursos);
                }
                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Evaluaciones[] GetEvaluacion(string codigo, string periodo)
        {
            try
            {
                HorarioSC alumno;
                alumno = new HorarioSC();
                List<Evaluacion> dc = new List<Evaluacion>();

                dc = alumno.GetEvaluacion(codigo, periodo);

                List<Evaluaciones> widgets = new List<Evaluaciones>();

                Evaluaciones lstcursos;
                for (int i = 0; i < dc.Count; i++)
                {
                    lstcursos = new Evaluaciones();
                    lstcursos.evaluacion = dc[i];
                    widgets.Add(lstcursos);
                }
                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Actividades[] GetActividad(string periodo)
        {
            try
            {
                ActividadSC Actividad;
                Actividad = new ActividadSC();
                List<Actividad> dc = new List<Actividad>();

                dc = Actividad.GetActividad(periodo);

                List<Actividades> widgets = new List<Actividades>();

                Actividades lstActividades;
                for (int i = 0; i < dc.Count; i++)
                {
                    lstActividades = new Actividades();
                    lstActividades.actividad = dc[i];
                    widgets.Add(lstActividades);
                }
                return widgets.ToArray();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public decimal Promedio_Uno(string codigo)
        {
            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodAlumno;

            try
            {

                PromedioxCurso Promedio;

                sCadenaConeccion = "server=204.93.193.254; database=umobile_SIIA-EDUCATE; User Id=umobile_upc; Pwd=123456";
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "UMOBILE.ups_PromedioCurso";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@codcurso";
                prmCodAlumno.SqlDbType = SqlDbType.Int;
                prmCodAlumno.Value = Convert.ToInt32(codigo);

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();
                Promedio = new PromedioxCurso();

                decimal promedio = 0;

                while (drUsuarioObtener.Read())
                {
                    promedio = Math.Round(drUsuarioObtener.GetDecimal(drUsuarioObtener.GetOrdinal("promedio")), 2);

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return promedio;

            }
            catch (Exception ex)
            {
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();
                throw;
            }
        }

        public decimal Peso_Uno(string codigo)
        {
            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodAlumno;

            try
            {

                PromedioxCurso Promedio;

                sCadenaConeccion = "server=204.93.193.254; database=umobile_SIIA-EDUCATE; User Id=umobile_upc; Pwd=123456";
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "UMOBILE.ups_PesoCurso";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@codcurso";
                prmCodAlumno.SqlDbType = SqlDbType.Int;
                prmCodAlumno.Value = Convert.ToInt32(codigo);

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();
                Promedio = new PromedioxCurso();

                decimal promedio = 0;

                while (drUsuarioObtener.Read())
                {
                    promedio = Math.Round(drUsuarioObtener.GetDecimal(drUsuarioObtener.GetOrdinal("promedio")), 2);

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return promedio;

            }
            catch (Exception ex)
            {
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();
                throw;
            }
        }

    }
}
