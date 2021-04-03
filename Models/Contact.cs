using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Contact
    {
        public Contact(){ }
        public Contact(int id, string name, string lastName, string email, DateTime birthDate, int? addressId)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            AddressId = addressId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public virtual IList<Telephone> Telephones { get; set; }

    }
}
