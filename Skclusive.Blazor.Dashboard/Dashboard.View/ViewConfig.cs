using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Material.Component;

namespace Skclusive.Blazor.Dashboard.View
{
    public interface IViewConfig
    {
        bool Responsive { get; }
    }

    public class ViewConfigBuilder
    {
        private class ViewConfig : IViewConfig
        {
            public bool Responsive { get; internal set; }
        }

        private readonly ViewConfig config = new ViewConfig();

        public IViewConfig Build()
        {
            return config;
        }

        public ViewConfigBuilder WithResponsive(bool responsive)
        {
            config.Responsive = responsive;

            return this;
        }

        public ViewConfigBuilder With(IViewConfig config)
        {
            WithResponsive(config.Responsive);

            return this;
        }
    }
}
