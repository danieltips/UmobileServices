using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using UMOBILE.BL.BE;

namespace UMOBILE.DALC
{
    public class PeriodoDALC
    {
        public List<PeriodoBE> GetPeriodo()
        {

            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;

            try
            {

                List<PeriodoBE> Periodos = new List<PeriodoBE>();
                PeriodoBE Periodo;

                sCadenaConeccion = Properties.Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "UMOBILE.sp_Periodo";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                while (drUsuarioObtener.Read())
                {
                    Periodo = new PeriodoBE();
                    Periodo.Id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    Periodo.Periodo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("periodo"));
                    Periodo.Inicio = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("inicio"));
                    Periodo.Fin = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("fin"));

                    Periodos.Add(Periodo);
                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return Periodos;


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
