using System.Collections.Generic;

namespace Service_Layer.Dtos.Menu
{
    public class MenusDto
    {
        public List<MenuDto> Menus { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}