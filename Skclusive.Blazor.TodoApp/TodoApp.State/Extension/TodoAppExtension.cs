using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using Skclusive.Blazor.TodoApp.Models;
using Skclusive.Blazor.TodoApp.Converters;

namespace Skclusive.Blazor.TodoApp.Extension
{
    public static class TodoAppExtension
    {
        public static void AddTodoApp(this IServiceCollection services)
        {
            services.AddSingleton<JsonConverter, TodoSnapshotConverter>();

            services.AddSingleton((_) => AppTypes.AppStateType.Create(new AppStateSnapshot
            {
                Filter = Filter.All,

                Todos = new TodoSnapshot[]
                {
                    new TodoSnapshot { Title = "Get coffee" },

                    new TodoSnapshot { Title = "Learn Blazor" }
                }
            }));
        }
    }
}
