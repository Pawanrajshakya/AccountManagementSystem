using System.Threading.Tasks;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface IRelationshipRepository: IRepository<Relationship>
    {
         Task<bool> RelationshipExists(string description);
    }
}