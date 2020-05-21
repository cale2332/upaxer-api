
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebApp;
using WebApp.Services;
using WebApp.Entities;
using WebApp.DataTransferObjects;

namespace WebApp.RestfulAPI.Modules
{
	public class AutoMapperModule
	{
		public static void Register(IServiceCollection services)
		{
			// Auto Mapper Configurations
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AutoMapperProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
		}
	}

	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			//Schedule
			CreateMap<AppUser, AppUserSingle>().ReverseMap();


		}
	}
}
