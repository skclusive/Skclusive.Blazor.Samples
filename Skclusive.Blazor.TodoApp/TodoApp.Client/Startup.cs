using Skclusive.Blazor.TodoApp.Models;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Skclusive.Script.DevTools;
using Skclusive.Script.DomHelpers;

namespace Skclusive.Blazor.TodoApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<JsonConverter, TodoSnapshotConverter>();

            services.AddDevTools();

            services.AddDomHelpers();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
