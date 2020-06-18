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
    public class UserService : BaseService, IUserService
    {
        private readonly IRoleService _roleService;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IRoleService roleService) : base(unitOfWork, mapper)
        {
            _roleService = roleService;
        }

        public async Task<int> Add(UserToSaveDto entity)
        {
            byte[] passwordHash, passwordSalt;

            if (await _unitOfWork.User.UserExists(entity.Username))
                throw new Exception("Username already exists.");

            User userToCreate = _mapper.Map<User>(entity);

            CreatePasswordHash(entity.Username, out passwordHash, out passwordSalt);
            userToCreate.PasswordHash = passwordHash;
            userToCreate.PasswordSalt = passwordSalt;
            // userToCreate.IsActive = true;
            userToCreate.IsVisible = true;
            if (CurrentUser.User != null)
                userToCreate.CreatedBy = CurrentUser.User.Id;

            userToCreate.UserRole = new System.Collections.Generic.List<UserRole>();

            if (entity.UserRole.Count() > 0)
            {
                foreach (var userRole in entity.UserRole)
                {
                    userToCreate.UserRole.Add(new UserRole { RoleId = userRole });
                }
            }

            _unitOfWork.User.Add(userToCreate);

            _unitOfWork.Complete();

            return userToCreate.Id;
        }

        public async Task<UserDto> Get(int id)
        {
            var user = await this._unitOfWork.User.Get(id);
            if (user == null || !user.IsVisible)
                return null;

            UserDto userDto = _mapper.Map<UserDto>(user);
            await GetUserRoles(user.Id, userDto);

            return userDto;
        }

        public async Task<UsersDto> GetAll(Param parameter)
        {
            PagedList<UserDto> userDtos = new PagedList<UserDto>();

            var queryable = _unitOfWork.User.GetAll()
                .Include(x => x.UserRole)
                .Where(x => x.IsVisible == true);

            switch (parameter.SearchBy.ToLower())
            {
                case "username":
                    queryable = queryable.Where(x => x.UserName.Contains(parameter.SearchText));
                    break;
                case "name":
                    queryable = queryable.Where(x => x.Name.Contains(parameter.SearchText));
                    break;
            }

            switch (parameter.SortBy.ToLower())
            {
                case "username":
                    switch (parameter.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.UserName);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.UserName);
                            break;
                        default:
                            queryable = queryable.OrderByDescending(x => x.CreatedDate);
                            break;

                    }
                    break;

                case "name":
                    switch (parameter.SortDirection.ToLower())
                    {
                        case "desc":
                            queryable = queryable.OrderByDescending(x => x.Name);
                            break;
                        case "asc":
                            queryable = queryable.OrderBy(x => x.Name);
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

            var users = await PagedList<User>.CreateAsync(queryable, parameter.PageNumber, parameter.PageSize);

            if (users != null)
            {
                foreach (var user in users)
                {
                    UserDto userDto = _mapper.Map<UserDto>(user);
                    foreach (var role in user.UserRole)
                    {
                        userDto.UserRole.Add(await _roleService.Get(role.RoleId));
                    }
                    userDtos.Add(userDto);
                }
            }
            UsersDto usersDto = new UsersDto();
            usersDto.Users = userDtos;
            usersDto.CurrentPage = users.CurrentPage;
            usersDto.PageSize = users.PageSize;
            usersDto.TotalCount = users.TotalCount;
            usersDto.TotalPages = users.TotalPages;
            return usersDto;
        }

        public async Task<bool> Remove(int id)
        {
            var entityToDelete = await this._unitOfWork.User.Get(id);

            if (entityToDelete == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.User.Remove(entityToDelete);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var entity = await this._unitOfWork.User.Get(id);

            if (entity == null)
                throw new Exception("Not Found.");

            entity.IsVisible = false;

            this._unitOfWork.User.Update(entity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, UserToEditDto entity)
        {
            var entityToUpdate = await this._unitOfWork.User.GetAll()
            .Include(x => x.UserRole)
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

            if (entityToUpdate == null)
                throw new Exception("Not Found.");

            entityToUpdate.UserRole = new List<UserRole>();

            if (entity.UserRole.Count() > 0)
            {
                foreach (var userRole in entity.UserRole)
                {
                    entityToUpdate.UserRole.Add(new UserRole { RoleId = userRole, UserId = id });
                }
            }

            entityToUpdate.UserName = entity.Username;
            entityToUpdate.IsActive = entity.IsActive;
            entityToUpdate.Phone = entity.Phone;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.Name = entity.Name;

            _unitOfWork.User.Update(entityToUpdate);


            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<UserDto> Login(string username, string password)
        {
            var user = await _unitOfWork.User.Find(x => x.UserName == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            UserDto userDto = _mapper.Map<UserDto>(user);

            await GetUserRoles(user.Id, userDto);

            return userDto;
        }

        private async Task GetUserRoles(int id, UserDto userDto)
        {
            var user = await _unitOfWork.User.GetUserRoles(id);

            if (user != null && user.UserRole.Count() > 0)
            {
                foreach (var role in user.UserRole)
                {
                    userDto.UserRole.Add(await _roleService.Get(role.RoleId));
                }
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputedHash.Length; i++)
                {
                    if (ComputedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private void AddHistory(User user)
        {
            UserHistory userHistory = _mapper.Map<UserHistory>(user);
            _unitOfWork.UserHistory.Add(userHistory);
        }

        public async Task<UserDto> FindBy(string username)
        {
            var user = await _unitOfWork.User.Find(x => x.UserName.ToLower() == username.ToLower());

            if (user == null)
                return null;

            UserDto userDto = _mapper.Map<UserDto>(user);

            await GetUserRoles(user.Id, userDto);

            return userDto;
        }

        public async Task<bool> SetPassword(int id, string password)
        {
            byte[] passwordHash, passwordSalt;

            var entityToUpdate = await this._unitOfWork.User.Get(id);

            if (entityToUpdate == null)
                throw new Exception("Not Found.");

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            entityToUpdate.PasswordHash = passwordHash;
            entityToUpdate.PasswordSalt = passwordSalt;
            entityToUpdate.LastPasswordChangedOn = DateTime.Now;
            entityToUpdate.PasswordChangedCount = entityToUpdate.PasswordChangedCount + 1;

            _unitOfWork.User.Update(entityToUpdate);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}