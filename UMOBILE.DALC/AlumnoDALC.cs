using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UMOBILE.BL.BE;

namespace UMOBILE.DALC
{
    public class AlumnoDALC
    {
        public List<AlumnoBE> GetAlumno(string codigo)
        {
            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodAlumno;
            SqlParameter prmPass;

            try
            {
                sCadenaConeccion = Properties.Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_AlumnoObtener";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@codigo";
                prmCodAlumno.SqlDbType = SqlDbType.VarChar;
                prmCodAlumno.Value = codigo;

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);

                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                AlumnoBE alumno;
                alumno = new AlumnoBE();

                while (drUsuarioObtener.Read())
                {

                    alumno.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    alumno.nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nombre"));
                    alumno.codigo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("codigo"));
                    alumno.carrera = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("Carrera"));
                    alumno.ciclo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("CicloIngreso"));
                    alumno.correo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("email"));
                    alumno.foto = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("DireccionFoto"));

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                List<AlumnoBE> widget = new List<AlumnoBE>();

                widget.Add(alumno);

                return widget;

            }
            catch (Exception ex)
            {
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();
                throw;
            }


        }

        public List<AlumnoBE> GetCompaneros(string Curso_id, string Periodo_id, string Seccion_id)
        {
            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodCurso;
            SqlParameter prmCodPeriodo;
            SqlParameter prmCodSeccion;

            try
            {
                sCadenaConeccion = Properties.Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_ListadoAlumnosMatriculados";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodCurso = cmdUsuarioObtener.CreateParameter();
                prmCodCurso.ParameterName = "@curso_id";
                prmCodCurso.SqlDbType = SqlDbType.VarChar;
                prmCodCurso.Value = Curso_id;

                prmCodPeriodo = cmdUsuarioObtener.CreateParameter();
                prmCodPeriodo.ParameterName = "@periodo_id";
                prmCodPeriodo.SqlDbType = SqlDbType.VarChar;
                prmCodPeriodo.Value = Periodo_id;

                prmCodSeccion = cmdUsuarioObtener.CreateParameter();
                prmCodSeccion.ParameterName = "@seccion_id";
                prmCodSeccion.SqlDbType = SqlDbType.VarChar;
                prmCodSeccion.Value = Seccion_id;

                cmdUsuarioObtener.Parameters.Add(prmCodCurso);
                cmdUsuarioObtener.Parameters.Add(prmCodPeriodo);
                cmdUsuarioObtener.Parameters.Add(prmCodSeccion);

                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                AlumnoBE alumno;
                
                List<AlumnoBE> widget = new List<AlumnoBE>();
                while (drUsuarioObtener.Read())
                {
                    alumno = new AlumnoBE();
                    alumno.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("Persona_id"));
                    alumno.nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nombre"));
                    alumno.codigo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("codigo"));
                    alumno.correo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("email"));
                    alumno.cursoid = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("Curso_id"));
                    alumno.seccionid = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("seccion_id"));
                    widget.Add(alumno);

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                

                

                return widget;

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
