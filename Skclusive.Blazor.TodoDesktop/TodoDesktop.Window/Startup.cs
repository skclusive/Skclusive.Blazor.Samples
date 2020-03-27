using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DomHelpers;
using Skclusive.Blazor.TodoDesktop.Extension;
using WebWindows.Blazor;

namespace Skclusive.Blazor.TodoDesktop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTodoDesktop();

            services.TryAddDomHelpersServices();
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
