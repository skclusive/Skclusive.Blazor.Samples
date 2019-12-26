using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Component;

namespace Skclusive.Blazor.Dashboard.App.View
{
    public static class DashboardViewExtension
    {
        public static void AddDashboardView(this IServiceCollection services, IDashboardViewConfig config)
        {
            services.AddMaterialUI();

            services.AddSingleton<IDashboardViewConfig>(config);
        }
    }
}
