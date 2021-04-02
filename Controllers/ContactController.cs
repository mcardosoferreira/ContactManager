using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        public ContactController() { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            return Ok("get funciona");
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {            
            return BadRequest("Acessou o post");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Contact model)
        {            
            return BadRequest("Acessou o put");
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Contact model)
        {           
            return BadRequest("Acessou o patch");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
            return BadRequest("Acessou o delete");
        }
    }
}
