using AutoMapper;
using ContactManager.Data.Repositories;
using ContactManager.Domain.Models;
using ContactManager.Infrastructure.DataContracts;
using ContactManager.Infrastucture.Internacionalization;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        public readonly IRepository _repository;
        public readonly IMapper _mapper;
        public readonly IContactsService _contactsService;

        public ContactController(IRepository repository, IMapper mapper, IContactsService contactsService)
        {
            this._mapper = mapper;
            this._repository = repository;
            this._contactsService = contactsService;
        }

        public async Task<IActionResult> Index(string? searchString, int typeSearch = 1)
        {
            IEnumerable<ContactDto> contacts = await this._contactsService.GetAllAsync(searchString, typeSearch);
            return this.View(contacts);
        }
        public ActionResult Create()
        {
            var model = new ContactDto();
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(ContactDto contact, string submitButton)
        {
            Contact contactResult = this._mapper.Map<Contact>(contact);

            switch (submitButton)
            {
                case "New Telephone":
                    {
                        contact.Telephones.Add(null);
                        return this.View(contact);
                    }
                case "Salvar Contato":
                    {
                        this._repository.Add(contactResult);
                        if (this._repository.SaveChanges())
                        {
                            return this.RedirectToAction("Index");
                        }
                        break;
                    }
            }

            return this.View(contact);
        }

        public ActionResult Edit(int id)
        {
            Contact contactResult = this._repository.GetContactById(id);
            if (contactResult == null)
            {
                return this.NotFound(Messages.CONTACT_NOT_FOUND);
            }
            ContactDto contactDto = this._mapper.Map<ContactDto>(contactResult);
            return this.View(contactDto);
        }

        [HttpPost]
        public ActionResult Edit(ContactDto contactDto, string submitButton)
        {
            Contact contactResult = this._repository.GetContactById(contactDto.Id);
            if (contactResult == null)
            {
                return this.NotFound("Contato não encontrado.");
            }
            switch (submitButton)
            {
                case "New Telephone":
                    {
                        contactDto.Telephones.Add(null);
                        return this.View(contactDto);
                    }
                case "Save changes":
                    {
                        Contact contact = this._mapper.Map<Contact>(contactDto);

                        foreach (Telephone item in contact.Telephones.ToList())
                        {
                            if (item.Number == null)
                            {
                                contact.Telephones.Remove(item);
                            }
                        }

                        this._repository.Update(contact);
                        if (this._repository.SaveChanges())
                        {
                            return this.RedirectToAction("Index");
                        }
                        break;
                    }
            }
            return this.View(contactDto);
        }

        public ActionResult Delete(int id)
        {

            Contact contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return this.NotFound("Contato não encontrado.");
            }
            ContactDto contactDto = this._mapper.Map<ContactDto>(contact);

            return this.View(contactDto);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return this.NotFound("Contato não encontrado.");
            }

            this._repository.Delete(contact);
            if (this._repository.SaveChanges())
            {
                return this.RedirectToAction("Index");
            }
            return this.BadRequest("Contato não foi deletado.");
        }

        public ActionResult Details(int id)
        {

            Contact contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return this.NotFound("Contato não encontrado.");
            }

            ContactDto contactDto = this._mapper.Map<ContactDto>(contact);

            return this.View(contactDto);
        }
    }
}
