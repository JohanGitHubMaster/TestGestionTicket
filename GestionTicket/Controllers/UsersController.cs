using GestionTicket.Models.User;
using GestionTicket.Repositories.Ticket;
using GestionTicket.Repositories.User;
using Microsoft.AspNetCore.Mvc;

namespace GestionTicket.Controllers
{  
   [ApiController]
   [Route("[controller]")]
   public class UsersController : ControllerBase
   {
      private IUserRepository _userRepository;
      private ITicketRepository _ticketRepository;
      public UsersController(IUserRepository userRepository,ITicketRepository ticketRepository)
      {
         _userRepository = userRepository;
         _ticketRepository = ticketRepository;
      }
      [HttpGet("")]
      public IActionResult GetUsers()
      {
         return Ok(_userRepository.GetAllUsers());
      }
      [HttpGet("/{id}/ticket")]
      public IActionResult GetUsers(int id)
      {
         return Ok(_ticketRepository.GetTicketOfUsersById(id));
      }

      [HttpPost("")]
      public IActionResult CreateUsers(User user)
      {
         user.Tickets = null;
         _userRepository.CreateUser(user);
         return Ok();
      }

      [HttpPut("/{id}")]
      public IActionResult ModifyUser(int id,User user)
      {
         user.Id = id;
         _userRepository.ModifyUser(id,user);
         return Ok();
      }

      [HttpDelete("/{id}")]
      public IActionResult DeleteUser(int id)
      {
         _userRepository.RemoveUser(id);
         return Ok();
      }
   }
}
