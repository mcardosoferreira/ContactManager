using AutoMapper;
using ContactManager.Data.Repositories;
using ContactManager.Dtos;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IActionResult> Index()
        {
            var result = await _repository.GetAllContactsAsync();
            var contactResult = _mapper.Map<IEnumerable<ContactDto>>(result);
            return View(contactResult);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetAllContactsAsync();
            var contactResult = _mapper.Map<IEnumerable<ContactDto>>(result);
            return Ok(contactResult);
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

        [HttpPost]
        public IActionResult Post([FromBody]ContactDto contact)
        {
            var contactResult = _mapper.Map<Contact>(contact);

            _repository.Add(contactResult);
            if (_repository.SaveChanges())
            {
                return Ok(contactResult);
            }
            return BadRequest("Contato não adicionado.");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ContactDto contact)
        {
            var contactResult = _repository.GetContactById(id);
            if(contactResult == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            _repository.Update(contact);
             if(_repository.SaveChanges())
            {
                return Ok(contact);
            }
            return BadRequest("Contato não atualizado.");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]ContactDto contact)
        {
            var contactResult = _repository.GetContactById(id);
            if (contactResult == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            _repository.Update(contact);
            if (_repository.SaveChanges())
            {
                return Ok(contact);
            }
            return BadRequest("Contato não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            _repository.Delete(contact);
            if (_repository.SaveChanges())
            {
                return Ok("Contado deletado.");
            }
            return BadRequest("Contado não foi deletado.");
        }
    }
}
