using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Funcionario
    {
        public int id { get; set; }

        public string nome { get; set; }

        public bool sexo { get; set; }

        public DateTime nascimento { get; set; }

        public string cep { get; set; }

        public string bairro { get; set; }

        public string rua { get; set; }
            
        public int num { get; set; }

        public string cpf { get; set; }

        public string rg { get; set; }

        public string email { get; set; }

        public float salario { get; set; }

        public float comissao { get; set; }
       
        public int cidadeID;
    }
}       