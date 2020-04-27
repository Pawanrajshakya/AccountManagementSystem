using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> GroupExists(string description)
        {
            if (await _dbContext.Groups.AnyAsync(x => x.Description == description))
                return true;

            return false;
        }
    }
}