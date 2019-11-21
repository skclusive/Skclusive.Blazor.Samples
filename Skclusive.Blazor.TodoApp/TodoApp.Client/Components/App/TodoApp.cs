using System;
using System.Threading.Tasks;
using Skclusive.Blazor.TodoApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Skclusive.Core.Component;
using Skclusive.Script.DevTools.StateTree;
using Skclusive.Mobx.StateTree;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Skclusive.Blazor.TodoApp.Components
{
    public class TodoAppComponent : DisposableComponentBase
    {
        [Inject]
        public IStateTreeTool<TodoStoreSnapshot> StateTreeTool { get; set; }

        protected ITodoStore TodoStore { get; set; }

        public TodoAppComponent()
        {
            TodoStore = ModelTypes.StoreType.Create(new TodoStoreSnapshot
            {
                Filter = "ShowAll",

                Todos = new TodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" },

                    new TodoSnapshot { Title = "Learn Blazor" }
                }
            });
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            RunTimeout(() =>
            {
                _ = StateTreeTool.ConnectAsync(TodoStore);

            }, 100);
        }

        protected override void Dispose()
        {
            base.Dispose();

            StateTreeTool?.Dispose();
        }
    }
}
