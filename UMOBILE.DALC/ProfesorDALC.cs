using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMOBILE.BL.BE;
using System.Data.SqlClient;
using System.Data;

namespace UMOBILE.DL.DALC
{
    public class ProfesorDALC
    {
        public List<ProfesorBE> GetProfesor(string Curso_id, string Periodo_id, string Seccion_id)
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
                sCadenaConeccion = UMOBILE.DALC.Properties.Settings.Default.csDesarrollo;
                Conn = new SqlConnection(sCadenaConeccion);
                sqlUsuarioObtener = "usps_ProfesorObtener";
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

                ProfesorBE Profesor;
                Profesor = new ProfesorBE();

                while (drUsuarioObtener.Read())
                {

                    Profesor.id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    Profesor.nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nombre"));
                    Profesor.correo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("email"));
                    Profesor.cursoid = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("Curso_id"));
                    Profesor.seccion = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("Seccion_id"));


                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                List<ProfesorBE> widget = new List<ProfesorBE>();

                widget.Add(Profesor);

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
