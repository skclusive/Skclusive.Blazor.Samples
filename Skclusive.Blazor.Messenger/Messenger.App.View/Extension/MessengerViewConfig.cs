using Skclusive.Material.Core;
using Skclusive.Material.Component;

namespace Skclusive.Blazor.Messenger.App.View
{
    public interface IMessengerViewConfig : IMaterialConfig
    {
    }

    public class MessengerViewConfigBuilder : MaterialConfigBuilder<MessengerViewConfigBuilder, IMessengerViewConfig>
    {
        protected class MessengerViewConfig : MaterialConfig, IMessengerViewConfig
        {
        }

        public MessengerViewConfigBuilder() : base(new MessengerViewConfig())
        {
        }

        protected override IMessengerViewConfig Config()
        {
            return (IMessengerViewConfig)_config;
        }

        protected override MessengerViewConfigBuilder Builder()
        {
            return this;
        }
    }
}
