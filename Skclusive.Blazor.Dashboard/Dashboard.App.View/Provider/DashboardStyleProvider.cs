using Skclusive.Blazor.Dashboard.App.View.Chart;
using Skclusive.Blazor.Dashboard.App.View.Styles;
using Skclusive.Core.Component;

namespace Skclusive.Blazor.Dashboard.App.View
{
    public class DashboardStyleProvider : StyleTypeProvider
    {
        public DashboardStyleProvider() : base
        (
            typeof(ChartJsStyles),
            typeof(DashboardStyles)
        )
        {
        }
    }
}
