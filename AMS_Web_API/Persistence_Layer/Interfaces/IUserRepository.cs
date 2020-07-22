using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserRoles(int id);
    }
}