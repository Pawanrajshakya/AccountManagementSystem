using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos.Menu
{
    public class MenuDto
    {
        public MenuDto()
        {
            Roles = new List<RoleDto>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Link { get; set; }
        public string IconName { get; set; }
        public int MainMenuId { get; set; }
        public int SortId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}