using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DomHelpers;
using Skclusive.Blazor.TodoDesktop.Extension;

namespace Skclusive.Blazor.TodoDesktop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTodoDesktop();

            services.AddDomHelpers();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
