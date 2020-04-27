using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IBusinessRepository: IRepository<Business>
    {
         Task<bool> BusinessExists(string name);
    }
}