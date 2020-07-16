using System;
using Service_Layer.Services;


namespace Service_Layer.Interface
{
    public interface IServiceManager
    {
        IBusinessService Business { get; }
        IRoleService Role { get; }
        IMenuService Menu { get; }
        IAccountTypeService AccountType { get; }
        IAccountService Account { get; }
        IClientService Client { get; }
        IGroupService Group { get; }
        IRelationshipService Relationship { get; }
        ITransactionTypeService TransactionType { get; }
        ITransactionService Transaction { get; }
        IUserService User { get; }
        IUserActivityService UserActivity { get; }
    }


}