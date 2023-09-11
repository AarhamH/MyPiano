using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IUserRepository
    {
        UserModel Build(UserModel user);
        UserModel GetByEmail(string email);

        UserModel GetById(int id);
    }
}
