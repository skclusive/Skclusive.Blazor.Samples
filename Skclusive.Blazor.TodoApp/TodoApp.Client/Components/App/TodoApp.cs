using System;
using System.Threading.Tasks;
using Skclusive.Blazor.TodoApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using Skclusive.Script.DevTools.StateTree;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.TodoApp.Components
{
    public class TodoAppComponent : DisposableComponentBase
    {
        [Inject]
        public IStateTreeTool<AppStateSnapshot> StateTreeTool { get; set; }

        [Inject]
        public IAppState AppState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            StateTreeTool.Configure(AppState);
        }

        protected override async Task OnAfterMountAsync()
        {
            await StateTreeTool.ConnectAsync();
        }

        protected override async ValueTask DisposeAsync()
        {
            await StateTreeTool.DisposeAsync();
        }
    }
}
