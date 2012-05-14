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
    public class CalificacionDALC
    {
        public List<CalificacionBE> GetCalificacionesPorAlumno(string codigo, string periodo)
        {

            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodAlumno;
            SqlParameter prmCodPeriodo;

            try
            {

                List<CalificacionBE> Calificaciones = new List<CalificacionBE>();
                CalificacionBE nota;

                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_NotasCursos";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@Alumno_id";
                prmCodAlumno.SqlDbType = SqlDbType.VarChar;
                prmCodAlumno.Value = codigo;

                prmCodPeriodo = cmdUsuarioObtener.CreateParameter();
                prmCodPeriodo.ParameterName = "@Periodo_id";
                prmCodPeriodo.SqlDbType = SqlDbType.VarChar;
                prmCodPeriodo.Value = periodo;

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Parameters.Add(prmCodPeriodo);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                while (drUsuarioObtener.Read())
                {
                    nota = new CalificacionBE();
                    nota.Id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    nota.Idcurso = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("idcurso"));
                    nota.Evaluacion = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("evaluacion"));
                    nota.Peso = Convert.ToDecimal(drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("peso")));
                    nota.Nota = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nota"));
                    Calificaciones.Add(nota);
                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();


                return Calificaciones;

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
