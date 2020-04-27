using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IClientRepository: IRepository<Client>
    {
         Task<bool> ClientExists(string name);
         
    }
}