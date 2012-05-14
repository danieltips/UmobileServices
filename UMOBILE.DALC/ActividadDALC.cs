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
    public class ActividadDALC
    {
        public List<ActividadBE> GetActividades(string periodo)
        {

            SqlConnection Conn = null;
            String sCadenaConeccion;
            String sqlUsuarioObtener;
            SqlCommand cmdUsuarioObtener = null;
            SqlDataReader drUsuarioObtener;
            SqlParameter prmCiclo;

            try
            {
                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_Actividad";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCiclo = cmdUsuarioObtener.CreateParameter();
                prmCiclo.ParameterName = "@ciclo";
                prmCiclo.SqlDbType = SqlDbType.VarChar;
                prmCiclo.Value = periodo;

                cmdUsuarioObtener.Parameters.Add(prmCiclo);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                ActividadBE actividad;
                List<ActividadBE> lstactividad = new List<ActividadBE>();

                while (drUsuarioObtener.Read())
                {
                    actividad = new ActividadBE();
                    actividad.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    actividad.mensaje = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("mensaje"));
                    actividad.fecha = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("fecha"));
                    actividad.titulo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("titulo"));
                    actividad.ciclo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("ciclo"));
                    lstactividad.Add(actividad);

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return lstactividad;

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
