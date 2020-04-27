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
    public class ClientService : BaseService, IClientService
    {
        public ClientService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(ClientToSaveDto entity)
        {
            if (await _unitOfWork.Client.ClientExists(entity.Name))
            {
                throw new Exception("Already exists.");
            }

            Client Client = _mapper.Map<Client>(entity);

            _unitOfWork.Client.Add(Client);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<ClientDto> Get(int id)
        {
            var entity = await this._unitOfWork.Client.Get(id);
            if (!entity.IsVisible)
                return null;
            ClientDto ClientDto = _mapper.Map<ClientDto>(entity);
            return ClientDto;
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            List<ClientDto> ClientDtos = new List<ClientDto>();
            var Clients = (await this._unitOfWork.Client.GetAll()).Where(x => x.IsVisible);
            if (Clients != null)
            {
                foreach (var Client in Clients)
                {
                    ClientDtos.Add(_mapper.Map<ClientDto>(Client));
                }
            }
            return ClientDtos;
        }

        public async Task<bool> Remove(int id)
        {
            var entity = await this._unitOfWork.Client.Get(id);

            if (entity == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Client.Remove(entity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var Client = await this._unitOfWork.Client.Get(id);

            if (Client == null)
                throw new Exception("Not Found.");

            Client.IsVisible = false;

            this._unitOfWork.Client.Update(Client);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, ClientToEditDto entity)
        {
            var Client = await this._unitOfWork.Client.Get(id);

            if (Client == null)
                throw new Exception("Not Found.");

            Client.IsActive = entity.IsActive;
            Client.BusinessId = entity.BusinessId;

            _unitOfWork.Client.Update(Client);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}