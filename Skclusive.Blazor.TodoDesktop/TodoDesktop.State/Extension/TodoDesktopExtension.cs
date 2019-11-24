using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Skclusive.Blazor.TodoDesktop.Models;
using Skclusive.Blazor.TodoDesktop.Converters;
using static Skclusive.Blazor.TodoDesktop.Models.AppTypes;

namespace Skclusive.Blazor.TodoDesktop.Extension
{
    public static class TodoDesktopExtension
    {
        public static void AddTodoDesktop(this IServiceCollection services)
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
