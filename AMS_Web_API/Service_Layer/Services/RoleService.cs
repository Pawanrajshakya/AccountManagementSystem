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
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(RoleToSaveDto entity)
        {
            if (await _unitOfWork.Role.RoleExists(entity.Description))
            {
                throw new Exception("Already exists.");
            }

            Role role = _mapper.Map<Role>(entity);

            _unitOfWork.Role.Add(role);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<RoleDto> Get(int id)
        {
            var entity = await this._unitOfWork.Role.Get(id);
            if (!entity.IsVisible)
                return null;
            RoleDto roleDto = _mapper.Map<RoleDto>(entity);
            return roleDto;
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            List<RoleDto> roleDtos = new List<RoleDto>();
            var roles = (await this._unitOfWork.Role.GetAll()).Where(x => x.IsVisible);
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    roleDtos.Add(_mapper.Map<RoleDto>(role));
                }
            }
            return roleDtos;
        }

        public async Task<bool> Remove(int id)
        {
            var role = await this._unitOfWork.Role.Get(id);

            if (role == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Role.Remove(role);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var role = await this._unitOfWork.Role.Get(id);

            if (role == null)
                throw new Exception("Not Found.");

            role.IsVisible = false;

            this._unitOfWork.Role.Update(role);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, RoleToEditDto entity)
        {
            var role = await this._unitOfWork.Role.Get(id);

            if (role == null)
                throw new Exception("Not Found.");

            role.Description = entity.Description;
            role.IsActive = entity.IsActive;

            _unitOfWork.Role.Update(role);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}