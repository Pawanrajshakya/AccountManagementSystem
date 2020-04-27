using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Business : Audit
    {
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Address1 { get; set; }

        [MaxLength(255)]
        public string Address2 { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(5)]
        public string ZipCode { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}