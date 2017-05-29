using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class FornecedorBLL
    {
        public void insert(Model.Fornecedor fornecedor)
        {
            string sql = "INSERT INTO fornecedor VALUES (@empresa, @representante, @telefone, @celular, @cidadeID)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            addParameter(command, fornecedor);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Fornecedor");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public void addParameter(SqlCommand command, Model.Fornecedor fornecedor)
        {
            command.Parameters.AddWithValue("empresa", fornecedor.empresa);
            command.Parameters.AddWithValue("representante", fornecedor.representante);
            command.Parameters.AddWithValue("telefone", fornecedor.telefone);
            command.Parameters.AddWithValue("celular", fornecedor.celular);
            command.Parameters.AddWithValue("cidadeID", fornecedor.cidadeID);
        }

        public List<Model.Fornecedor> select()
        {
            List<Model.Fornecedor> lstFornecedor = new List<Model.Fornecedor>();
            string sql = "SELECT * FROM Fornecedor";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    lstFornecedor.Add(getFornecedor(reader));
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Fornecedor");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstFornecedor;
        }

        public List<Model.Fornecedor> selectIdEmpresa()
        {
            List<Model.Fornecedor> lstFornecedor = new List<Model.Fornecedor>();
            string sql = "SELECT id, empresa FROM Fornecedor";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Fornecedor fornecedor = new Model.Fornecedor();
                    fornecedor.id = Convert.ToInt32(reader["id"]);
                    fornecedor.empresa = Convert.ToString(reader["empresa"]);
                    lstFornecedor.Add(fornecedor);
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Fornecedor");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstFornecedor;
        }

        public Model.Fornecedor getFornecedor(SqlDataReader reader)
        {
            Model.Fornecedor fornecedor = new Model.Fornecedor();
            fornecedor.id = Convert.ToInt32(reader["id"]);
            fornecedor.empresa = Convert.ToString(reader["empresa"]);
            fornecedor.representante = Convert.ToString(reader["representante"]);
            fornecedor.telefone = Convert.ToString(reader["telefone"]);
            fornecedor.celular = Convert.ToString(reader["celular"]);
            return fornecedor;
        }

        public Model.Fornecedor selectByID(int fornecedorID)
        {
            Model.Fornecedor fornecedor = new Model.Fornecedor();
            string sql = "SELECT * FROM Fornecedor WHERE id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", fornecedorID);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                reader.Read();
                fornecedor = getFornecedor(reader);
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Fornecedor");
            }
            finally
            {
                conexao.Dispose();
            }
            return fornecedor;
        }
        
        public void delete(int fornecedorID)
        {
            string sql = "DELETE fornecedor where id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", fornecedorID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de Fornecedor");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public void update(Model.Fornecedor fornecedor)
        {
            string sql = "UPDATE fornecedor SET empresa=@empresa, representante=@representante, telefone=@telefone, celular=@celular, cidadeID=@cidadeID WHERE id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            addParameter(command, fornecedor);
            command.Parameters.AddWithValue("id", fornecedor.id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de fornecedor");
            }
            finally
            {
                conexao.Dispose();
            }
        }
    }
}