
namespace GestionTicket.Models.User;
using GestionTicket.Models.Ticket;

public class User
{
   public required int Id { get; set; }
   public required string UserName { get; set; }
   public required string Email { get; set; }
   public required List<Ticket>? Tickets { get; set; }
}
