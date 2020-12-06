using Skclusive.Core.Component;

namespace Skclusive.Material.App.View
{
    public class MaterialStyleProvider : StyleTypeProvider
    {
        public MaterialStyleProvider() : base
        (
            priority: default,
            typeof(SiteStyle),
            typeof(FullLayoutStyle)
        )
        {
        }
    }
}
