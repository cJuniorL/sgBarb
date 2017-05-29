using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class EntradaProduto
    {
        public int id { get; set; }

        public float valorUni { get; set; }

        public int quantidade { get; set; }

        public int produtoID { get; set; }

        public int compraID { get; set; }
    }
}