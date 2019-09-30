//using BlazorNetCoreConf.Core.Services;
using BlazorNetCoreConf.Core;
using BlazorNetCoreConf.Core.Data;
using BlazorNetCoreConf.Core.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorNetCoreConf.WebAssembly
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MovieContext>();
            services.AddDbContext<MovieContext>(
                options => options.UseSqlServer("Server=.;Database=BlazorNetCoreConfDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddScoped<WeatherForecastService>();
            services.AddScoped<MovieService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
