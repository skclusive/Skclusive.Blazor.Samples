using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.Messenger.App.View;
using WebWindows.Blazor;

namespace Skclusive.Blazor.Messenger.Native.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddMessengerViewServices
            (
                new MessengerViewConfigBuilder()
                .WithIsServer(false)
                .WithIsPreRendering(false)
                .Build()
            );
        }

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<MessengerView>("app");
        }
    }
}
