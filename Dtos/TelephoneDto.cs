namespace ContactManager.Dtos
{
    public class TelephoneDto
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        public virtual ContactDto Contact { get; set; }
        public string Number { get; set; }
    }
}
