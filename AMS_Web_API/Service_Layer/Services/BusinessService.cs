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
    public class BusinessService : BaseService, IBusinessService
    {
        public BusinessService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(BusinessToSaveDto entity)
        {

            if (await _unitOfWork.Business.BusinessExists(entity.Name))
            {
                throw new Exception("Already exists.");
            }

            Business entityToSave = _mapper.Map<Business>(entity);

            _unitOfWork.Business.Add(entityToSave);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;

        }

        public async Task<BusinessDto> Get(int id)
        {
            var entity = await this._unitOfWork.Business.Get(id);
            if (!entity.IsVisible)
                return null;
            BusinessDto businessDto = _mapper.Map<BusinessDto>(entity);
            return businessDto;

        }
        
        public async Task<IEnumerable<BusinessDto>> GetAll()
        {
            List<BusinessDto> businessDtos = new List<BusinessDto>();
            var businesses = (await this._unitOfWork.Business.GetAll()).Where(x => x.IsVisible);
            if (businesses != null)
            {
                foreach (var business in businesses)
                {
                    businessDtos.Add(_mapper.Map<BusinessDto>(business));
                }
            }
            return businessDtos;
        }
        public async Task<bool> Remove(int id)
        {
            var businessToDelete = await this._unitOfWork.Business.Get(id);

            if (businessToDelete == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Business.Remove(businessToDelete);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var business = await this._unitOfWork.Business.Get(id);

            if (business == null)
                throw new Exception("Not Found.");

            business.IsVisible = false;

            this._unitOfWork.Business.Update(business);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
        public async Task<bool> Update(int id, BusinessToEditDto entity)
        {
            var businessToPatch = await this._unitOfWork.Business.Get(id);

            if (businessToPatch == null)
                throw new Exception("Not Found.");

            businessToPatch.Address1 = entity.Address1;
            businessToPatch.Address2 = entity.Address2;
            businessToPatch.Description = entity.Description;
            businessToPatch.Name = entity.Name;
            businessToPatch.ZipCode = entity.ZipCode;
            businessToPatch.State = entity.State;
            businessToPatch.IsActive = entity.IsActive;

            _unitOfWork.Business.Update(businessToPatch);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}