using System;
using System.Collections.Generic;

namespace ContactManager.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public int? AddressId { get; set; }
        public AddressDto Address { get; set; }

        public virtual IList<TelephoneDto> Telephones { get; set; }
    }
}
