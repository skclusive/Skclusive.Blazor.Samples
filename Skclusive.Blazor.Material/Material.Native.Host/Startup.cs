using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Material.App.View;
using Skclusive.Material.Layout;
using Skclusive.Blazor.Material.App.View.Data;

namespace Skclusive.Blazor.Material.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddHttpClient();

            services.AddTransient<IWeatherForecastService, LocalWeatherForecastService>();
            // Responsive is disabled due to bug in WebWindow javascript calling dotnet fails when delayed
            services.AddLayout(new LayoutConfigBuilder().WithResponsive(false).Build());
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
