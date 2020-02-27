using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Material.App.View;
using Skclusive.Material.Layout;
using Skclusive.Blazor.Material.App.View.Data;
using WebWindows.Blazor;

namespace Skclusive.Blazor.Material.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddHttpClient();

            services.AddTransient<IWeatherForecastService, LocalWeatherForecastService>();
            // Responsive is disabled due to bug in WebWindow javascript calling dotnet fails when delayed
            services.TryAddLayoutServices(new LayoutConfigBuilder().WithResponsive(false).Build());
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
