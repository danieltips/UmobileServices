using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UMOBILE.BL.BE;
using System.Globalization;
using UMOBILE.DALC.Properties;

namespace UMOBILE.DL.DALC
{
    public class HorarioDALC
    {
        public List<HorarioBE> GetHorario(string codigo, string periodo)
        {

            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodAlumno;
            SqlParameter prmPeriodo;

            try
            {

                List<HorarioBE> horarios = new List<HorarioBE>();
                HorarioBE horario;

                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_Horario";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@Alumno_id";
                prmCodAlumno.SqlDbType = SqlDbType.VarChar;
                prmCodAlumno.Value = codigo;

                prmPeriodo = cmdUsuarioObtener.CreateParameter();
                prmPeriodo.ParameterName = "@Periodo_id";
                prmPeriodo.SqlDbType = SqlDbType.VarChar;
                prmPeriodo.Value = periodo;

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Parameters.Add(prmPeriodo);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                while (drUsuarioObtener.Read())
                {
                    horario = new HorarioBE();
                    horario.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    horario.dia = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("dia"));
                    String[] horainicio = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("h_inicio")).Split(':');
                    String[] horafin = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("h_fin")).Split(':');
                    horario.horainicio = double.Parse(horainicio[0]) + double.Parse(horainicio[1]) * 0.01;
                    horario.horafin = double.Parse(horafin[0]) + double.Parse(horafin[1]) * 0.01;
                    horario.tipo = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("tipo"));
                    horario.salon = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("salon"));
                    horario.nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("Nombre"));
                    horario.curso_id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("Curso_id"));
                    horario.cruce = false;
                    horario.frec = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("frec"));
                    horario.fechainicio = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("f_inicio"));
                    horario.fechafin = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("f_fin"));
                    horarios.Add(horario);
                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return horarios;

            }
            catch (Exception ex)
            {
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();
                throw;
            }


        }

        public List<EvaluacionBE> GetEvaluacion(string codigo, string periodo)
        {
            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodAlumno;
            SqlParameter prmCiclo;


            try
            {
                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_Evaluacion";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@Alumno_id";
                prmCodAlumno.SqlDbType = SqlDbType.VarChar;
                prmCodAlumno.Value = codigo;

                prmCiclo = cmdUsuarioObtener.CreateParameter();
                prmCiclo.ParameterName = "@Periodo_id";
                prmCiclo.SqlDbType = SqlDbType.Int;
                prmCiclo.Value = Convert.ToInt32(periodo);

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Parameters.Add(prmCiclo);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                EvaluacionBE Evaluacion;
                List<EvaluacionBE> lstEvaluacion = new List<EvaluacionBE>();
                FuncionesDALC funciones = new FuncionesDALC();

                while (drUsuarioObtener.Read())
                {
                    Evaluacion = new EvaluacionBE();
                    Evaluacion.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    Evaluacion.nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nombre"));
                    Evaluacion.horainicio = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("horainicio"));
                    Evaluacion.horafin = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("horafin"));
                    Evaluacion.lugar = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("lugar"));
                    Evaluacion.tipo = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("tipo"));
                    Evaluacion.fecha = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("fecha"));
                    lstEvaluacion.Add(Evaluacion);

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return lstEvaluacion;

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
