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
    public class CursoDALC
    {
        public List<CursoBE> GetCursosPorAlumno(string codigo, string periodo)
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
                sqlUsuarioObtener = "usps_CursosMatriculados";
                cmdUsuarioObtener = Conn.CreateCommand();
                cmdUsuarioObtener.CommandText = sqlUsuarioObtener;
                cmdUsuarioObtener.CommandType = CommandType.StoredProcedure;

                prmCodAlumno = cmdUsuarioObtener.CreateParameter();
                prmCodAlumno.ParameterName = "@codigo";
                prmCodAlumno.SqlDbType = SqlDbType.VarChar;
                prmCodAlumno.Value = codigo;

                prmCiclo = cmdUsuarioObtener.CreateParameter();
                prmCiclo.ParameterName = "@ciclo";
                prmCiclo.SqlDbType = SqlDbType.Int;
                prmCiclo.Value = Convert.ToInt32(periodo);

                cmdUsuarioObtener.Parameters.Add(prmCodAlumno);
                cmdUsuarioObtener.Parameters.Add(prmCiclo);
                cmdUsuarioObtener.Connection.Open();
                drUsuarioObtener = cmdUsuarioObtener.ExecuteReader();

                CursoBE curso;
                List<CursoBE> lstcurso = new List<CursoBE>();
                FuncionesDALC funciones = new FuncionesDALC();

                while (drUsuarioObtener.Read())
                {
                    curso = new CursoBE();
                    curso.Id = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("id"));
                    curso.Nombre = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("nombre"));
                    curso.Codigo = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("codigo"));
                    curso.Creditos = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("creditos"));
                    curso.Seccion = drUsuarioObtener.GetString(drUsuarioObtener.GetOrdinal("seccion"));
                    curso.Nivel = drUsuarioObtener.GetInt32(drUsuarioObtener.GetOrdinal("nivel"));
                    curso.Promedio = funciones.Promedio_Uno(curso.Id.ToString());
                    curso.Peso = funciones.Peso_Uno(curso.Id.ToString());
                    lstcurso.Add(curso);

                }

                cmdUsuarioObtener.Connection.Close();
                cmdUsuarioObtener.Dispose();
                Conn.Dispose();

                return lstcurso;

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
