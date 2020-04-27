using System.Collections.Generic;
using System.Threading.Tasks;
using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IRoleService: IDeleteService, IAddService<RoleToSaveDto>, IUpdateService<RoleToEditDto>, IGetService<RoleDto>
    {
    }
}