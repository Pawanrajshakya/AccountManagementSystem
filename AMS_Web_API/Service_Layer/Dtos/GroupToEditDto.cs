using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class GroupToEditDto
    {
        [Required]
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}