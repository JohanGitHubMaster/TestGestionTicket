﻿namespace GetionTicket.Web.Models.Ticket
{
   public class Ticket
   {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string Status { get; set; }
      public int? UserId { get; set; }
   }
}
