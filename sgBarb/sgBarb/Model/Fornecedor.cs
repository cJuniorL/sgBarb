using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Fornecedor
    {
        public int id { get; set; }

        public string empresa { get; set; }

        public string representante { get; set; }

        public string telefone { get; set; }

        public string celular { get; set; }

        public int cidadeID { get; set; }
    }
}