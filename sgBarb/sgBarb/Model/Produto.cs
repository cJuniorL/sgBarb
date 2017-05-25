using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Produto
    {
        public int id { get; set; }

        public string descr { get; set; }

        public float valorVenda { get; set; }

        public int quantidade { get; set; }

        public int tipoProdutoID { get; set; }  
    }
}