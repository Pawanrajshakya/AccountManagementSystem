using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IAccountTypeService : IDeleteService, IAddService<AccountTypeToSaveDto>, IUpdateService<AccountTypeToEditDto>, IGetService<AccountTypeDto>
    {

    }
}