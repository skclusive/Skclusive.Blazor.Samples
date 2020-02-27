using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Component;

namespace Skclusive.Blazor.Messenger.App.View
{
    public static class MessengerViewExtension
    {
        public static void TryAddMessengerViewServices(this IServiceCollection services)
        {
            services.TryAddMaterialServices();
        }
    }
}
