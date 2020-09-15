using Skclusive.Blazor.Dashboard.App.View.Chart;
using Skclusive.Core.Component;

namespace Skclusive.Blazor.Dashboard.App.View
{
    public class DashboardScriptProvider : ScriptTypeProvider
    {
        public DashboardScriptProvider() : base
        (
            typeof(MomentJsScript),
            typeof(ChartJsScript),
            typeof(ChartJsInteropScript)
        )
        {
        }
    }
}
