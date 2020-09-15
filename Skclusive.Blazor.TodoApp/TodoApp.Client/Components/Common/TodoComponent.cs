using Skclusive.Blazor.TodoApp.Models;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.Blazor.TodoApp.Components
{
    public class TodoComponent : PureComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public IAppState AppState { get; set; }
    }
}
