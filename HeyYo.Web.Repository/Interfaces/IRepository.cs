using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeyYo.Web.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T model);

        Task AddRange(IEnumerable<T> models);

        Task<T> GetById<Id>(Id id);

        Task Remove(T model);

        Task RemoveRange(IEnumerable<T> models);

        Task Update(T models);

        Task UpdateRange(IEnumerable<T> models);
    }
}
