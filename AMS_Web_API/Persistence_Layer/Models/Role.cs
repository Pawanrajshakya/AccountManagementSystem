using System.Collections.Generic;

namespace Persistence_Layer.Models
{
    public class Role: Audit
    {
        public Role()
        {
            UserRole = new List<UserRole>();
        }
        public string Description { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}