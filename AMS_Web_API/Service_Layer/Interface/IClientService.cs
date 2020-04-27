using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IClientService : IDeleteService, IAddService<ClientToSaveDto>, IUpdateService<ClientToEditDto>, IGetService<ClientDto>
    {

    }
}