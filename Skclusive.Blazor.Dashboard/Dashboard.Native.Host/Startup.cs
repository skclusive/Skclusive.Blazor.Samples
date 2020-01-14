using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Dashboard.App.View;
using Skclusive.Material.Layout;

namespace Skclusive.Blazor.Dashboard.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Responsive is disabled due to bug in WebWindow javascript calling dotnet fails when delayed
            services.AddDashboardView(new LayoutConfigBuilder().WithResponsive(false).Build());
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<DashboardView>("app");
        }
    }
}
