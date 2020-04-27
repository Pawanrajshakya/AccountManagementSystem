using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
         Task<bool> AccountExists(string name);
    }
}