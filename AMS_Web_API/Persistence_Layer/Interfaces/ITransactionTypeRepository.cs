using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface ITransactionTypeRepository: IRepository<TransactionType>
    {
         Task<bool> TransactionTypeExists(string description);
         
    }
}