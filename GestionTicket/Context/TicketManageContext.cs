using GestionTicket.Models.Ticket;
using GestionTicket.Models.User;
using Microsoft.EntityFrameworkCore;

namespace GestionTicket.Context
{
   public class TicketManageContext : DbContext
   {
      public TicketManageContext(DbContextOptions<TicketManageContext> options) : base(options)
      {
      }
      public DbSet<User> Users { get; set; }
      public DbSet<Ticket> Tickets { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {

      }
   }
}
