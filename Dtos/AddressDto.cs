namespace ContactManager.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }

        public ContactDto Contact { get; set; }
    }
}
