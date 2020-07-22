using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos.Menu
{
    public class MenuToSaveDto
    {
        [Required]
        public string Title { get; set; }
        public string Link { get; set; }
        public string IconName { get; set; }
        public int MainMenuId { get; set; }
        public int SortId { get; set; }
        public string UserRoles { get; set; }
        public bool IsActive { get; set; }
    }
}