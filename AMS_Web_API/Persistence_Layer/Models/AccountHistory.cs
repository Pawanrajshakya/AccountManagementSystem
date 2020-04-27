using System;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class AccountHistory
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; private set; }

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

        public int RelationshipId { get; set; } //Relationship with main account
        #endregion
        
        public int Order { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public bool IsVisible { get; set; }

        public bool IsActive { get; set; }

        public byte[] RowVersion { get; set; }
    }
}