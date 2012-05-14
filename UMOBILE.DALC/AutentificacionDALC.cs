using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using System.Data.SqlClient;
using System.Data;
using UMOBILE.DALC.Properties;

namespace UMOBILE.DL.DALC
{
    public class AutentificacionDALC
    {
        public AutentificacionBE Autentificacion(string codigo, string password)
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
                sCadenaConeccion = Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_Autentificacion";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@codigo";
                prmCodAlumno.SqlDbType = SqlDbType.VarChar;
                prmCodAlumno.Value = codigo;

                prmPass = cmdUsuarioObtener.CreateParameter();
                prmPass.ParameterName = "@pass";
                prmPass.SqlDbType = SqlDbType.VarChar;
                prmPass.Value = password;

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Parameters.Add(prmPass);

                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                AutentificacionBE alumno;
                alumno = new AutentificacionBE();

                while (drUsuarioObtener.Read())
                {

                    alumno.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    alumno.nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nombre"));
                    alumno.codigo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("codigo"));
                    alumno.periodo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("periodo"));

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return alumno;


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
