using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class AccountHistoryRepository : Repository<AccountHistory>, IAccountHistoryRepository
    {
        public AccountHistoryRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}