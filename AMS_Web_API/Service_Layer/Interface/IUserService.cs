using System.Threading.Tasks;
using Service_Layer.Dtos;

namespace Service_Layer.Interface
{
    public interface IUserService : IDeleteService, IAddService<UserToSaveDto>, IUpdateService<UserToEditDto>, IGetService<UserDto>
    {
        // Task<UserDto> Register(User user, string password);
        Task<UserDto> Login(string username, string password);
        Task<UserDto> FindBy(string username);
    }
}