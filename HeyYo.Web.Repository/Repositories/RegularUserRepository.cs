using HeyYo.Web.DataAccess.Context;
using HeyYo.Web.DataAccess.Models;
using HeyYo.Web.Repository.Interfaces;
using System.Threading.Tasks;

namespace HeyYo.Web.Repository.Repositories
{
    public class RegularUserRepository : Repository<RegularUser>, IRegularUserRepository
    {
        public HeyYoContext Context { get => _context as HeyYoContext; }

        public RegularUserRepository(HeyYoContext context) : base(context)
        {

        }

        public async Task<bool> AddRegularUser(RegularUser regularUser)
        {
            await Context.AddAsync(regularUser);

            return await Context.SaveChangesAsync() > 0;
        }
    }
}
