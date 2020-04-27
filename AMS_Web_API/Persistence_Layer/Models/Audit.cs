using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class Audit
    {
        public Audit()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedBy = 0;
            this.LastModifiedDate = DateTime.Now;
            this.LastModifiedBy = 0;
            this.IsActive = true;
            this.IsVisible = true;
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public bool IsVisible { get; set; }

        public bool IsActive { get; set; }
        //Handling Concurrency with the Entity Framework 6 in an ASP.NET MVC 5 Application (10 of 12)

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}