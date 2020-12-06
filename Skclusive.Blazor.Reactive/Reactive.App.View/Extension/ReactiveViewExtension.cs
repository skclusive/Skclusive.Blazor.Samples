using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using Skclusive.Core.Component;
using Skclusive.Material.Button;
using Skclusive.Material.Progress;
using Skclusive.Material.Divider;
using Skclusive.Material.Table;
using Skclusive.Material.AppBar;
using Skclusive.Material.Toolbar;
using Skclusive.Material.Layout;
using Skclusive.Mobx.Component;
using Skclusive.Script.DevTools;
using Skclusive.Reactive.App.State;
using System.Reactive.Concurrency;
using System.Text.Json.Serialization;

namespace Skclusive.Reactive.App.View
{
    public static class ReactiveViewExtension
    {
        public static void TryAddReactiveViewServices(this IServiceCollection services, IScheduler scheduler, ILayoutConfig config)
        {
            services.TryAddMobxServices(config);

            services.TryAddReactiveStateServices(scheduler);

            services.TryAddDevToolsServices(config);

            services.TryAddLayoutServices(config);

            services.TryAddButtonServices(config);
            services.TryAddProgressServices(config);
            services.TryAddDividerServices(config);
            services.TryAddTableServices(config);
            services.TryAddAppBarServices(config);
            services.TryAddToolbarServices(config);

            services.TryAddStyleTypeProvider<ReactiveStyleProvider>();
        }
    }
}
