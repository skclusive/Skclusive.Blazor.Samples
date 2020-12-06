using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Material.Component;

namespace Skclusive.Messenger.App.View
{
    public static class MessengerViewExtension
    {
        public static void TryAddMessengerViewServices(this IServiceCollection services, IMessengerViewConfig config)
        {
            services.TryAddMaterialServices(config);

            services.TryAddSingleton<IMessengerViewConfig>(config);
        }
    }
}
