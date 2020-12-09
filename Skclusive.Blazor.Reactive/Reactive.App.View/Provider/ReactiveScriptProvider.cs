using Skclusive.Core.Component;

namespace Skclusive.Reactive.App.View
{
    public class ReactiveScriptProvider : ScriptTypeProvider
    {
        public ReactiveScriptProvider() : base
        (
            priority: default,
            typeof(SiteScript)
        )
        {
        }
    }
}
