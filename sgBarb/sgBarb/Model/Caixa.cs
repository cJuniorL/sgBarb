using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Caixa
    {
        public int id { get; set; }

        public DateTime dataAbertura { get; set; }

        public DateTime dataFechamento { get; set; }

        public bool aberto { get; set; }
    }
}