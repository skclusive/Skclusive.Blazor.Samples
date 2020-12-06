using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Layout;
using Skclusive.Mobx.Component;
using Skclusive.Mobx.Form;
//using BlazorStyled;

namespace Skclusive.Material.App.View
{
    public static class MaterialViewExtension
    {
        public static void TryAddMaterialViewServices(this IServiceCollection services, ILayoutConfig config)
        {
            services.TryAddMobxServices(config);

            services.TryAddMobxFormServices(config);

            services.TryAddLayoutServices(config);

            //services.AddBlazorStyled();

            services.TryAddStyleTypeProvider<MaterialStyleProvider>();

             services.TryAddScriptTypeProvider<MaterialScriptProvider>();
        }
    }
}
