using Skclusive.Core.Component;

namespace Skclusive.Material.App.View
{
    public class MaterialScriptProvider : ScriptTypeProvider
    {
        public MaterialScriptProvider() : base
        (
            priority: default,
            typeof(SiteScript)
        )
        {
        }
    }
}
