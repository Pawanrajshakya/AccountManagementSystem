using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}