using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IGroupRepository: IRepository<Group>
    {
         Task<bool> GroupExists(string description);
    }
}