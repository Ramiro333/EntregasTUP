using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
namespace proyecto_Practica01_.Data
{
    internal class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;
        private DataHelper()
        {
            _connection = new SqlConnection(properties.Resources.CadenaConexionPC);
        }
        public static DataHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable ExecuteSPQuery(string sp, List<ParameterSP>? param = null)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                if (param != null)
                {
                    foreach (ParameterSP p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            return dt;
        }
        public int ExecuteSPNonQuery(string sp, List<ParameterSP>? param = null)
        {
            int filasAfectadas = 0;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                if (param != null)
                {
                    foreach (ParameterSP p in param)
                        {
                            cmd.Parameters.AddWithValue(p.Name, p.Valor);
                        }
                }
                filasAfectadas = cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                filasAfectadas = 0;
            }
            finally
            {
                _connection.Close();
            }
            return filasAfectadas;
        }

    }
}
