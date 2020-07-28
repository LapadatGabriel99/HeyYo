using HeyYo.Web.DataAccess.Context;
using HeyYo.Web.DataAccess.Models;
using HeyYo.Web.Repository.Interfaces;

namespace HeyYo.Web.Repository.Repositories
{
    public class RegularUserRepository : Repository<RegularUser>, IRegularUserRepository
    {
        public HeyYoContext Context { get => _context as HeyYoContext; }

        public RegularUserRepository(HeyYoContext context) : base(context)
        {

        }
    }
}
