using HeyYo.Web.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HeyYo.Web.DataAccess.Context
{
    public class HeyYoContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public HeyYoContext(DbContextOptions<HeyYoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(a => a.RegularUser)
                .WithOne(r => r.ApplicationUser)
                .HasForeignKey<RegularUser>(r => r.ApplicationUserId);
        }
    }
}
