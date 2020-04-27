using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class TransactionTypeRepository : Repository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> TransactionTypeExists(string description)
        {
            if (await _dbContext.TransactionTypes.AnyAsync(x => x.Description == description))
                return true;

            return false;
        }
    }
}