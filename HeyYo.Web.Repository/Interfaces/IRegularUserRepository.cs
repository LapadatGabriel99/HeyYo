using HeyYo.Web.DataAccess.Models;
using System.Threading.Tasks;

namespace HeyYo.Web.Repository.Interfaces
{
    public interface IRegularUserRepository : IRepository<RegularUser>
    {
        Task<bool> AddRegularUser(RegularUser regularUser);
    }
}
