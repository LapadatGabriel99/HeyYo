using HeyYo.Web.DataAccess.Models;
using System.Threading.Tasks;

namespace HeyYo.Web.BusinessLogic.Interfaces
{
    public interface IRegularUserService
    {
        Task CreateRegularUserAsync(RegularUser regularUser);
    }
}
