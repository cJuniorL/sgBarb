using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class FuncionarioBLL
    {
        public void insert(Model.Funcionario funcionario)
        {
            string sql = "INSERT INTO Funcionario VALUES (@nome, @sexo, @nascimento, @cep, @bairro, @rua, @num, @cpf, @rg, @email, @salario, @comissao, @cidadeID)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            commandAdd(command, funcionario);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.Write("Erro na inserção de funcionário.");
            }
            conexao.Dispose();
        }

        public void update(Model.Funcionario funcionario)
        {
            string sql = "UPDATE Funcionario SET nome=@nome, sexo=@sexo, nascimento=@nascimento, cep=@cep, bairro=@bairro, rua=@rua, num@num, cpf=@cpf, rg=@rg, email=@email, salario=@salario, comissao=@comissao, cidadeID=@cidadeID WHERE id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            commandAdd(command, funcionario);
            command.Parameters.AddWithValue("id", funcionario.id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de funcionário");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public Model.Funcionario selectById(int funcionarioID)
        {
            string sql = "SELECT * FROM funcionario where id=@id";
            Model.Funcionario funcionario = new Model.Funcionario();
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", funcionarioID);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (reader.Read())
                    funcionario = getFuncionario(reader);
            }
            catch
            {
                Console.WriteLine("Erro na seleção de funcionario");
            }
            finally
            {
                conexao.Dispose();
            }
            return funcionario;
        }

        public List<Model.Funcionario> select()
        {
            string sql = "SELECT * FROM funcionario;";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            List<Model.Funcionario> lstFuncionario = new List<Model.Funcionario>();
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    lstFuncionario.Add(getFuncionario(reader));
                }
            }
            catch
            {
                Console.WriteLine("Erro na selçeão de funcionáio");
            }
            conexao.Dispose();
            return lstFuncionario;
        }

        public List<Model.Funcionario> selectIdNome()
        {
            string sql = "SELECT id, nome FROM funcionario;";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            List<Model.Funcionario> lstFuncionario = new List<Model.Funcionario>();
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Funcionario funcionario = new Model.Funcionario();
                    funcionario.id = Convert.ToInt32(reader["id"]);
                    funcionario.nome = reader["nome"].ToString();
                    lstFuncionario.Add(funcionario);
                }
            }
            catch
            {
                Console.WriteLine("Erro na selçeão de funcionáio");
            }
            conexao.Dispose();
            return lstFuncionario;
        }

        public void delete(int funcionarioID)
        {
            string sql = "DELETE funcionario where id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", funcionarioID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção do funcionário");
            }
            finally
            {
                conexao.Dispose();
            }
        }


        private Model.Funcionario getFuncionario(SqlDataReader reader)
        {
            Model.Funcionario funcionario = new Model.Funcionario();
            funcionario.id = Convert.ToInt32(reader["id"]);
            funcionario.nome = reader["nome"].ToString();
            funcionario.sexo = Convert.ToBoolean(reader["sexo"]);
            funcionario.nascimento = Convert.ToDateTime(reader["nascimento"]);
            funcionario.cep = Convert.ToString(reader["cep"]);
            funcionario.bairro = Convert.ToString(reader["bairro"]);
            funcionario.rua = Convert.ToString(reader["rua"]);
            funcionario.num = Convert.ToInt32(reader["num"]);
            funcionario.cpf = Convert.ToString(reader["cpf"]);
            funcionario.rg = Convert.ToString(reader["rg"]);
            funcionario.email = Convert.ToString(reader["email"]);
            funcionario.salario = Convert.ToSingle(reader["salario"]);
            funcionario.comissao = Convert.ToSingle(reader["comissao"]);
            funcionario.cidadeID = Convert.ToInt32(reader["cidadeID"]);
            return funcionario;
        }

        public void commandAdd(SqlCommand command, Model.Funcionario funcionario)
        {
            command.Parameters.AddWithValue("nome", funcionario.nome);
            command.Parameters.AddWithValue("sexo", funcionario.sexo);
            command.Parameters.AddWithValue("nascimento", funcionario.nascimento);
            command.Parameters.AddWithValue("cep", funcionario.cep);
            command.Parameters.AddWithValue("bairro", funcionario.bairro);
            command.Parameters.AddWithValue("rua", funcionario.rua);
            command.Parameters.AddWithValue("num", funcionario.num);
            command.Parameters.AddWithValue("cpf", funcionario.cpf);
            command.Parameters.AddWithValue("rg", funcionario.rg);
            command.Parameters.AddWithValue("email", funcionario.email);
            command.Parameters.AddWithValue("salario", funcionario.salario);
            command.Parameters.AddWithValue("comissao", funcionario.comissao);
            command.Parameters.AddWithValue("cidadeID", funcionario.cidadeID);
        }
    }
}