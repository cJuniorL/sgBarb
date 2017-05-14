using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ClienteBll
    {
        public void insert(Model.Cliente cliente)
        {
            string sql = "INSERT INTO CLIENTE VALUES (@nome, @sexo, @telefone, @celular, @nascimento, @cidadeID, @cep,  @bairro, @rua, @num, @complemento, @cpf, @rg, @email, @credito, @observacao)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            commandAdd(command, cliente);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
               //...
            }
            conexao.Dispose();
        }

        public List<Model.Cliente> select()
        {
            List<Model.Cliente> lstCliente = new List<Model.Cliente>();
            string sql = "SELECT * FROM CLIENTE";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    lstCliente.Add(getReaderCliente(reader));
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na seleção de Genero...");
            }
            conexao.Dispose();

            return (lstCliente);
        }

        public Model.Cliente getReaderCliente(SqlDataReader reader)
        {
            Model.Cliente cliente = new Model.Cliente();
            cliente.id = Convert.ToInt32(reader["id"]);
            cliente.nome = Convert.ToString(reader["nome"]);
            cliente.sexo = Convert.ToBoolean(reader["sexo"]);
            cliente.telefone = Convert.ToString(reader["telefone"]);
            cliente.celular = Convert.ToString(reader["celular"]);
            cliente.nascimento = Convert.ToDateTime(reader["nascimento"]);
            cliente.cidadeID = Convert.ToInt32(reader["cidadeID"]);
            cliente.cep = Convert.ToString(reader["cep"]);
            cliente.rua = Convert.ToString(reader["rua"]);
            cliente.bairro = Convert.ToString(reader["bairro"]);
            cliente.num = Convert.ToInt32(reader["num"]);
            cliente.complemento = Convert.ToString(reader["complemento"]);
            cliente.cpf = Convert.ToString(reader["cpf"]);
            cliente.rg = Convert.ToString(reader["rg"]);
            cliente.email = Convert.ToString(reader["email"]);
            cliente.credito = Convert.ToInt32(reader["credito"]);
            cliente.observacao = Convert.ToString(reader["observacao"]);
            return cliente;
        }

        public void commandAdd(SqlCommand command, Model.Cliente cliente)
        {
            command.Parameters.AddWithValue("nome", cliente.nome);
            command.Parameters.AddWithValue("sexo", cliente.sexo);
            command.Parameters.AddWithValue("telefone", cliente.telefone);
            command.Parameters.AddWithValue("celular", cliente.celular);
            command.Parameters.AddWithValue("nascimento", cliente.nascimento);
            command.Parameters.AddWithValue("cidadeID", cliente.cidadeID);
            command.Parameters.AddWithValue("cep", cliente.cep);
            command.Parameters.AddWithValue("bairro", cliente.bairro);
            command.Parameters.AddWithValue("rua", cliente.rua);
            command.Parameters.AddWithValue("num", cliente.num);
            command.Parameters.AddWithValue("complemento", cliente.complemento);
            command.Parameters.AddWithValue("cpf", cliente.cpf);
            command.Parameters.AddWithValue("rg", cliente.rg);
            command.Parameters.AddWithValue("email", cliente.email);
            command.Parameters.AddWithValue("credito", cliente.credito);
            command.Parameters.AddWithValue("observacao", cliente.observacao);
        }
    }
}