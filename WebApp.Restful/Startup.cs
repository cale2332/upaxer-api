using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Data.Context;
using WebApp.RestfulAPI.Modules;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;

namespace WebApp.Restful
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string[] withOrigins => new[] { "http://voilatek-001-site5.atempurl.com", "http://127.0.0.1:5500", "http://localhost:4200", "http://localhost:4201", "http://localhost:81", "http://localhost:9528", "http://localhost:9527", "http://localhost", "http://192.168.1.100" };

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add GCConnection
            services.AddDbContext<WebAppDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

            services.AddScoped<DbContext>(provider => provider.GetService<WebAppDataContext>());
            services.AddMvcCore()
                    .AddAuthorization()
                   // .AddJsonFormatters()
                    .AddApiExplorer();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson();
            // Add cors
            services.AddCors();
            
            // Add Register modules.
            ServiceModule.Register(services, Configuration);
            RepositoryModule.Register(services);
            AutoMapperModule.Register(services);

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configure Cors
            app.UseCors(builder =>
                           builder.WithOrigins(withOrigins)
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials()
                             );
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
