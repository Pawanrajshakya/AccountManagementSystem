using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IAccountTypeRepository : IRepository<AccountType>
    {
        Task<bool> AccountTypeExists(string description);
    }
}