using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Dashboard.App.View;

namespace Skclusive.Blazor.Dashboard.Browser.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDashboardView(new DashboardViewConfigBuilder().WithResponsive(true).Build());
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<DashboardView>("app");
        }
    }
}
