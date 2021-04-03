using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContactManager.Dtos;
using ContactManager.Models;

namespace ContactManager.Helpers
{
    public class ContactManagerProfile : Profile
    {
        public ContactManagerProfile()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Telephone, TelephoneDto>();
            CreateMap<TelephoneDto, Telephone>();
        }
    }
}
