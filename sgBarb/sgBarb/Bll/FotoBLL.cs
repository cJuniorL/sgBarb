using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class FotoBLL
    {
        public void insert(Model.Foto foto)
        {
            string sql = "INSERT INTO Foto VALUES (@imagem, @clienteID, @data)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("imagem", foto.imagem);
            command.Parameters.AddWithValue("data", foto.data.ToShortDateString());
            command.Parameters.AddWithValue("clienteID", foto.clienteID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Imagem");
            }
            finally
            {
                conexao.Dispose();
            }
        }
        public List<Model.Foto> select()
        {
            string sql = "SELECT * FROM Foto";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            List<Model.Foto> lstFoto = new List<Model.Foto>();
            //try
            //{
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Model.Foto foto = new Model.Foto();
                    foto.id = Convert.ToInt32(reader["id"]);
                    foto.data = Convert.ToDateTime(reader["data"]);
                    foto.imagem = Convert.ToString(reader["imagem"]);
                    foto.clienteID = Convert.ToInt32(reader["clienteID"]);
                    lstFoto.Add(foto);
                }
            //}
            //catch
            //{
                Console.WriteLine("Erro na seleção de foto");
            //}
            //finally
            //{
                conexao.Dispose();
            //}
            return lstFoto;
        }
    }

}