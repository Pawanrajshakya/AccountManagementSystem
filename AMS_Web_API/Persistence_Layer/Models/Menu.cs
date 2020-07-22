using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Menu : Audit
    {
        [Required]
        public string Title { get; set; }
        public string Link { get; set; }
        public string IconName { get; set; }
        public int MainMenuId { get; set; }
        public int SortId { get; set; }
        public string UserRoles { get; set; }
    }
}