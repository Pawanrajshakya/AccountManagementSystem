using System;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class TransactionToSaveDto
    {
        [Required]
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        [MaxLength(255)]
        public string Description1 { get; set; }
        [MaxLength(255)]
        public string Description2 { get; set; }
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; }
    }
}