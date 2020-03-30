using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DomHelpers;
using Skclusive.Core.Component;
using Skclusive.Blazor.TodoDesktop.Extension;
using WebWindows.Blazor;

namespace Skclusive.Blazor.TodoDesktop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTodoDesktop();

            services.TryAddDomHelpersServices
            (
                new CoreConfigBuilder()
                .WithIsServer(false)
                .WithIsPreRendering(false)
                .Build()
            );
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
