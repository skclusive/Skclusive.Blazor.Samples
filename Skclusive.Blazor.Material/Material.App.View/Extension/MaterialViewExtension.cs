using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Button;
using Skclusive.Material.Progress;
using Skclusive.Material.Divider;
using Skclusive.Material.Table;
using Skclusive.Material.AppBar;
using Skclusive.Material.Toolbar;
using Skclusive.Material.Layout;
//using BlazorStyled;

namespace Skclusive.Blazor.Material.App.View
{
    public static class MaterialViewExtension
    {
        public static void TryAddMaterialViewServices(this IServiceCollection services, ILayoutConfig config)
        {
            services.TryAddLayoutServices(config);

            services.TryAddButtonServices(config);
            services.TryAddProgressServices(config);
            services.TryAddDividerServices(config);
            services.TryAddTableServices(config);
            services.TryAddAppBarServices(config);
            services.TryAddToolbarServices(config);

            //services.AddBlazorStyled();

            services.TryAddStyleTypeProvider<MaterialStyleProvider>();
        }
    }
}
