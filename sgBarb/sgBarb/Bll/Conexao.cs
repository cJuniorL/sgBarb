using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class Conexao
    {
        private SqlConnection connection;

        public Conexao()
        {
            this.connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=sgBarb;Integrated Security=True");
            connection.Open();
        }

        public SqlConnection getConexao()
        {
            return connection;
        }

        public void Dispose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}