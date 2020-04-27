using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class RelationshipDto
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}