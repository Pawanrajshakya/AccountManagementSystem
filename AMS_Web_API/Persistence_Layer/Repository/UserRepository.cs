using System.Threading.Tasks;
using Persistence_Layer.Data;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence_Layer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserRoles(int id)
        {
            List<Role> roles = new List<Role>();
            return await _dbContext.Users.Include(x=>x.UserRole).SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _dbContext.Users.AnyAsync(x => x.UserName == username))
                return true;

            return false;
        }
    }
}