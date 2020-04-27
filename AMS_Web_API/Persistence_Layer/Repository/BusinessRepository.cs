using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class BusinessRepository : Repository<Business>, IBusinessRepository
    {
        public BusinessRepository(DataContext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> BusinessExists(string name)
        {
            if (await _dbContext.Businesses.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }
    }
}