using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class UserHistoryRepository : Repository<UserHistory>, IUserHistoryRepository
    {
        public UserHistoryRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}