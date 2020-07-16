using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Interface;
using System.Linq;
using Service_Layer.Helpers;

namespace Service_Layer.Services
{
    public class AccountTypeService : BaseService, IAccountTypeService
    {
        public AccountTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Add(AccountTypeToSaveDto Entity)
        {
            if (await _unitOfWork.AccountType.Exists(x=>x.Description == Entity.Description))
            {
                throw new Exception("Name already exists.");
            }

            AccountType entity = _mapper.Map<AccountType>(Entity);

            _unitOfWork.AccountType.Add(entity);

            _unitOfWork.Complete();

            return entity.Id;
        }

        public async Task<AccountTypeDto> Get(int id)
        {
            AccountType entity = await this._unitOfWork.AccountType.Get(id);
            if (!entity.IsVisible)
                return null;
            AccountTypeDto entityDto = _mapper.Map<AccountTypeDto>(entity);
            return entityDto;
        }

        // public async Task<IEnumerable<AccountTypeDto>> GetAll()
        // {
        //     List<AccountTypeDto> entityDtos = new List<AccountTypeDto>();
        //     var entities = (await this._unitOfWork.AccountType.GetAll()).Where(x => x.IsVisible);
        //     if (entities != null)
        //     {
        //         foreach (var entity in entities)
        //         {
        //             entityDtos.Add(_mapper.Map<AccountTypeDto>(entity));
        //         }
        //     }
        //     return entityDtos;
        // }

        public Task<PagedList<AccountTypeDto>> GetAll(Param parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            var entityToDelete = await this._unitOfWork.AccountType.Get(id);

            if (entityToDelete == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.AccountType.Remove(entityToDelete);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var entity = await this._unitOfWork.AccountType.Get(id);

            if (entity == null)
                throw new Exception("Not Found.");

            entity.IsVisible = false;

            this._unitOfWork.AccountType.Update(entity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, AccountTypeToEditDto entity)
        {
            var entityToUpdate = await this._unitOfWork.AccountType.Get(id);

            if (entityToUpdate == null)
                throw new Exception("Not Found.");

            entityToUpdate.Description = entity.Description;
            entityToUpdate.IsActive = entity.IsActive;
            entityToUpdate.SortId = entity.SortId;
            entityToUpdate.GroupId = entity.GroupId;

            _unitOfWork.AccountType.Update(entityToUpdate);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}