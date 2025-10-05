using apiwithdb.Models.dtos;
using apiwithdb.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiwithdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;
        public EventsController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _service.GetAll();
            return Ok(item);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var anEvent = await _service.GetById(id);
            return anEvent == null
                ? NotFound(new { error = "Event not found", status = 404 })
                : Ok(anEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var anEvent = await _service.Create(dto);
                return CreatedAtAction(nameof(GetOne), new { id = anEvent.Id }, anEvent);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message, status = 400 });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}