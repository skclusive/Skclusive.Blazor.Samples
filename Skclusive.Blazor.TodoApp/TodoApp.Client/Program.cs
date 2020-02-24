using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Skclusive.Script.DevTools;
using Skclusive.Script.DomHelpers;
using Skclusive.Blazor.TodoApp.Extension;

namespace Skclusive.Blazor.TodoApp
{
    public class Program
    {
		public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddTodoApp();

            builder.Services.AddDevTools();

            builder.Services.AddDomHelpers();

            await builder.Build().RunAsync();
        }
    }
}
