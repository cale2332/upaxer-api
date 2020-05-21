using Microsoft.Extensions.DependencyInjection;
using WebApp.Data.Repositories;

namespace WebApp.RestfulAPI.Modules
{
    public class RepositoryModule
    {
        public static void Register(IServiceCollection services)
        { 
            services.AddTransient<ISecurityManagerRepository, SecurityManagerRepository>();
        }
    }
}
    