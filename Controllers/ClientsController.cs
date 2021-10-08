using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PwC.OnlineAssessment.API.Entities;
using PwC.OnlineAssessment.API.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PwC.OnlineAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository  clientsRepository;
        public ClientsController(IClientsRepository clientsRepository)
        {
            this.clientsRepository = clientsRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await clientsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var client = await clientsRepository.Get(id);
            if (client == null) { return NotFound(); }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Client client)
        {
            if (client==null || !ModelState.IsValid) { return BadRequest(); }

            await clientsRepository.Create(client);
                        
            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Client client)
        {
            if (client == null || id != client.Id  || !ModelState.IsValid) { return BadRequest(); }

            var currentClient = await clientsRepository.Get(id);            
            if (currentClient == null) { return NotFound(); }

            await clientsRepository.Update(currentClient, client);
            return Ok(client);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var currentClient = await clientsRepository.Get(id);
            if (currentClient == null) { return NotFound(); }

            await clientsRepository.Delete(currentClient);
            return Ok();
        }
    }
}
