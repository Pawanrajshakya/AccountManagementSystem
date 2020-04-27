using System;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Repository;

namespace Persistence_Layer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Account = new AccountRepository(_context);
            AccountHistory = new AccountHistoryRepository(_context);
            AccountType = new AccountTypeRepository(_context);
            Business = new BusinessRepository(_context);
            Client = new ClientRepository(_context);
            Group = new GroupRepository(_context);
            Relationship = new RelationshipRepository(_context);
            Role = new RoleRepository(_context);
            Transaction = new TransactionRepository(_context);
            TransactionType = new TransactionTypeRepository(_context);
            User = new UserRepository(_context);
            UserHistory = new UserHistoryRepository(_context);
        }

        public IAccountRepository Account { get; private set; }

        public IAccountHistoryRepository AccountHistory { get; private set; }

        public IAccountTypeRepository AccountType { get; private set; }

        public IBusinessRepository Business { get; private set; }

        public IClientRepository Client { get; private set; }

        public IGroupRepository Group { get; private set; }

        public IRelationshipRepository Relationship { get; private set; }

        public IRoleRepository Role { get; private set; }

        public ITransactionRepository Transaction { get; private set; }

        public ITransactionTypeRepository TransactionType { get; private set; }

        public IUserRepository User { get; private set; }

        public IUserHistoryRepository UserHistory {get; private set;}

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}