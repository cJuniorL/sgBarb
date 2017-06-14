using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class ComandaCaixa
    {
        public int id { get; set; }

        public float valorPago { get; set; }

        public int caixaID { get; set; }

        public int comandaID { get; set; }
    }
}