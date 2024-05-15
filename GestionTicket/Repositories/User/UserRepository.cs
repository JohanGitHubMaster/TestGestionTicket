namespace GestionTicket.Repositories.User;

using GestionTicket.Context;
using Microsoft.EntityFrameworkCore;
using Models.User;
public class UserRepository : IUserRepository
{
   private TicketManageContext _ticketManageContext;
   public UserRepository(TicketManageContext ticketManageContext)
   {
      _ticketManageContext = ticketManageContext;
   }
   public List<User> GetAllUsers()
   {
      return _ticketManageContext
               .Users
               .AsNoTracking()
               .ToList();
   }
   public void CreateUser(User user)
   {
       _ticketManageContext
               .Users
               .Add(user);
      _ticketManageContext.SaveChanges();
   }

   public void ModifyUser(int userId,User user)
   {
       user.Id = userId;
      _ticketManageContext
              .Users
              .Update(user);
      _ticketManageContext.SaveChanges();
   }

   public void RemoveUser(int userId)
   {
      User usertodelete = _ticketManageContext.Users.FirstOrDefault(x => x.Id == userId);
      _ticketManageContext
              .Users
              .Remove(usertodelete);
      _ticketManageContext.SaveChanges();
   }

   public int GetIdUserByName(string username)
   {
      return _ticketManageContext.Users.FirstOrDefault(x=>x.UserName==username).Id;
   }
}
