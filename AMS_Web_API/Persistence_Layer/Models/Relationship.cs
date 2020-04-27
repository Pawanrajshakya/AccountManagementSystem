using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Relationship: Audit
    {
        [StringLength(100)]
        [Required]
        public string Description { get; set; }
    }
}