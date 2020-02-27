using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Messenger.App.View;
using WebWindows.Blazor;

namespace Skclusive.Blazor.Messenger.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddMessengerViewServices();
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<MessengerView>("app");
        }
    }
}
