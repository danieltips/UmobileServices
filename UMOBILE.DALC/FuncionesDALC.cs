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
    public class FuncionesDALC
    {

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

                PromedioxCursoBE Promedio;

                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_PromedioCurso";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@Curso_id";
                prmCodAlumno.SqlDbType = SqlDbType.Int;
                prmCodAlumno.Value = Convert.ToInt32(codigo);

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();
                Promedio = new PromedioxCursoBE();

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

                PromedioxCursoBE Promedio;

                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_PesoCurso";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@Curso_id";
                prmCodAlumno.SqlDbType = SqlDbType.Int;
                prmCodAlumno.Value = Convert.ToInt32(codigo);

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();
                Promedio = new PromedioxCursoBE();

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

        //public List<CalificacionBE> GetCalificacionesPorCurso(string codigo)
        //{

        //    SqlConnection Conn = null;
        //    String sCadenaConeccion;
        //    String sqlUsuarioObtener;
        //    SqlCommand cmdUsuarioObtener = null;
        //    SqlDataReader drUsuarioObtener;
        //    SqlParameter prmCodAlumno;

        //    try
        //    {

        //        List<CalificacionBE> Calificaciones = new List<CalificacionBE>();
        //        CalificacionBE nota;

        //        sCadenaConeccion = Settings.Default.csDesarrollo;
        //        Conn = new SqlConnection(sCadenaConeccion);
        //        sqlUsuarioObtener = "UMOBILE.sp_CalificacionesCursos";
        //        cmdUsuarioObtener = Conn.CreateCommand();
        //        cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
        //        cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

        //        prmCodAlumno = cmdUsuarioObtener.CreateParameter();
        //        prmCodAlumno.ParameterName = "@codigo";
        //        prmCodAlumno.SqlDbType = SqlDbType.VarChar;
        //        prmCodAlumno.Value = codigo;

        //        cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
        //        cmdUsuarioObtener.Connection.Open();
        //        drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

        //        while (drUsuarioObtener.Read())
        //        {
        //            nota = new Calificacion();
        //            nota.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
        //            nota.idcurso = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("idcurso"));
        //            nota.tipo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("tipo"));
        //            nota.evaluacion = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("evaluacion"));
        //            nota.numero = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("numero"));
        //            nota.peso = Convert.ToDecimal(drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("peso")));
        //            nota.nota = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nota"));
        //            Calificaciones.Add(nota);
        //        }

        //        cmdUsuarioObtener.Connection.Close();
        //        cmdUsuarioObtener.Dispose();
        //        Conn.Dispose();

        //        return Calificaciones;
        //    }
        //    catch (Exception ex)
        //    {

        //        cmdUsuarioObtener.Dispose();
        //        Conn.Dispose();
        //        throw;
        //    }


        //}
    }
}
