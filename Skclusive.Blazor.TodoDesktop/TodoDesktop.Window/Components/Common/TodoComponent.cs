using Skclusive.Blazor.TodoDesktop.Models;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Blazor.TodoDesktop.Components
{
    public class TodoComponent : PureComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public IAppState AppState { get; set; }
    }
}
