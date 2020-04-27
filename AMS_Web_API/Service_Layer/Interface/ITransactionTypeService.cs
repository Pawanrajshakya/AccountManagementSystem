using Persistence_Layer.Models;
using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface ITransactionTypeService : IDeleteService, IAddService<TransactionTypeToSaveDto>, IUpdateService<TransactionTypeToEditDto>, IGetService<TransactionTypeDto>
    {

    }
}