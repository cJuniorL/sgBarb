using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class ProdutoDAL
    {
        public static void insert(Model.Produto produto)
        {
            Bll.ProdutoBLL produtoBll = new Bll.ProdutoBLL();
            produtoBll.insert(produto);
        }

        public static List<Model.Produto> select()
        {
            Bll.ProdutoBLL produtoBll = new Bll.ProdutoBLL();
            return produtoBll.select();
        }

        public static void update(Model.Produto produto)
        {
            Bll.ProdutoBLL produtoBll = new Bll.ProdutoBLL();
            produtoBll.update(produto);
        }

        public static void delete(int produtoID)
        {
            Bll.ProdutoBLL produtoBLL = new Bll.ProdutoBLL();
            produtoBLL.delete(produtoID);
        }

        public static Model.Produto selectByID(int produtoID)
        {
            Bll.ProdutoBLL produtoBLL = new Bll.ProdutoBLL();
            return produtoBLL.selectByID(produtoID);    
        }

        public static List<Model.Produto> selectIdDescrByIdTipo(int tipoPodutoID)
        {
            Bll.ProdutoBLL produtoBLL = new Bll.ProdutoBLL();
            return produtoBLL.selectIdDescrByIdTipo(tipoPodutoID);
        }
    }
}