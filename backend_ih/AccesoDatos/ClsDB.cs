using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace backend_ih.AccesoDatos
{
    public class ClsDB
    {
        private SqlConnection conexion = new SqlConnection();

        //Sobrecargas
        public ClsDB()
        {
            var appSettings = ConfigurationManager.AppSettings;

            conexion = new SqlConnection(appSettings["cadenaConexion"]);
            //conexion = new SqlConnection("Data Source=LAPTOP-80MJM6P4\SQLEXPRESS;Initial Catalog=prueba;Persist Security Info=True;User ID=jruiz;Password=jerry153;Connect Timeout=0;Application Name=SPA");
        }

        public DataTable QueryGenerico(string sqlQuery)
        {
            SqlCommand comando = new SqlCommand(sqlQuery, conexion);
            DataTable retorno = new DataTable("dt");
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;

            try
            {
                adaptador.Fill(retorno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                comando.Connection.Close();
            }
            return retorno;
        }

        public DataTable QuerySPconParametros(string sp, List<SqlParameter> args)
        {
            SqlCommand cmd = new SqlCommand(sp, conexion);
            {
                var withBlock = cmd.Parameters;
                foreach (SqlParameter item in args)
                    withBlock.Add(item);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            DataTable tbl = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cmd;

            try
            {
                adap.Fill(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                //EnviarEmail("jruiz@enviacolvanes.com.co", "Error en aplicacion MVC", ex.Message + " (" + sp + ") " + MensajeError(args));
                throw new Exception(ex.Message);
            }
        }
    }
}