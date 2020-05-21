using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Services;
using WebApp.Entities.Database;

namespace WebApp.RestfulAPI.Modules
{
    public class ServiceModule
    {
        private static IConfiguration _configuration;

		public static void Register(IServiceCollection services, IConfiguration configuration)
		{
			_configuration = configuration;

			//Security
            services.AddTransient<ISecurityManagerService, SecurityManagerService>();

            services.Configure<DatabaseOptions>(_configuration.GetSection("DefaultConnection"));
        }
    }
}
