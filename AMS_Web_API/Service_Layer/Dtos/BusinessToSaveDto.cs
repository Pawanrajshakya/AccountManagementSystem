using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class BusinessToSaveDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address1 is required")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required(ErrorMessage = "State is required")]
        [MaxLength(2, ErrorMessage="State length must be 2"), MinLength(2)]
        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        [MaxLength(5)]
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } 
    }
}