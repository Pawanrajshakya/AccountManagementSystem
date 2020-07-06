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

        public async Task<RolesDto> GetAll(Param parameter)
        {
            PagedList<RoleDto> roleDtos = new PagedList<RoleDto>();

            var queryable = _unitOfWork.Role.GetAll()
                .Where(x => x.IsVisible == true);

            switch (parameter.SearchBy.ToLower())
            {
                case "description":
                    queryable = queryable.Where(x => x.Description.Contains(parameter.SearchText));
                    break;
            }

            switch (parameter.SortBy.ToLower())
            {
                case "description":
                    switch (parameter.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Description);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Description);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;

                    }
                    break;
                case "createddate":
                    switch (parameter.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.CreatedDate);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;
                    }
                    break;
            }

            var pagedRoles = await PagedList<Role>.CreateAsync(queryable, parameter.PageNumber, parameter.PageSize);

            if (pagedRoles != null)
            {
                foreach (var role in pagedRoles)
                {
                    RoleDto dto = _mapper.Map<RoleDto>(role);
                    roleDtos.Add(dto);
                }
            }

            RolesDto roles = new RolesDto();
            roles.Roles = roleDtos;
            roles.CurrentPage = pagedRoles.CurrentPage;
            roles.PageSize = pagedRoles.PageSize;
            roles.TotalCount = pagedRoles.TotalCount;
            roles.TotalPages = pagedRoles.TotalPages;
            return roles;
        }

        public List<RoleDto> GetAll()
        {
            List<RoleDto> roleDtos = new List<RoleDto>();

            var roles = _unitOfWork.Role.GetAll()
                .Where(x => x.IsVisible == true)
                .OrderBy(x => x.Description)
                .ToList();
            
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    RoleDto dto = _mapper.Map<RoleDto>(role);
                    roleDtos.Add(dto);
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