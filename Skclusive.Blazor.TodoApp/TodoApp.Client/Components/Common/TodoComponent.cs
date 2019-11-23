using Skclusive.Blazor.TodoApp.Models;
using Microsoft.AspNetCore.Components;
using Skclusive.Mobx.Component;

namespace Skclusive.Blazor.TodoApp.Components
{
    public class TodoComponent : ObservableComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public IAppState AppState { get; set; }
    }
}
