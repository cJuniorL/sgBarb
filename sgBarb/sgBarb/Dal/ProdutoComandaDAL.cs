using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class ProdutoComandaDAL
    {
        public static void insert(Model.ProdutoComanda produtComanda)
        {
            Bll.ProdutoComandaBLL produtoComandaBLL = new Bll.ProdutoComandaBLL();
            produtoComandaBLL.insert(produtComanda);
        }
        
        public static List<Model.ProdutoComanda> selectByComandaID(int idComanda)
        {
            Bll.ProdutoComandaBLL produtoComandaBLL = new Bll.ProdutoComandaBLL();
            return produtoComandaBLL.selectByComandaID(idComanda);
        }

        public static Model.ProdutoComanda selectByID(int id)
        {
            Bll.ProdutoComandaBLL produtoComandaBLL = new Bll.ProdutoComandaBLL();
            return produtoComandaBLL.selectByID(id);
        }

        public static void update(Model.ProdutoComanda produtoComanda)
        {
            Bll.ProdutoComandaBLL produtoComandaBLL = new Bll.ProdutoComandaBLL();
            produtoComandaBLL.update(produtoComanda);
        }

        public static void delete(int produtoComandaID)
        {
            Bll.ProdutoComandaBLL produtoComandaBLL = new Bll.ProdutoComandaBLL();
            produtoComandaBLL.delete(produtoComandaID);
        }
    }
}