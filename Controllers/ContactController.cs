using AutoMapper;
using ContactManager.Data.Repositories;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        public readonly IRepository _repository;
        public readonly IMapper _mapper;

        public ContactController(IRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetAllContactsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
                return BadRequest("Contato não encontrado.");
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            _repository.Add(contact);
            if (_repository.SaveChanges())
            {
                return Ok(contact);
            }
            return BadRequest("Contato não adicionado.");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Contact model)
        {
            var contact = _repository.GetContactById(id);
            if(contact == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            _repository.Update(model);
             if(_repository.SaveChanges())
            {
                return Ok(model);
            }
            return BadRequest("Contato não atualizado.");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Contact model)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return BadRequest("Contato não encontrado.");
            }

            _repository.Update(model);
            if (_repository.SaveChanges())
            {
                return Ok(model);
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
