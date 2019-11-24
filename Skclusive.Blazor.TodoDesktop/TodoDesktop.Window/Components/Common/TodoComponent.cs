using Skclusive.Blazor.TodoDesktop.Models;
using Microsoft.AspNetCore.Components;
using Skclusive.Mobx.Component;

namespace Skclusive.Blazor.TodoDesktop.Components
{
    public class TodoComponent : ObservableComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public IAppState AppState { get; set; }
    }
}
