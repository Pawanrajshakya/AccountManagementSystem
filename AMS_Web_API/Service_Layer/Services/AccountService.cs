using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(AccountToSaveDto entity)
        {

            if (await _unitOfWork.Account.AccountExists(entity.AccountNo))
            {
                throw new Exception("Already exists.");
            }

            Account entityToSave = _mapper.Map<Account>(entity);

            _unitOfWork.Account.Add(entityToSave);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;

        }

        public async Task<AccountDto> Get(int id)
        {
            var entity = await this._unitOfWork.Account.Get(id);
            if (!entity.IsVisible)
                return null;
            AccountDto AccountDto = _mapper.Map<AccountDto>(entity);
            return AccountDto;

        }
        
        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            List<AccountDto> AccountDtos = new List<AccountDto>();
            var Accountes = (await this._unitOfWork.Account.GetAll()).Where(x => x.IsVisible);
            if (Accountes != null)
            {
                foreach (var Account in Accountes)
                {
                    AccountDtos.Add(_mapper.Map<AccountDto>(Account));
                }
            }
            return AccountDtos;
        }
        public async Task<bool> Remove(int id)
        {
            var account = await this._unitOfWork.Account.Get(id);

            if (account == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Account.Remove(account);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var Account = await this._unitOfWork.Account.Get(id);

            if (Account == null)
                throw new Exception("Not Found.");

            Account.IsVisible = false;

            this._unitOfWork.Account.Update(Account);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
        public async Task<bool> Update(int id, AccountToEditDto entity)
        {
            var account = await this._unitOfWork.Account.Get(id);

            if (account == null)
                throw new Exception("Not Found.");

            //AddHistory(account);

            account.Address1 = entity.Address1;
            account.Address2 = entity.Address2;
            account.AccountNo = entity.AccountNo;
            account.ZipCode = entity.ZipCode;
            account.State = entity.State;
            account.AccountTypeId = entity.AccountTypeId;
            account.ClientId = entity.ClientId;
            account.Email = entity.Email;
            account.FirstName = entity.FirstName;
            account.IsMain = entity.IsMain;
            account.LastName = entity.LastName;
            account.MiddleName = entity.MiddleName;
            account.RelationshipId = entity.RelationshipId;
            account.Phone = entity.Phone;
            account.Order = entity.Order;
            account.IsActive = entity.IsActive;

            _unitOfWork.Account.Update(account);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        private void AddHistory(Account account)
        {
            AccountHistory accountHistory = _mapper.Map<AccountHistory>(account);
            _unitOfWork.AccountHistory.Add(accountHistory);
        }
    }
}