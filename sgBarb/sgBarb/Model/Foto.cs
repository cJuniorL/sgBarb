using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Foto
    {
        public int id { get; set; }

        public string imagem { get; set; }

        public DateTime data { get; set; }

        public int clienteID { get; set; }

    }
}