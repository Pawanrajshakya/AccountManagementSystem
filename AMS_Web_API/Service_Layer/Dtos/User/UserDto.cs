using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            UserRole = new List<RoleDto>();
        }
        public int Id { get; set; }
        [MinLength(6, ErrorMessage = "Minimum length for username is 6")]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public List<RoleDto> UserRole { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int PasswordChangedCount { get; set; }
        public System.DateTime LastPasswordChangedOn { get; set; }
    }

    
}