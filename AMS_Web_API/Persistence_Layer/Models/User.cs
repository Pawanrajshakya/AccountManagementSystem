using System.Collections.Generic;

namespace Persistence_Layer.Models
{
    public class User: Audit
    {
        public User()
        {
            UserRole = new List<UserRole>();
        }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public virtual List<UserRole> UserRole { get; set; }
    }
}