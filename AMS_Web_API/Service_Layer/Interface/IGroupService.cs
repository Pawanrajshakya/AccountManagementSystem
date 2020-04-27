using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IGroupService : IDeleteService, IAddService<GroupToSaveDto>, IUpdateService<GroupToEditDto>, IGetService<GroupDto>
    {

    }
}