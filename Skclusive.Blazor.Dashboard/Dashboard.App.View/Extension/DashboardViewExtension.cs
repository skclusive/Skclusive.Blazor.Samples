using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Component;
using Skclusive.Material.Layout;

namespace Skclusive.Blazor.Dashboard.App.View
{
    public static class DashboardViewExtension
    {
        public static void AddDashboardView(this IServiceCollection services, ILayoutConfig config)
        {
            services.AddMaterialUI();

            services.AddLayout(config);
        }
    }
}
