using Skclusive.Core.Component;
using Skclusive.Blazor.Material.App.View.Layout;
using Skclusive.Blazor.Material.App.View.Resource;

namespace Skclusive.Blazor.Material.App.View
{
    public class MaterialStyleProvider : StyleTypeProvider
    {
        public MaterialStyleProvider() : base
        (
            typeof(SiteStyle),
            typeof(FullLayoutStyle)
        )
        {
        }
    }
}
