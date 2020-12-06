using Skclusive.Core.Component;

namespace Skclusive.Reactive.App.View
{
    public class ReactiveStyleProvider : StyleTypeProvider
    {
        public ReactiveStyleProvider() : base
        (
            priority: default,
            typeof(SiteStyle),
            typeof(FullLayoutStyle)
        )
        {
        }
    }
}
