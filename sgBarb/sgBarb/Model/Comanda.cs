using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Comanda
    {
        public int id { get; set; }
       
        public DateTime dataCompra { get; set; }

        public float valorTotal { get; set; }

        public float descontoTotal { get; set; }

        public bool aberta { get; set; }

        public int clienteID { get; set; }

        public int funcionarioID { get; set; }
    }
}