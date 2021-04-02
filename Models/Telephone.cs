using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Telephone
    {
        public Telephone(){}

        public Telephone(int id, int contactId, string number)
        {
            Id = id;
            ContactId = contactId;            
            Number = number;
        }

        public int Id { get; set; }

        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }        
        public string Number { get; set; }
       
    }
}
