using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using System;
using Skclusive.Text.Json;
using Skclusive.TodoApp.State;
using static Skclusive.TodoApp.State.AppTypes;

using System.Text.Json.Serialization;

namespace Skclusive.TodoApp.State
{
    public static class TodoAppExtension
    {
        public static void TryAddTodoApp(this IServiceCollection services)
        {
            services.TryAddJsonConverter<JsonTypeConverter<ITodoSnapshot, TodoSnapshot>>();

            services.TryAddJsonConverter<JsonTypeConverter<IAppStateSnapshot, AppStateSnapshot>>();

            services.TryAddSingleton((_) => AppStateType.Create(new AppStateSnapshot
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
