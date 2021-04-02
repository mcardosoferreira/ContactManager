namespace ContactManager.Models
{
    public class Address
    {
        public Address() { }

        public Address(int id, string Neighborhood, string city, string state, string complement)
        {
            this.Id = id;
            this.Neighborhood = Neighborhood;
            this.City = city;
            this.State = state;
            this.Complement = complement;
        }

        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }

        public Contact Contact { get; set; }
    }
}
