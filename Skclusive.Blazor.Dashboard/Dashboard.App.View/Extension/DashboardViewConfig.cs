using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Component;

namespace Skclusive.Blazor.Dashboard.App.View
{
    public interface IDashboardViewConfig
    {
        bool Responsive { get; }
    }

    public class DashboardViewConfigBuilder
    {
        private class DashboardViewConfig : IDashboardViewConfig
        {
            public bool Responsive { get; internal set; }
        }

        private readonly DashboardViewConfig config = new DashboardViewConfig();

        public IDashboardViewConfig Build()
        {
            return config;
        }

        public DashboardViewConfigBuilder WithResponsive(bool responsive)
        {
            config.Responsive = responsive;

            return this;
        }

        public DashboardViewConfigBuilder With(IDashboardViewConfig config)
        {
            WithResponsive(config.Responsive);

            return this;
        }
    }
}
