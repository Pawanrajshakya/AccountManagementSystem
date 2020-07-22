using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class AccountTypeToSaveDto
    {
        [Required(ErrorMessage="Description is required.")]
        public string Description { get; set; }
        public int SortId { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }
    }
}