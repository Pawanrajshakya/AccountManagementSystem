using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class Account : Audit
    {
        
        public string AccountNo { get; set; }

        [ForeignKey("ClientId")]
        public Client Client{ get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; private set; }

        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; }

        public int AccountTypeId { get; set; }

        public bool IsMain { get; set; } //One client can have multiple account

        #region Detail
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        [MaxLength(55)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Address1 { get; set; }

        [MaxLength(255)]
        public string Address2 { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(20)]
        public string ZipCode { get; set; }

        public Relationship Relationship { get; set; }

        public int RelationshipId { get; set; } //Relationship with main account
        #endregion

        //public List<Transaction> Transactions { get; set; }

        public int Order { get; set; }
    }
}