using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class ComandaServico
    {
        public int id { get; set; }

        public float valorServico { get; set; }

        public float desconto { get; set; }

        public int funcionarioID { get; set; }

        public int servicoID { get; set; }

        public int comandaID { get; set; }

    }
}