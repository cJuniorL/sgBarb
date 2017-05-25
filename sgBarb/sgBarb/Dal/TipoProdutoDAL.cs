using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class TipoProdutoDAL
    {
        public static void insert(Model.TipoProduto tipoProduto)
        {
            Bll.TipoProdutoBLL tipoProdutoBLL = new Bll.TipoProdutoBLL();
            tipoProdutoBLL.insert(tipoProduto);
        }

        public static List<Model.TipoProduto> select()
        {
            Bll.TipoProdutoBLL tipoProdutoBLL = new Bll.TipoProdutoBLL();
            return tipoProdutoBLL.select();
        }
    }
}