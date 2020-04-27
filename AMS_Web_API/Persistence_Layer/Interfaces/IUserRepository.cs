using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(string username);
        Task<List<UserRole>> GetUserRoles(int id);
    }
}