using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class AccountTypeRepository : Repository<AccountType>, IAccountTypeRepository
    {
        public AccountTypeRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AccountTypeExists(string description)
        {
            if (await _dbContext.AccountTypes.AnyAsync(x => x.Description == description))
                return true;

            return false;
        }
    }
}