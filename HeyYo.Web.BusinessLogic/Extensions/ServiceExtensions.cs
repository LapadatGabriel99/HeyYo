using HeyYo.Web.BusinessLogic.Interfaces;
using HeyYo.Web.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HeyYo.Web.BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddHeyYoServices(this IServiceCollection services)
        {
            services.AddScoped<IRegularUserService, RegularUserService>();

            return services;
        }
    }
}
