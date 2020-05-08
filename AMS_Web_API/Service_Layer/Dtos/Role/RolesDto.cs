using System.Collections.Generic;

namespace Service_Layer.Dtos
{
    public class RolesDto
    {
        public List<RoleDto> Roles { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}