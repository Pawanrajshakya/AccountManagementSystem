using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> RoleExists(string description)
        {
            if (await _dbContext.Roles.AnyAsync(x => x.Description == description))
                return true;

            return false;
        }
    }
}