using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                comandText = "USP_GetProductos";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, comandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Nombre = reader["Nombre"] != null ? Convert.ToString(reader["Nombre"]) : String.Empty,
                            Precio = reader["Precio"] != null ? Convert.ToDecimal(reader["Precio"]) : 0,
                            EsActivo = reader["EsActivo"] != null ? Convert.ToBoolean(reader["EsActivo"]) : true,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productos;
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_InsProductos";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                parameters[0].Value = producto.Nombre;
                parameters[1] = new SqlParameter("@Precio", SqlDbType.Decimal);
                parameters[1].Value = producto.Precio;
                parameters[2] = new SqlParameter("@EsActivo", SqlDbType.Bit);
                parameters[2].Value = producto.EsActivo;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdProductos";
                parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@IdProducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                parameters[1].Value = producto.Nombre;
                parameters[2] = new SqlParameter("@Precio", SqlDbType.Decimal);
                parameters[2].Value = producto.Precio;
                parameters[3] = new SqlParameter("@EsActivo", SqlDbType.Bit);
                parameters[3].Value = producto.EsActivo;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DelProductos";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdProducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
