using Skclusive.TodoApp.State;
using Microsoft.AspNetCore.Components;
using Skclusive.Core.Component;

namespace Skclusive.TodoApp.Client
{
    public class TodoComponent : PureComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public IAppState AppState { get; set; }
    }
}
