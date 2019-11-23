using Skclusive.Blazor.TodoApp.Models;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Script.DevTools;
using Skclusive.Script.DomHelpers;
using Skclusive.Blazor.TodoApp.Extension;

namespace Skclusive.Blazor.TodoApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTodoApp();

            services.AddDevTools();

            services.AddDomHelpers();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
