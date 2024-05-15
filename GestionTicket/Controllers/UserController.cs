using Microsoft.AspNetCore.Mvc;

namespace GestionTicket.Controllers
{  
   [ApiController]
   [Route("[controller]")]
   public class UserController : ControllerBase
   {
      public UserController()
      {

      }
      [HttpGet("Index")]
      public IActionResult Index()
      {
         return Ok();
      }
   }
}
