using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Funcoes
{
    public class Relatorios
    {
        public static void listarProduto()
        {
            string arq = @"c:\Relatorio\relProd.html";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(arq))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"estilo.css\" rel=\"stylesheet\">");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th colspan=\"5\">");
                sw.WriteLine("<h1> Relatorio de Produtos </h1>");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th> Produto </th> <th> Tipo </th> <th> Quantidade </th> <th> Valor de Venda </th>");
                sw.WriteLine("</tr>");
                List<Model.Produto> lstProduto = Dal.ProdutoDAL.select().OrderBy(p => p.descr).ToList();
                for (int i = 0; i < lstProduto.Count; i++)
                {
                    sw.Write("<tr>");
                    sw.WriteLine("<td> " + lstProduto[i].descr + "</td>");
                    sw.WriteLine("<td>" + Dal.TipoProdutoDAL.select().First(p => p.id == lstProduto[i].tipoProdutoID).descr + "</td>");
                    sw.WriteLine("<td>" + lstProduto[i].quantidade + "</td>");
                    sw.WriteLine("<td> R$ " + lstProduto[i].valorVenda.ToString("0.00") + "</td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arq);
        }

        public void listarServico()
        {
            string arq = @"c:\Relatorio\relServico.html";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(arq))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"estilo.css\" rel=\"stylesheet\">");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th colspan=\"2\">");
                sw.WriteLine("<h1> Relatorio de Produtos </h1>");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th> Serviço </th> <th> Valor </th>");
                sw.WriteLine("</tr>");
                List<Model.Servico> lstServico = Dal.SerivcoDAL.select().OrderBy(p => p.descr).ToList();
                for (int i = 0; i < lstServico.Count; i++)
                {
                    sw.Write("<tr>");
                    sw.WriteLine("<td> " + lstServico[i].descr + "</td>");
                    sw.WriteLine("<td> R$ " + lstServico[i].valor.ToString("0.00") + "</td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arq);

        }

        public void listarFornecedor()
        {
            string arq = @"c:\Relatorio\relServico.html";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(arq))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"estilo.css\" rel=\"stylesheet\">");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th colspan=\"2\">");
                sw.WriteLine("<h1> Relatorio de Produtos </h1>");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th> Serviço </th> <th> Valor </th>");
                sw.WriteLine("</tr>");
                List<Model.Servico> lstServico = Dal.SerivcoDAL.select().OrderBy(p => p.descr).ToList();
                for (int i = 0; i < lstServico.Count; i++)
                {
                    sw.Write("<tr>");
                    sw.WriteLine("<td> " + lstServico[i].descr + "</td>");
                    sw.WriteLine("<td> R$ " + lstServico[i].valor.ToString("0.00") + "</td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arq);

        }

        public static void imprimirAgenda(int funcionarioID, DateTime dia)
        {
            string arq = @"c:\Relatorio\relCompra.html";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(arq))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"estilo.css\" rel=\"stylesheet\">");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th colspan=\"5\">");
                List<Model.Agenda> lstAgenda = sgBarb.Dal.AgendaDAL.select().Where(f => f.data == dia && f.funcionarioID == funcionarioID).OrderBy(t => t.getHora()).ThenBy(t => t.getMinuto()).ThenBy(t => !t.encaixe).ToList();
                sw.WriteLine("<h1> Relatorio de Agenda - " + Dal.FuncionarioDAL.selectById(funcionarioID).nome + "</h1>");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th> Cliente </th> <th> Horário Inicio </th> <th> Horário Término</th> <th> Encaixe</th>");
                sw.WriteLine("</tr>");
                for (int i = 0; i < lstAgenda.Count; i++)
                {
                    sw.Write("<tr>");
                    sw.WriteLine("<td> " + Dal.ProdutoDAL.selectByID(lstEntradaProduto[i].produtoID).descr + "</td>");
                    sw.WriteLine("<td>" + Dal.TipoProdutoDAL.select().First(p => p.id == Dal.ProdutoDAL.selectByID(lstEntradaProduto[i].produtoID).tipoProdutoID).descr + "</td>");
                    sw.WriteLine("<td>" + lstEntradaProduto[i].quantidade + "</td>");
                    sw.WriteLine("<td> R$ " + lstEntradaProduto[i].valorUni.ToString("0.00") + "</td>");
                    sw.WriteLine("<td> R$ " + (lstEntradaProduto[i].valorUni * lstEntradaProduto[i].quantidade).ToString("0.00") + "</td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("<h3> Total: R$" + lstEntradaProduto.Sum(s => s.quantidade * s.valorUni) + "</h3>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arq);
        }

        public static void listarCompra(int compraID)
        {
            string arq = @"c:\Relatorio\relCompra.html";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(arq))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"estilo.css\" rel=\"stylesheet\">");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th colspan=\"5\">");
                Model.Compra compra = Dal.CompraDAL.selectByID(compraID);
                sw.WriteLine("<h1> Relatorio de Compra - " + compra.dataCompra.ToShortDateString() + "</h1>");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th> Produto </th> <th> Tipo </th> <th> Quantidade Comprada</th> <th> Valor Uni </th> <th> Valor Total </th>");
                sw.WriteLine("</tr>");
                List<Model.EntradaProduto> lstEntradaProduto = Dal.EntradaProdutoDAL.selectCompraID(compraID).OrderBy(c => Dal.ProdutoDAL.selectByID(c.produtoID).descr).ToList();
                for (int i = 0; i < lstEntradaProduto.Count; i++)
                {
                    sw.Write("<tr>");
                    sw.WriteLine("<td> " + Dal.ProdutoDAL.selectByID(lstEntradaProduto[i].produtoID).descr + "</td>");
                    sw.WriteLine("<td>" + Dal.TipoProdutoDAL.select().First(p => p.id == Dal.ProdutoDAL.selectByID(lstEntradaProduto[i].produtoID).tipoProdutoID).descr + "</td>");
                    sw.WriteLine("<td>" + lstEntradaProduto[i].quantidade + "</td>");
                    sw.WriteLine("<td> R$ " + lstEntradaProduto[i].valorUni.ToString("0.00") + "</td>");
                    sw.WriteLine("<td> R$ " + (lstEntradaProduto[i].valorUni * lstEntradaProduto[i].quantidade).ToString("0.00") + "</td>");
                    sw.WriteLine("</tr>");
                }
                sw.WriteLine("</table>");
                sw.WriteLine("<h3> Total: R$" + lstEntradaProduto.Sum(s => s.quantidade * s.valorUni) + "</h3>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arq);
        }

        public static void relatorioCliente(int clienteID)
        {
            string arq = @"c:\Relatorio\relCliente.html";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(arq))
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<link href=\"estilo.css\" rel=\"stylesheet\">");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<table>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th colspan=\"2\">");
                Model.Cliente cliente = Dal.ClienteDAL.selectById(clienteID);
                sw.WriteLine("<h1> Relatorio de Cliente - " + cliente.nome + "</h1>");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Nome </th> <td>" + cliente.nome + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Gênero </th> <td>" + (cliente.sexo ? "Masculino" : "Feminino")   + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Nascimento </th> <td>" + cliente.nascimento.ToShortDateString() + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Telefone </th> <td>" + cliente.telefone + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Celular </th> <td>" + cliente.celular + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Cidade </th> <td>" + Dal.CidadeDAL.select().First( c=> c.id == cliente.cidadeID).nome + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Cep </th> <td>" + cliente.cep + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Bairro </th> <td>" + cliente.bairro + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Rua </th> <td>" + cliente.rua + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Num </th> <td>" + cliente.num + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> CPF </th> <td>" + cliente.cpf + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Rg </th> <td>" + cliente.rg + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Email </th> <td>" + cliente.email + "</td>");
                sw.WriteLine("</tr>");
                sw.WriteLine("<tr>");
                sw.WriteLine("<th class=\"width:33%\"> Credito </th> <td> R$" + cliente.credito.ToString("0.00") + "</td>");
                sw.WriteLine("</tr>");

                sw.WriteLine("</table>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arq);
        }
    }
}
