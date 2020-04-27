using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service_Layer.Interface
{

    public interface IDeleteService
    {
        Task<bool> Remove(int id);
        Task<bool> SoftDelete(int id);
    }

    public interface IAddService<T> where T : class
    {
        Task<bool> Add(T entity);
    }

    public interface IUpdateService<T> where T : class
    {
        Task<bool> Update(int id, T entity);
    }

    public interface IGetService<T> where T : class
    {
        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();
    }
}