using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using proyecto_Practica01_.Domain;
namespace proyecto_Practica01_.Data.Utilities
{
    public class DataHelper
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
        public bool ExecuteSPNonQuery(string sp, List<ParameterSP>? param = null)
        {
            bool result;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = sp;
                if (param != null)
                {
                    foreach (ParameterSP p in param)
                        {
                            cmd.Parameters.AddWithValue(p.Name, p.Valor);
                        }
                }
                int filasAfectadas = cmd.ExecuteNonQuery();
                result = filasAfectadas > 0;


            }
            catch (SqlException ex)
            {
                result = false;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
        public bool ExecuteTransaction(Factura factura)
        {
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                var cmd = new SqlCommand("SP_INSERTAR_FACTURA", _connection, transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@id_forma_pago", factura.FormaPago.id);
                cmd.Parameters.AddWithValue("@id_cliente", factura.Cliente.Id);


                SqlParameter paramOut = new SqlParameter("@ultimoId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramOut);

                int affectedRows = cmd.ExecuteNonQuery();
                int ultimoId = (cmd.Parameters["@ultimoId"].Value != DBNull.Value)
                               ? (int)cmd.Parameters["@ultimoId"].Value
                               : -1;
                if (affectedRows <= 0 )
                {
                    transaction.Rollback();
                    return false;
                }
                foreach (DetalleFactura df in factura.Detalle)
                {
                    SqlCommand cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE_FACTURA", _connection, transaction);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_articulo", df.Articulo.Id_articulo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", df.cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", df.precio);
                    cmdDetalle.Parameters.AddWithValue("@id_factura", ultimoId);

                    int affectedRowsDetalle = cmdDetalle.ExecuteNonQuery();
                    if (affectedRowsDetalle <= 0)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}
