using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Material.App.View;
using Skclusive.Material.Layout;

namespace Skclusive.Blazor.Material.Browser.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLayout(new LayoutConfigBuilder().WithResponsive(true).Build());
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<AppView>("app");
        }
    }
}
