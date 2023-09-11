using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) 
        {
            _context = context;
        }

        public UserModel Create(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
