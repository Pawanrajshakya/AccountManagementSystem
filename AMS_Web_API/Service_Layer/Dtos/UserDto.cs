using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            UserRole = new List<int>();
        }
        public int Id { get; set; }
        [MinLength(6, ErrorMessage = "Minimum length for username is 6")]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        [Required]
        public List<int> UserRole { get; set; }
        public bool IsActive { get; set; }
    }
}