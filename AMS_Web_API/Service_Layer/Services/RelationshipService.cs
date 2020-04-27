using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Service_Layer.Dtos;
using Service_Layer.Interface;
using Persistence_Layer.Models;

namespace Service_Layer.Services
{
    public class RelationshipService : BaseService, IRelationshipService
    {
        public RelationshipService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(RelationshipToSaveDto entity)
        {
            if (await _unitOfWork.Relationship.RelationshipExists(entity.Description))
            {
                throw new Exception("Already exists.");
            }

            Relationship Relationship = _mapper.Map<Relationship>(entity);

            _unitOfWork.Relationship.Add(Relationship);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<RelationshipDto> Get(int id)
        {
            var entity = await this._unitOfWork.Relationship.Get(id);
            if (!entity.IsVisible)
                return null;
            RelationshipDto RelationshipDto = _mapper.Map<RelationshipDto>(entity);
            return RelationshipDto;
        }

        public async Task<IEnumerable<RelationshipDto>> GetAll()
        {
            List<RelationshipDto> RelationshipDtos = new List<RelationshipDto>();
            var Relationships = (await this._unitOfWork.Relationship.GetAll()).Where(x => x.IsVisible);
            if (Relationships != null)
            {
                foreach (var Relationship in Relationships)
                {
                    RelationshipDtos.Add(_mapper.Map<RelationshipDto>(Relationship));
                }
            }
            return RelationshipDtos;
        }

        public async Task<bool> Remove(int id)
        {
            var entity = await this._unitOfWork.Relationship.Get(id);

            if (entity == null)
            {
                throw new Exception("Not Found.");
            }

            this._unitOfWork.Relationship.Remove(entity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> SoftDelete(int id)
        {
            var Relationship = await this._unitOfWork.Relationship.Get(id);

            if (Relationship == null)
                throw new Exception("Not Found.");

            Relationship.IsVisible = false;

            this._unitOfWork.Relationship.Update(Relationship);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }

        public async Task<bool> Update(int id, RelationshipToEditDto entity)
        {
            var Relationship = await this._unitOfWork.Relationship.Get(id);

            if (Relationship == null)
                throw new Exception("Not Found.");

            Relationship.Description = entity.Description;
            Relationship.IsActive = entity.IsActive;

            _unitOfWork.Relationship.Update(Relationship);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}