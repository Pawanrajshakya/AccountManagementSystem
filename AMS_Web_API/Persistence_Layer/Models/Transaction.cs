using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Persistence_Layer.Interfaces;

namespace Persistence_Layer.Models
{
    public class Transaction : Audit, ITransaction
    {
        //[Required(ErrorMessage = "Date is required.")]
        public DateTime TransactionDate { get; set; }

        //[Range(1, 100000000,
        //ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Amount { get; set; }

        [MaxLength(255)]
        public string Description1 { get; set; }

        [MaxLength(255)]
        public string Description2 { get; set; }

        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }

        public int TransactionTypeId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        
        public int AccountId { get; set; }

    }
}