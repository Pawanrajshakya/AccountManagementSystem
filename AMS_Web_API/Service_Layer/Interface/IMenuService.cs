using System.Collections.Generic;
using Service_Layer.Dtos.Menu;

namespace Service_Layer.Interface
{
    public interface IMenuService: IDeleteService, IAddService<MenuToSaveDto>,
    IUpdateService<MenuToEditDto>, IGetService<MenuDto>, IGetWithPaginationService<MenusDto>
    {
         List<MainMenusDto> GetMainMenus(int id);
    }
}