using System;

namespace Service_Layer.Dtos
{
    public class AccountHistoryDto
    {
        public int id { get; set; }
        public string AccountNo { get; set; }
        public int ClientId { get; set; }
        public decimal Balance { get; private set; }
        public int AccountTypeId { get; set; }
        public bool IsMain { get; set; } //One client can have multiple account
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int RelationshipId { get; set; } //Relationship with main account
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