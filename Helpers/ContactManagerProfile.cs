using AutoMapper;
using ContactManager.Dtos;
using ContactManager.Models;

namespace ContactManager.Helpers
{
    public class ContactManagerProfile : Profile
    {
        public ContactManagerProfile()
        {
            this.CreateMap<Contact, ContactDto>().ReverseMap();

            this.CreateMap<Address, AddressDto>().ReverseMap();
            this.CreateMap<Telephone, TelephoneDto>();
            this.CreateMap<TelephoneDto, Telephone>();
        }
    }
}
