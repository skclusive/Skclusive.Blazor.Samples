using Skclusive.Core.Component;

namespace Skclusive.Dashboard.App.View
{
    public class DashboardStyleProvider : StyleTypeProvider
    {
        public DashboardStyleProvider() : base
        (
            priority: default,
            typeof(ChartJsStyles),
            typeof(DashboardStyles)
        )
        {
        }
    }
}
