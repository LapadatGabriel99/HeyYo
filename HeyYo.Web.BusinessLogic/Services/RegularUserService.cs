using HeyYo.Web.BusinessLogic.Interfaces;
using HeyYo.Web.DataAccess.Models;
using HeyYo.Web.Repository.Interfaces;
using System.Threading.Tasks;

namespace HeyYo.Web.BusinessLogic.Services
{
    public class RegularUserService : IRegularUserService
    {
        private readonly IRegularUserRepository _regularUserRepository;

        public RegularUserService(IRegularUserRepository regularUserRepository)
        {
            _regularUserRepository = regularUserRepository;
        }

        public async Task CreateRegularUserAsync(RegularUser regularUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
