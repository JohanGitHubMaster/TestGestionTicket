using GestionTicket.Models.Ticket;
using GestionTicket.Models.User;
using Microsoft.EntityFrameworkCore;

namespace GestionTicket.Context;
using Models.User;
public class TicketManageContext : DbContext
{
   public TicketManageContext(DbContextOptions<TicketManageContext> options) : base(options)
   {
   }
   public DbSet<User> Users { get; set; }
   public DbSet<Ticket> Tickets { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<User>().HasKey(e => e.Id);
      modelBuilder.Entity<User>()
                     .Property(e => e.Id)
                     .ValueGeneratedOnAdd();
      modelBuilder.Entity<User>().
         Property(e => e.UserName)
         .HasMaxLength(800);
      modelBuilder.Entity<User>().
        Property(e => e.Email)
        .HasMaxLength(400);
   }
}
