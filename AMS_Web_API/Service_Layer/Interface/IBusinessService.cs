using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IBusinessService: IDeleteService, IAddService<BusinessToSaveDto>, IUpdateService<BusinessToEditDto>, IGetService<BusinessDto>
    {
    }
}