using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ChangePasswordDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}