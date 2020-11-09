using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DomHelpers;
using Skclusive.Core.Component;
using Skclusive.Mobx.Component;
using Skclusive.Blazor.TodoDesktop.Extension;
using WebWindows.Blazor;

namespace Skclusive.Blazor.TodoDesktop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTodoDesktop();

            var coreConfig = new CoreConfigBuilder()
                .WithIsServer(false)
                .WithIsPreRendering(false)
                .Build();

            services.TryAddMobxServices(coreConfig);

            services.TryAddDomHelpersServices(coreConfig);
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
