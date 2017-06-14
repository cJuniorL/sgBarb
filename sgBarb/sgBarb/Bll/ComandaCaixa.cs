using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ComandaCaixa
    {
        public void insert(Model.ComandaCaixa comandaCaixa)
        {
            string sql = "INSERT INTO ComandaCaixa VALUES(@valorPago, @caixaID, @comandaID)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("valorPago", comandaCaixa.valorPago);
            command.Parameters.AddWithValue("caixaID", comandaCaixa.caixaID);
            command.Parameters.AddWithValue("comandaID", comandaCaixa.comandaID);
            command.ExecuteNonQuery();
            conexao.Dispose();
        }

        public List<Model.ComandaCaixa> select()
        {
            List<Model.ComandaCaixa> lstComandaCaixa = new List<Model.ComandaCaixa>();
            string sql = "SELECT * FROM ComandaCaixa";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Model.ComandaCaixa comandaCaixa = new Model.ComandaCaixa();
                comandaCaixa.id = Convert.ToInt32(reader["id"]);
                comandaCaixa.valorPago = Convert.ToSingle(reader["valorPago"]);
                comandaCaixa.caixaID = Convert.ToInt32(reader["caixaID"]);
                comandaCaixa.comandaID = Convert.ToInt32(reader["comandaID"]);
                lstComandaCaixa.Add(comandaCaixa);
            }
            conexao.Dispose();
            return lstComandaCaixa;
        }

        public Model.ComandaCaixa selectById(int id)
        {
            string sql = "SELECT * FROM ComandaCaixa WHERE id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", id);
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            reader.Read();
            Model.ComandaCaixa comandaCaixa = new Model.ComandaCaixa();
            comandaCaixa.id = Convert.ToInt32(reader["id"]);
            comandaCaixa.valorPago = Convert.ToSingle(reader["valorPago"]);
            comandaCaixa.caixaID = Convert.ToInt32(reader["caixaID"]);
            comandaCaixa.comandaID = Convert.ToInt32(reader["comandaID"]);
            conexao.Dispose();
            return comandaCaixa;
        }
    }
}