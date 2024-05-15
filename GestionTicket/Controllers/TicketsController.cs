using GestionTicket.Models.Ticket;
using GestionTicket.Repositories.Ticket;
using GestionTicket.Repositories.User;
using Microsoft.AspNetCore.Mvc;

namespace GestionTicket.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class TicketsController : ControllerBase
   {
      private ITicketRepository _ticketRepository;
      public TicketsController(ITicketRepository ticketRepository)
      {
         _ticketRepository = ticketRepository;
      }

      [HttpGet("")]
      public IActionResult GetTicket()
      {
         return Ok(_ticketRepository.GetAllTickets());
      }

      [HttpGet("/{id}")]
      public IActionResult GetTicket(int id)
      {
         return Ok(_ticketRepository.GetTicketsById(id));
      }

      [HttpPost("")]
      public IActionResult CreateTicket(Ticket ticket)
      {
         _ticketRepository.CreateTicket(ticket);
         return Ok();
      }

      [HttpPut("/{id}/assign/{userId}")]
      public IActionResult ModifyTicket(int id,int userId)
      {
         _ticketRepository.ModifyTicketOfUser(id,userId);
         return Ok();
      }

      [HttpDelete("{id}")]
      public IActionResult DeleteTicket(int id)
      {
         _ticketRepository.DeleteTicketById(id);
         return Ok();
      }
   }
}
