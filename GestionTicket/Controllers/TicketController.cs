using Microsoft.AspNetCore.Mvc;

namespace GestionTicket.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class TicketController : ControllerBase
   {
      [HttpGet("Index")]
      public IActionResult Index()
      {
         return Ok();
      }
      [HttpGet("GetTicket")]
      public IActionResult GetTicket()
      {
         return Ok();
      }
   }
}
