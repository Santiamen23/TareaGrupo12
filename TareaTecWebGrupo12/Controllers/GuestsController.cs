using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TareaTecWebGrupo12.Models.dtos;
using TareaTecWebGrupo12.Services;

namespace TareaTecWebGrupo12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _service;

        public GuestsController(IGuestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guests = await _service.GetAll();
            return Ok(guests);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var guest = await _service.GetById(id);
            return guest == null
                ? NotFound(new { error = "Guest not found", status = 404 })
                : Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            try
            {
                var guest = await _service.Create(dto);
                return CreatedAtAction(nameof(GetOne), new { id = guest.Id }, guest);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message, status = 400 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message, status = 500 });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Guest not found", status = 404 });
        }
    }
}
