using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Helpers;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Add(RoleToSaveDto entity)
        {
            if (await _unitOfWork.Role.RoleExists(entity.Description))
            {
                throw new Exception("Already exists.");
            }

            Role role = _mapper.Map<Role>(entity);

            _unitOfWork.Role.Add(role);

            _unitOfWork.Complete();

            return role.Id;
        }

        public async Task<RoleDto> Get(int id)
        {
            var entity = await this._unitOfWork.Role.Get(id);
            if (!entity.IsVisible)
                return null;
            RoleDto roleDto = _mapper.Map<RoleDto>(entity);
            return roleDto;
        }
        
        public async Task<RolesDto> GetAll(RoleParam param)
        {
            PagedList<RoleDto> roleDtos = new PagedList<RoleDto>();

            var queryable = _unitOfWork.Role.GetAll()
                .Where(x => x.IsVisible && x.IsActive == param.IsActive);

            if (!string.IsNullOrWhiteSpace(param.Description))
                queryable = queryable.Where(x => x.Description.Contains(param.Description));

            var roles = await PagedList<Role>.CreateAsync(queryable, param.PageNumber, param.PageSize);

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    RoleDto dto = _mapper.Map<RoleDto>(role);
                    
                    roleDtos.Add(dto);
                }
            }
            RolesDto rolesDto = new RolesDto();
            rolesDto.Roles = roleDtos;
            rolesDto.CurrentPage = roles.CurrentPage;
            rolesDto.PageSize = roles.PageSize;
            rolesDto.TotalCount = roles.TotalCount;
            rolesDto.TotalPages = roles.TotalPages;
            return rolesDto;
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