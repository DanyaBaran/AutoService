using AutoService.Shared.Models;
using AutoService.Shared.Interfaces;

namespace AuthService.Api.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByNameAndPassword(string name, string password);
        User GetUserByName(string name);
    }
}
