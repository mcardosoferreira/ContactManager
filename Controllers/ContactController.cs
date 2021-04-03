using AutoMapper;
using ContactManager.Data.Repositories;
using ContactManager.Dtos;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {

        public readonly IRepository _repository;
        public readonly IMapper _mapper;

        public ContactController(IRepository repository, IMapper mapper) {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IActionResult> Index(string searchString, int tipoBusca)
        {
            var result = await _repository.GetAllContactsAsync();
            if (!String.IsNullOrEmpty(searchString) && tipoBusca == 1)
            {
                result = await _repository.GetContactsByNameAsync(searchString);
            }
            else if(!String.IsNullOrEmpty(searchString) && tipoBusca == 2)
            {
                result = await _repository.GetContactsByPhoneAsync(searchString);
            }
            var contactResult = _mapper.Map<IEnumerable<ContactDto>>(result);
            return View(contactResult);
        }        

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
                return BadRequest("Contato não encontrado.");

            var contactResult = _mapper.Map<ContactDto>(contact);
            return Ok(contactResult);
        }
        public ActionResult Create()
        {
            var model = new ContactDto();
            return View(model);
        }
        

        [HttpPost]
        public ActionResult Create(ContactDto contact)
        {
            var contactResult = _mapper.Map<Contact>(contact);

            _repository.Add(contactResult);
            if (_repository.SaveChanges())
            {
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        public ActionResult Edit(int id)
        {            
            var contactResult = _repository.GetContactById(id);
            if (contactResult == null)
            {
                return BadRequest("Contato não encontrado.");
            }
            var contactDto = _mapper.Map<ContactDto>(contactResult);            
            return View(contactDto);
        }
                
        [HttpPost]
        public ActionResult Edit(ContactDto contactDto)
        {
            var contactResult = _repository.GetContactById(contactDto.Id);
            if(contactResult == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            var contact = _mapper.Map<Contact>(contactDto);

            _repository.Update(contact);
             if(_repository.SaveChanges())
            {
                return RedirectToAction("Index");
            }
            return BadRequest("Contato não atualizado.");
        }      

        public ActionResult Delete(int id)
        {

            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return BadRequest("Contato não encontrado.");
            }
            var contactDto = _mapper.Map<ContactDto>(contact);

            return View(contactDto);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            _repository.Delete(contact);
            if (_repository.SaveChanges())
            {
                return RedirectToAction("Index");
            }
            return BadRequest("Contado não foi deletado.");
        }

        public ActionResult Details(int id)
        {            

            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return BadRequest("Contato não encontrado.");
            }   

            var contactDto = _mapper.Map<ContactDto>(contact);           
            
            

            return View(contactDto);
        }
    }
}
