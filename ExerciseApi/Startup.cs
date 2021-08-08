using ExerciseServices.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oxygen.Core.Common.Interfaces;
using Oxygen.Core.Database;
using Oxygen.Core.Runtime.Application;

namespace ExerciseApi
{
    public class Startup:OxygenCoreStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services
                .AddOxygenDbContextPools()
                .AddAutoMapper(typeof(MapperProfile));
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, IVersionInfo versionInfoService)
        {
            base.Configure(app, env, versionInfoService);
            app.UseHttpsRedirection();
        }
    }
}
