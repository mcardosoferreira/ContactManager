namespace ContactManager.Models
{
    public class Address
    {
        public Address() { }

        public Address(int id, string bairro, string cidade, string estado, string complemento)
        {
            this.Id = id;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Complemento = complemento;
        }

        public int Id { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }

        public Contact Contact { get; set; }
    }
}
