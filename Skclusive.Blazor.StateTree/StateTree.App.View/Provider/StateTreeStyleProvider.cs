using Skclusive.Core.Component;
using Skclusive.Blazor.StateTree.App.View.Layout;
using Skclusive.Blazor.StateTree.App.View.Resource;

namespace Skclusive.Blazor.StateTree.App.View
{
    public class StateTreeStyleProvider : StyleTypeProvider
    {
        public StateTreeStyleProvider() : base
        (
            typeof(SiteStyle),
            typeof(FullLayoutStyle)
        )
        {
        }
    }
}
