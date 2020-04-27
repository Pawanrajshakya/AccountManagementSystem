using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class AccountType: Audit
    {
        public string Description { get; set; }
        public int Order { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public int GroupId { get; set; }
    }
}