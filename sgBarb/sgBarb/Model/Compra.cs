using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Compra
    {
        public int id { get; set; }

        public DateTime dataCompra { get; set; }

        public int fornecedorID { get; set; }
    }
}