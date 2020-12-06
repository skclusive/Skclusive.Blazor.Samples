using Skclusive.Core.Component;

namespace Skclusive.Dashboard.App.View
{
    public class DashboardScriptProvider : ScriptTypeProvider
    {
        public DashboardScriptProvider() : base
        (
            priority: default,
            typeof(MomentJsScript),
            typeof(ChartJsScript),
            typeof(ChartJsInteropScript)
        )
        {
        }
    }
}
