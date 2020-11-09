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
using Skclusive.Blazor.StateTree.App.State;

using System.Text.Json.Serialization;

namespace Skclusive.Blazor.StateTree.App.View
{
    public static class StateTreeViewExtension
    {
        public static void TryAddStateTreeViewServices(this IServiceCollection services, ILayoutConfig config)
        {
            services.TryAddMobxServices(config);

            services.TryAddStateTreeStateServices();

            services.TryAddDevToolsServices(config);

            services.TryAddLayoutServices(config);

            services.TryAddButtonServices(config);
            services.TryAddProgressServices(config);
            services.TryAddDividerServices(config);
            services.TryAddTableServices(config);
            services.TryAddAppBarServices(config);
            services.TryAddToolbarServices(config);

            services.TryAddStyleTypeProvider<StateTreeStyleProvider>();
        }
    }
}
