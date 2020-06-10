using System.Collections.Generic;

namespace Persistence_Layer.Models
{
    public class User : Audit
    {
        public User()
        {
            UserRole = new List<UserRole>();
        }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public int PasswordChangedCount { get; set; }
        public System.DateTime LastPasswordChangedOn { get; set; }

    }
}