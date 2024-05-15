using GestionTicket.Models.User;
using GestionTicket.Repositories.Ticket;
using GestionTicket.Repositories.Token;
using GestionTicket.Repositories.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace GestionTicket.Controllers
{  
   [ApiController]
   [Route("[controller]")]
   public class UsersController : ControllerBase
   {
      private IUserRepository _userRepository;
      private ITicketRepository _ticketRepository;
      private Token _token;
      public UsersController(IUserRepository userRepository,ITicketRepository ticketRepository, Token token)
      {
         _userRepository = userRepository;
         _ticketRepository = ticketRepository;
         _token = token;
      }
      [HttpGet("")]
      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      public IActionResult GetUsers()
      {
         return Ok(_userRepository.GetAllUsers());
      }
      [HttpGet("/{id}/ticket")]
      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      public IActionResult GetUsers(int id)
      {
         return Ok(_ticketRepository.GetTicketOfUsersById(id));
      }

      [HttpPost("")]
      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      public IActionResult CreateUsers(User user)
      {
         user.Tickets = null;
         _userRepository.CreateUser(user);
         return Ok();
      }

      [HttpPut("/{id}")]
      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      public IActionResult ModifyUser(int id,User user)
      {
         user.Id = id;
         _userRepository.ModifyUser(id,user);
         return Ok();
      }

      [HttpDelete("/{id}")]
      [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      public IActionResult DeleteUser(int id)
      {
         _userRepository.RemoveUser(id);
         return Ok();
      }

      [HttpGet("GetToken")]
      [Produces("application/json")]
      public async Task<IActionResult> GenerateToken()
      {
         try
         {

            string token = _token.GenerateTokenAsync();
            var response = new
            {
               Token = token
            };
            return Ok(response);
         }
         catch
         {
            return StatusCode(StatusCodes.Status500InternalServerError, "Une erreur s'est produite lors de la génération du jeton.");
         }

      }

   }
}
