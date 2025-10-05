using Microsoft.AspNetCore.Mvc;

namespace TareaTecWebGrupo12.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController:ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
