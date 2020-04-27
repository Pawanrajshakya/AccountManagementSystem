using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IAccountService : IDeleteService, IAddService<AccountToSaveDto>, IUpdateService<AccountToEditDto>, IGetService<AccountDto>
    {

    }
}