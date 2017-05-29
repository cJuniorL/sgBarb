using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class CompraBll
    {
        public int insert(Model.Compra compra)
        {
            string sql = "INSERT INTO compra VALUES (@dataCompra, @fornecedorID) SET @ID = SCOPE_IDENTITY();";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("dataCompra", compra.dataCompra);
            command.Parameters.AddWithValue("fornecedorID", compra.fornecedorID);
            SqlParameter IDParameter = new SqlParameter("@ID", SqlDbType.Int);  
            IDParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(IDParameter);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de compra");
            }
            finally
            {
                conexao.Dispose();
            }
            return (int)IDParameter.Value;
        }

        public List<Model.Compra> select()
        {
            string sql = "SELECT * FROM Compra";
            List<Model.Compra> lstCompra = new List<Model.Compra>();
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Compra compra = new Model.Compra();
                    compra.id = Convert.ToInt32(reader["id"]);
                    compra.fornecedorID = Convert.ToInt32(reader["fornecedorID"]);
                    compra.dataCompra = Convert.ToDateTime(reader["dataCompra"]);
                    lstCompra.Add(compra);
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de compra");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstCompra;
        }

        public Model.Compra selectById(int compraID)
        {
            string sql = "SELECT * FROM Compra WHERE id=@id";
            Model.Compra compra = new Model.Compra();
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", compraID);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                reader.Read();
                compra.id = Convert.ToInt32(reader["id"]);
                compra.fornecedorID = Convert.ToInt32(reader["fornecedorID"]);
                compra.dataCompra = Convert.ToDateTime(reader["dataCompra"]);
            }
            catch
            {
                Console.WriteLine("Erro na seleção de compra");
            }
            finally
            {
                conexao.Dispose();
            }
            return compra;
        }
    }
}