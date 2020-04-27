using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class RelationshipRepository : Repository<Relationship>, IRelationshipRepository
    {
        public RelationshipRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> RelationshipExists(string description)
        {
            if (await _dbContext.Relationships.AnyAsync(x => x.Description == description))
                return true;

            return false;
        }
    }
}