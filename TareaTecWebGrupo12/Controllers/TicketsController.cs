using Microsoft.AspNetCore.Mvc;
using TareaTecWebGrupo12.Models;
using TareaTecWebGrupo12.Models.dtos;
using TareaTecWebGrupo12.Services;

namespace TareaTecWebGrupo12.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;
        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ticket = await _service.GetById(id);
            return ticket is null? NotFound(new { error = "Ticket not found", status = 404 }) :Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var ticket = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success ?NotFound(new { error = "Ticket not found", status = 404 }):NoContent();
        }
    }
}
