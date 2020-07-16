using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Helpers;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public async Task<int> Add(GroupToSaveDto entity)
        {
            if (await _unitOfWork.Group.Exists(x => x.Description == entity.Description))
            {
                throw new Exception("Already exists.");
            }

            Group group = _mapper.Map<Group>(entity);

            _unitOfWork.Group.Add(group);

            _unitOfWork.Complete();

            return group.Id;
        }

        public async Task<GroupDto> Get(int id)
        {
            var entity = await this._unitOfWork.Group.Get(id);
            if (!entity.IsVisible)
                return null;
            GroupDto groupDto = _mapper.Map<GroupDto>(entity);
            return groupDto;
        }

        // public async Task<IEnumerable<GroupDto>> GetAll()
        // {
        //     List<GroupDto> groupDtos = new List<GroupDto>();
        //     var groups = (await this._unitOfWork.Group.GetAll()).Where(x => x.IsVisible);
        //     if (groups != null)
        //     {
        //         foreach (var group in groups)
        //         {
        //             groupDtos.Add(_mapper.Map<GroupDto>(group));
        //         }
        //     }
        //     return groupDtos;
        // }

        public Task<PagedList<GroupDto>> GetAll(Param parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            var entity = await this._unitOfWork.Group.Get(id);

            if (entity == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Group.Remove(entity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var group = await this._unitOfWork.Group.Get(id);

            if (group == null)
                throw new Exception("Not Found.");

            group.IsVisible = false;

            this._unitOfWork.Group.Update(group);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, GroupToEditDto entity)
        {
            var group = await this._unitOfWork.Group.Get(id);

            if (group == null)
                throw new Exception("Not Found.");

            group.Description = entity.Description;
            group.IsActive = entity.IsActive;
            group.SortId = entity.SortId;

            _unitOfWork.Group.Update(group);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}