using System;

namespace Persistence_Layer.Models
{
    public class UserHistory
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; }
        public int PasswordChangedCount { get; set; }
        public System.DateTime LastPasswordChangedOn { get; set; }
    }
}