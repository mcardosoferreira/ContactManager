using AutoMapper;
using ContactManager.Data.Repositories;
using ContactManager.Domain.Models;
using ContactManager.Infrastructure.DataContracts;
using ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Create()
        {
            var model = new ContactDto();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(ContactDto contact, string submitButton)
        {
            ContactDto contactResult = this._contactsService.Create(contact, submitButton);

            return this.RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
          
            ContactDto contactResult = this._contactsService.Edit(id);
            return this.View(contactResult);
        }

        [HttpPost]
        public IActionResult Edit(ContactDto contactDto, string submitButton)
        {
            ContactDto contactDtoResult = this._contactsService.EditConfirm(contactDto, submitButton);
            return this.View(contactDtoResult);
        }

        public IActionResult Delete(int id)
        {
            ContactDto contactDto = this._contactsService.Delete(id);

            return this.View(contactDto);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            this._contactsService.DeleteConfirmed(id);
            return this.RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            ContactDto contactDto = this._contactsService.Details(id);

            return this.View(contactDto);
        }
    }
}
