using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Component;
using Skclusive.Material.Layout;

namespace Skclusive.Blazor.Dashboard.App.View
{
    public static class DashboardViewExtension
    {
        public static void TryAddDashboardViewServices(this IServiceCollection services, IDashboardViewConfig config)
        {
            services.TryAddLayoutServices(config);

            services.TryAddMaterialServices(config);

            services.TryAddScoped<IDashboardViewConfig>(sp => config);

            services.TryAddStyleTypeProvider<DashboardStyleProvider>();

            services.TryAddScriptTypeProvider<DashboardScriptProvider>();
        }
    }
}
