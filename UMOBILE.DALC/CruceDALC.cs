using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using System.Data.SqlClient;
using System.Data;

namespace UMOBILE.DL.DALC
{
    public class CruceDALC
    {
        public List<CruceBE> GetCruce(string curso1, string curso2, string dia, string hora_inicio, string hora_fin)
        {

            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCodCurso1;
            SqlParameter prmCodCurso2;
            SqlParameter prmDia;
            SqlParameter prmHorainicio;
            SqlParameter prmHorafin;

            try
            {

                List<CruceBE> Cruces = new List<CruceBE>();
                CruceBE Cruce;

                sCadenaConeccion = UMOBILE.DALC.Properties.Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_CruceDetalle";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodCurso1 = cmdUsuarioObtener.CreateParameter();
                prmCodCurso1.ParameterName = "@Curso1_id";
                prmCodCurso1.SqlDbType = SqlDbType.Int;
                prmCodCurso1.Value = Convert.ToInt32(curso1);

                prmCodCurso2 = cmdUsuarioObtener.CreateParameter();
                prmCodCurso2.ParameterName = "@Curso2_id";
                prmCodCurso2.SqlDbType = SqlDbType.Int;
                prmCodCurso2.Value = Convert.ToInt32(curso2);

                prmDia = cmdUsuarioObtener.CreateParameter();
                prmDia.ParameterName = "@dia";
                prmDia.SqlDbType = SqlDbType.Int;
                prmDia.Value = Convert.ToInt32(dia);

                prmHorainicio = cmdUsuarioObtener.CreateParameter();
                prmHorainicio.ParameterName = "@hora_inicio";
                prmHorainicio.SqlDbType = SqlDbType.VarChar;
                prmHorainicio.Value = hora_inicio;

                prmHorafin = cmdUsuarioObtener.CreateParameter();
                prmHorafin.ParameterName = "@hora_fin";
                prmHorafin.SqlDbType = SqlDbType.VarChar;
                prmHorafin.Value = hora_fin;

                cmdUsuarioObtener.Parameters.Add(prmCodCurso1);
                cmdUsuarioObtener.Parameters.Add(prmCodCurso2);
                cmdUsuarioObtener.Parameters.Add(prmDia);
                cmdUsuarioObtener.Parameters.Add(prmHorainicio);
                cmdUsuarioObtener.Parameters.Add(prmHorafin);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                while (drUsuarioObtener.Read())
                {
                    Cruce = new CruceBE();
                    Cruce.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    String[] horainicio = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("h_inicio")).Split(':');
                    String[] horafin = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("h_fin")).Split(':');
                    Cruce.horainicio = double.Parse(horainicio[0]) + double.Parse(horainicio[1]) * 0.01;
                    Cruce.horafin = double.Parse(horafin[0]) + double.Parse(horafin[1]) * 0.01;
                    Cruce.tipo = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("tipo"));
                    Cruce.salon = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("salon"));
                    Cruce.nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("Nombre"));
                    Cruces.Add(Cruce);
                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return Cruces;

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
