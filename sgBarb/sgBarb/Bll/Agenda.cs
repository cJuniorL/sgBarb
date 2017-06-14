using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class Agenda
    {
        public void insert(Model.Agenda agenda)
        {
            string sql = "INSERT INTO agenda Values(@horarioInicio, @duracao, @data, @encaixe, @clienteID, @funcionarioID)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            addParameters(command, agenda);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro de inserção na agenda");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public List<Model.Agenda> select()
        {
            string sql = "SELECT * FROM agenda";
            List<Model.Agenda> lstAgenda = new List<Model.Agenda>();
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Agenda agenda = new Model.Agenda();
                    agenda.id = Convert.ToInt32(reader["id"]);
                    agenda.duracao = Convert.ToString(reader["duracao"]);
                    agenda.horarioInicio = Convert.ToString(reader["horarioInicio"]);

                    agenda.data = Convert.ToDateTime(reader["data"]);
                    agenda.encaixe = Convert.ToBoolean(reader["encaixe"]);
                    agenda.clienteID = Convert.ToInt32(reader["clienteID"]);
                    agenda.funcionarioID = Convert.ToInt32(reader["funcionarioID"]);
                    lstAgenda.Add(agenda);
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Agenda");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstAgenda;
        }

        public void addParameters(SqlCommand command, Model.Agenda agenda)
        {
            command.Parameters.AddWithValue("horarioInicio", agenda.horarioInicio);
            command.Parameters.AddWithValue("duracao", agenda.duracao);
            command.Parameters.AddWithValue("data", agenda.data.Date);
            command.Parameters.AddWithValue("encaixe", agenda.encaixe);
            command.Parameters.AddWithValue("clienteID", agenda.clienteID);
            command.Parameters.AddWithValue("funcionarioID", agenda.funcionarioID);
        }

        public void remove(int agendaID)
        {
            string sql = "DELETE agenda where id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", agendaID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção de agenda");
            }
            finally
            {
                conexao.Dispose();
            }

        }
    }
}