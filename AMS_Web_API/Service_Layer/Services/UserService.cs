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
    public class UserService : BaseService, IUserService
    {

        //private int i;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(UserToSaveDto entity)
        {
            byte[] passwordHash, passwordSalt;

            if (await _unitOfWork.User.UserExists(entity.Username))
                throw new Exception("Username already exists.");

            User userToCreate = _mapper.Map<User>(entity);

            CreatePasswordHash(entity.Password, out passwordHash, out passwordSalt);
            userToCreate.PasswordHash = passwordHash;
            userToCreate.PasswordSalt = passwordSalt;
            userToCreate.IsActive = true;
            userToCreate.IsVisible = true;
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

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
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

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            List<UserDto> userDtos = new List<UserDto>();
            var users = (await this._unitOfWork.User.GetAll()).Where(x => x.IsVisible);
            if (users != null)
            {

                foreach (var user in users)
                {
                    UserDto userDto = _mapper.Map<UserDto>(user);
                    await GetUserRoles(user.Id, userDto);
                    userDtos.Add(userDto);
                }
            }
            return userDtos;
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
            var entityToUpdate = await this._unitOfWork.User.Get(id);

            if (entityToUpdate == null)
                throw new Exception("Not Found.");

            entityToUpdate.UserName = entity.Username;
            entityToUpdate.IsActive = entity.IsActive;
            entityToUpdate.Gender = entity.Gender;
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
            var userRoles = await _unitOfWork.User.GetUserRoles(id);
            if (userRoles.Count() > 0)
            {
                foreach (var userRole in userRoles)
                {
                    userDto.UserRole.Add(userRole.RoleId);
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

            UserDto userDto = _mapper.Map<UserDto>(user);

            await GetUserRoles(user.Id, userDto);

            return userDto;
        }
    }
}