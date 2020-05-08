using System.Collections.Generic;
using Service_Layer.Dtos;

public class UsersDto
{
    public List<UserDto> Users { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
}