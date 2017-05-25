using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ClienteBLL
    {
        public void insert(Model.Cliente cliente)
        {
            string sql = "INSERT INTO CLIENTE VALUES (@nome, @sexo, @telefone, @celular, @nascimento, @cep,  @bairro, @rua, @num, @cpf, @rg, @email, @credito, @observacao, @cidadeID)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            commandAdd(command, cliente);

            command.ExecuteNonQuery();
            conexao.Dispose();
        }

        public void update(Model.Cliente cliente)
        {
            string sql = "UPDATE cliente SET nome=@nome, sexo=@sexo, telefone=@telefone, celular=@celular, nascimento=@nascimento, cep=@cep,  bairro=@bairro, rua=@rua, num=@num, cpf=@cpf, rg=@rg, email=@email, credito=@credito, observacao=@observacao, cidadeID=@cidadeID WHERE id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            commandAdd(command, cliente);
            command.Parameters.AddWithValue("id", cliente.id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de Cliente");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public void delete(int clienteID)
        {
            string sql = "DELETE cliente where id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", clienteID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Cliente");
            }
            finally
            {
                conexao.Dispose();
            }

        }

        public Model.Cliente selectById(int clienteID)
        {
            string sql = "SELECT * FROM CLIENTE WHERE ID=@id";
            Model.Cliente cliente = new Model.Cliente();
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", clienteID);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                reader.Read();
                cliente = getReaderCliente(reader);
            }
            catch
            {
                Console.WriteLine("Erro na seleção de cliente");
            }
            return cliente;
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

        public List<Model.Cliente> selectIdNome()
        {
            List<Model.Cliente> lstCliente = new List<Model.Cliente>();
            string sql = "SELECT id, nome FROM CLIENTE";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Cliente cliente = new Model.Cliente();
                    cliente.id = Convert.ToInt32(reader["id"]);
                    cliente.nome = Convert.ToString(reader["nome"]);
                    lstCliente.Add(cliente);
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
            cliente.cep = Convert.ToString(reader["cep"]);
            cliente.rua = Convert.ToString(reader["rua"]);
            cliente.bairro = Convert.ToString(reader["bairro"]);
            cliente.num = Convert.ToInt32(reader["num"]);
            cliente.cpf = Convert.ToString(reader["cpf"]);
            cliente.rg = Convert.ToString(reader["rg"]);
            cliente.email = Convert.ToString(reader["email"]);
            cliente.credito = Convert.ToInt32(reader["credito"]);
            cliente.observacao = Convert.ToString(reader["observacao"]);
            cliente.cidadeID = Convert.ToInt32(reader["cidadeID"]);
            return cliente;
        }

        public void commandAdd(SqlCommand command, Model.Cliente cliente)
        {
            command.Parameters.AddWithValue("nome", cliente.nome);
            command.Parameters.AddWithValue("sexo", Convert.ToInt32(cliente.sexo));
            command.Parameters.AddWithValue("telefone", cliente.telefone);
            command.Parameters.AddWithValue("celular", cliente.celular);
            command.Parameters.AddWithValue("nascimento", cliente.nascimento);
            command.Parameters.AddWithValue("cep", cliente.cep);
            command.Parameters.AddWithValue("bairro", cliente.bairro);
            command.Parameters.AddWithValue("rua", cliente.rua);
            command.Parameters.AddWithValue("num", cliente.num);
            command.Parameters.AddWithValue("cpf", cliente.cpf);
            command.Parameters.AddWithValue("rg", cliente.rg);
            command.Parameters.AddWithValue("email", cliente.email);
            command.Parameters.AddWithValue("credito", cliente.credito);
            command.Parameters.AddWithValue("observacao", cliente.observacao);
            command.Parameters.AddWithValue("cidadeID", cliente.cidadeID);
        }
    }
}