﻿namespace GestionTicket.Models.Ticket
{
   using GestionTicket.Models.User;
   public class Ticket
   {
      public required int Id { get; set; }
      public required string Title { get; set; }
      public required string Description { get; set; }
      public required string Status { get; set; }
      public int UserId { get; set; }
      public required User User { get; set; }
   }
}
