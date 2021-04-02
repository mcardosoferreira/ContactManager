using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Address
    {
        public Address() {}

        public Address(int id, string bairro, string cidade, string estado, string complemento)
        {
            Id = id;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            this.Complemento = complemento;
        }

        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
