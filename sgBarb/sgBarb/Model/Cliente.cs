using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Model
{
    public class Cliente
    {
        public int id { get; set; }

        public string nome { get; set; }

        public bool  sexo { get; set; } //True = .|. ~ False = (|)

        public string telefone { get; set; }

        public string celular { get; set; }

        public DateTime nascimento { get; set; }

        public string cep { get; set; }

        public string rua { get; set; }

        public string bairro { get; set; }

        public int num { get; set; }

        public string cpf { get; set; }

        public string rg { get; set; }

        public string email { get; set; }

        public float credito { get; set; }

        public string observacao { get; set; }

        public int cidadeID { get; set; }

    }
}