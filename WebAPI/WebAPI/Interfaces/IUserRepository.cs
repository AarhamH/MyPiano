using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IUserRepository
    {
        UserModel Create(UserModel user);
    }
}
