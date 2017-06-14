using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class ProdutoComanda
    {
        public int id { get; set; }

        public int quantidade { get; set; }

        public float valorProduto { get; set; }

        public int comandaID { get; set; }

        public int produtoID { get; set; }

        public float desconto { get; set; }

    }
}