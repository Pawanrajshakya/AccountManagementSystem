using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IRoleRepository: IRepository<Role>
    {
         Task<bool> RoleExists(string description);
    }
}