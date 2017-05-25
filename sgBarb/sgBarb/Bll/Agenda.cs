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

        public void addParameters(SqlCommand command, Model.Agenda agenda)
        {
            command.Parameters.AddWithValue("horarioInicio", agenda.horarioInicio.Hour + ":" + agenda.horarioInicio.Minute);
            command.Parameters.AddWithValue("duracao", agenda.duracao.Hour + ":" + agenda.duracao.Minute);
            command.Parameters.AddWithValue("data", agenda.data.Date);
            command.Parameters.AddWithValue("encaixe", agenda.encaixe);
            command.Parameters.AddWithValue("clienteID", agenda.clienteID);
            command.Parameters.AddWithValue("funcionarioID", agenda.funcionarioID);
        }
    }
}