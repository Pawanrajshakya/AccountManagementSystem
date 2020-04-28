using Service_Layer.Helpers;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(
            IBusinessService business,
            IRoleService role,
            IUserService user,
            IAccountTypeService accountType,
            IGroupService group,
            IAccountService account,
            IClientService client,
            IRelationshipService relationship,
            IUserActivityService userActivity)
        {
            this.Business = business;
            this.Role = role;
            this.User = user;
            this.AccountType = accountType;
            this.Group = group;
            this.Account = account;
            this.Client = client;
            this.Relationship = relationship;
            this.UserActivity = userActivity;
        }

        public IBusinessService Business { get; private set; }
        public IRoleService Role { get; private set; }
        public IAccountTypeService AccountType { get; private set; }
        public IAccountService Account { get; private set; }
        public IClientService Client { get; private set; }
        public IGroupService Group { get; private set; }
        public IRelationshipService Relationship { get; private set; }
        public ITransactionTypeService TransactionType { get; private set; }
        public ITransactionService Transaction { get; private set; }
        public IUserService User { get; private set; }
        public IUserActivityService UserActivity { get; private set; }
    }
}