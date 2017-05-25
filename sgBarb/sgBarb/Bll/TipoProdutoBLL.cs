using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class TipoProdutoBLL
    {
        public void insert(Model.TipoProduto tipoProduto)
        {
            string sql = "INSERT INTO TipoProduto VALUES (@descr)";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("descr", tipoProduto.descr);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Tipo de Produo");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public List<Model.TipoProduto> select()
        {
            List<Model.TipoProduto> lstTipoProduto = new List<Model.TipoProduto>();
            string sql = "SELECT * FROM TipoProduto";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            //try
            //{
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.TipoProduto tipoProduto = new Model.TipoProduto();
                    tipoProduto.id = Convert.ToInt32(reader["id"]);
                    tipoProduto.descr = Convert.ToString(reader["descr"]);
                    lstTipoProduto.Add(tipoProduto);
                }
            //}
            //catch
            //{
                Console.WriteLine("Erro na seleção de tipo de produto");
            //}
            //finally
            //{
                conexao.Dispose();
            //}
            return lstTipoProduto;
        }
    }
}