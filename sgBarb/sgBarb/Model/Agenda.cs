using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Agenda
    {
        public int id { get; set; }

        public DateTime horarioInicio { get; set; }

        public DateTime duracao { get; set; }

        public DateTime data { get; set; }

        public bool encaixe { get; set; }

        public int clienteID { get; set; }

        public int funcionarioID { get; set; }

    }
}