using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public UserModel Build(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public UserModel GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public UserModel GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
