namespace Persistence_Layer.Models
{
    public class UserRole
    {
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}