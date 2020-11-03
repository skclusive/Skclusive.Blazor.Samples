using Microsoft.Extensions.DependencyInjection;
using Skclusive.Extensions.DependencyInjection;
using System;
using Skclusive.Blazor.TodoApp.Models;
using static Skclusive.Blazor.TodoApp.Models.AppTypes;

using System.Text.Json.Serialization;

namespace Skclusive.Blazor.TodoApp.Extension
{
    public static class TodoAppExtension
    {
        public static void AddTodoApp(this IServiceCollection services)
        {
            services.AddSingleton<JsonConverter, JsonTypeConverter<ITodoSnapshot, TodoSnapshot>>();

            services.AddSingleton<JsonConverter, JsonTypeConverter<IAppStateSnapshot, AppStateSnapshot>>();

            services.AddSingleton((_) => AppStateType.Create(new AppStateSnapshot
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
