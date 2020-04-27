using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;

namespace Persistence_Layer.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ClientExists(string name)
        {
            if (await _dbContext.Clients.AnyAsync(x => x.Name == name))
                return true;

            return false;
        }
    }
}