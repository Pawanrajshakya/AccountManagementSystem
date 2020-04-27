using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IRelationshipService : IDeleteService, IAddService<RelationshipToSaveDto>, IUpdateService<RelationshipToEditDto>, IGetService<RelationshipDto>
    {

    }
}