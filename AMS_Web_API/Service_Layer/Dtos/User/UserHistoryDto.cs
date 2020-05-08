using System;

namespace Service_Layer.Dtos
{
    public class UserHistoryDto
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
        public byte[] RowVersion { get; set; }
    }
}