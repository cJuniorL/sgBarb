using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class CaixaBLL
    {
        public void insert(Model.Caixa caixa)
        {
            string sql = "INSERT INTO Caixa VALUES(@dataAbertura, @dataFechamento, @aberto)";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("dataAbertura", caixa.dataAbertura);
            command.Parameters.AddWithValue("dataFechamento", caixa.dataFechamento);
            command.Parameters.AddWithValue("aberto", Convert.ToInt32(caixa.aberto));
            command.ExecuteNonQuery();
            conexao.Dispose();
        }

        public List<Model.Caixa> select()
        {
            List<Model.Caixa> lstCaixa = new List<Model.Caixa>();
            string sql = "SELECT * FROM Caixa";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Model.Caixa caixa = new Model.Caixa();
                caixa.id = Convert.ToInt32(reader["id"]);
                caixa.dataAbertura = Convert.ToDateTime(reader["dataAbertura"]);
                caixa.dataFechamento = Convert.ToDateTime(reader["dataFechamento"]);
                caixa.aberto = Convert.ToBoolean(reader["aberto"]);
                lstCaixa.Add(caixa);
            }
            conexao.Dispose();
            return lstCaixa;
        }

        public Model.Caixa selectById(int idCaixa)
        {
            string sql = "SELECT * FROM Caixa where id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", idCaixa);
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            reader.Read();
            Model.Caixa caixa = new Model.Caixa();
            caixa.id = Convert.ToInt32(reader["id"]);
            caixa.dataAbertura = Convert.ToDateTime(reader["dataAbertura"]);
            caixa.dataFechamento = Convert.ToDateTime(reader["dataFechamento"]);
            caixa.aberto = Convert.ToBoolean(reader["aberto"]);
            conexao.Dispose();
            return caixa;
        }

        public void update(Model.Caixa caixa)
        {
            string sql = "UPDATE caixa SET dataFechamento=@dataFechamento, aberto=@aberto where id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("dataFechamento", caixa.dataFechamento);
            command.Parameters.AddWithValue("aberto", Convert.ToInt32(caixa.aberto));
            command.Parameters.AddWithValue("id", caixa.id);
            command.ExecuteNonQuery();
            conexao.Dispose();
        }
    }
}