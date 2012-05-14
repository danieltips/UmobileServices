using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UMOBILE.BL.BE;
using UMOBILE.DALC.Properties;

namespace UMOBILE.DL.DALC
{
    public class HorarioCursoDALC
    {
        public List<HorarioCursoBE> GetHorarioCurso(string codigo, string periodo)
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

                List<HorarioCursoBE> horarios = new List<HorarioCursoBE>();
                HorarioCursoBE horario;

                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_HorarioCurso";
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
                    horario = new HorarioCursoBE();
                    horario.Id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    horario.Idcurso = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("idcurso"));
                    horario.Dia = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("dia"));
                    horario.Horainicio = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("h_inicio"));
                    horario.Horafin = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("h_fin"));
                    horario.Salon = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("salon"));
                    horario.Sede = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("sede"));
                    horario.Tipo = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("tipo"));
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
    }
}
