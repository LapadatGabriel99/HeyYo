using HeyYo.Web.Repository.Interfaces;
using HeyYo.Web.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HeyYo.Web.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddHeyYoRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRegularUserRepository, RegularUserRepository>();

            return services;
        }
    }
}
