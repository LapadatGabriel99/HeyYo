using HeyYo.Web.BusinessLogic.Interfaces;
using HeyYo.Web.Repository.Interfaces;

namespace HeyYo.Web.BusinessLogic.Services
{
    public class RegularUserService : IRegularUserService
    {
        private readonly IRegularUserRepository _regularUserRepository;

        public RegularUserService(IRegularUserRepository regularUserRepository)
        {
            _regularUserRepository = regularUserRepository;
        }
    }
}
