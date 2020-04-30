using System.Threading.Tasks;
using AutoMapper;
using Persistence_Layer.Interfaces;
using Persistence_Layer.Models;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace Service_Layer.Services
{
    public class UserActivityService : BaseService, IUserActivityService
    {
        public UserActivityService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<bool> Add(UserActivityToSaveDto entity)
        {
            UserActivity userActivity = _mapper.Map<UserActivity>(entity);

            await Task.Run(() => { _unitOfWork.UserActivity.Add(userActivity); });
            
            //t.Wait();

            // _unitOfWork.UserActivity.Add(userActivity);

            if (_unitOfWork.Complete() > 0)
                return true;

            return false;
        }
    }
}