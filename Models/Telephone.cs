namespace ContactManager.Models
{
    public class Telephone
    {
        public Telephone() { }

        public Telephone(int id, int contactId, string number)
        {
            this.Id = id;
            this.ContactId = contactId;
            this.Number = number;
        }

        public int Id { get; set; }

        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
        public string Number { get; set; }

    }
}
