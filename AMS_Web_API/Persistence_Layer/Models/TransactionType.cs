using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class TransactionType : Audit
    {
        public string Description { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}