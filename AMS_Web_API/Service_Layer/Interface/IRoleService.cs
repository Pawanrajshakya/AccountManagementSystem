using System.Threading.Tasks;
using Service_Layer.Dtos;
using Service_Layer.Helpers;

namespace Service_Layer.Interface
{
    public interface IRoleService : IDeleteService, IAddService<RoleToSaveDto>,
    IUpdateService<RoleToEditDto>, IGetService<RoleDto>
    {
        Task<RolesDto> GetAll(RoleParam param);
    }
}