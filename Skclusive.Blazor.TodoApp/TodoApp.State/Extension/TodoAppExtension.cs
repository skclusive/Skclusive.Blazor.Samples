using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skclusive.Extensions.DependencyInjection;
using System;
using Skclusive.Text.Json;
using Skclusive.Blazor.TodoApp.Models;
using static Skclusive.Blazor.TodoApp.Models.AppTypes;

using System.Text.Json.Serialization;

namespace Skclusive.Blazor.TodoApp.Extension
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
