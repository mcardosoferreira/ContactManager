using AutoMapper;
using ContactManager.Data.Repositories;
using ContactManager.Dtos;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {

        public readonly IRepository _repository;
        public readonly IMapper _mapper;

        public ContactController(IRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public async Task<IActionResult> Index(string searchString, int tipoBusca)
        {
            IEnumerable<Contact> result = await this._repository.GetAllContactsAsync();
            if (!string.IsNullOrEmpty(searchString) && tipoBusca == 1)
            {
                result = await this._repository.GetContactsByNameAsync(searchString);
            }
            else if (!string.IsNullOrEmpty(searchString) && tipoBusca == 2)
            {
                result = await this._repository.GetContactsByPhoneAsync(searchString);
            }
            IEnumerable<ContactDto> contactResult = this._mapper.Map<IEnumerable<ContactDto>>(result);
            return this.View(contactResult);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Contact contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return this.BadRequest("Contato não encontrado.");
            }

            ContactDto contactResult = this._mapper.Map<ContactDto>(contact);
            return this.Ok(contactResult);
        }
        public ActionResult Create(string[] DynamicTextBox)
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
                return this.BadRequest("Contato não encontrado.");
            }
            ContactDto contactDto = this._mapper.Map<ContactDto>(contactResult);
            return this.View(contactDto);
        }

        [HttpPost]
        public ActionResult Edit(ContactDto contactDto)
        {
            Contact contactResult = this._repository.GetContactById(contactDto.Id);
            if (contactResult == null)
            {
                return this.BadRequest("Contato não encontrado.");
            }

            Contact contact = this._mapper.Map<Contact>(contactDto);

            this._repository.Update(contact);
            if (this._repository.SaveChanges())
            {
                return this.RedirectToAction("Index");
            }
            return this.BadRequest("Contato não atualizado.");
        }

        public ActionResult Delete(int id)
        {

            Contact contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return this.BadRequest("Contato não encontrado.");
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
                return this.BadRequest("Contato não encontrado.");
            }

            this._repository.Delete(contact);
            if (this._repository.SaveChanges())
            {
                return this.RedirectToAction("Index");
            }
            return this.BadRequest("Contado não foi deletado.");
        }

        public ActionResult Details(int id)
        {

            Contact contact = this._repository.GetContactById(id);
            if (contact == null)
            {
                return this.BadRequest("Contato não encontrado.");
            }

            ContactDto contactDto = this._mapper.Map<ContactDto>(contact);



            return this.View(contactDto);
        }
    }
}
