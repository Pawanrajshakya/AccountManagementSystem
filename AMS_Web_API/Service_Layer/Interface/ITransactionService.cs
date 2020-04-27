using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface ITransactionService : IDeleteService, IAddService<TransactionToSaveDto>, IUpdateService<TransactionToEditDto>, IGetService<TransactionDto>
    {

    }
}