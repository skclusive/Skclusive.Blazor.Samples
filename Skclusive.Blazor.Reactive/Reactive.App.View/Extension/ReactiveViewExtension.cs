using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Core.Component;
using Skclusive.Material.Layout;
using Skclusive.Mobx.Component;
using Skclusive.Mobx.Form;
using Skclusive.Script.DevTools;
using Skclusive.Reactive.App.State;
using System.Reactive.Concurrency;
using System.Text.Json.Serialization;
//using BlazorStyled;

namespace Skclusive.Reactive.App.View
{
    public static class ReactiveViewExtension
    {
        public static void TryAddReactiveViewServices(this IServiceCollection services, IScheduler scheduler, ILayoutConfig config)
        {
            services.TryAddMobxServices(config);

            services.TryAddReactiveStateServices(scheduler);

            services.TryAddDevToolsServices(config);

            services.TryAddMobxFormServices(config);

            services.TryAddLayoutServices(config);

            //services.AddBlazorStyled();

            services.TryAddStyleTypeProvider<ReactiveStyleProvider>();

             services.TryAddScriptTypeProvider<ReactiveScriptProvider>();
        }
    }
}
