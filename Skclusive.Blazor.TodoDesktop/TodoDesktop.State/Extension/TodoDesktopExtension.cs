using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using static Skclusive.TodoDesktop.State.AppTypes;

namespace Skclusive.TodoDesktop.State
{
    public static class TodoDesktopExtension
    {
        public static void TryAddTodoDesktop(this IServiceCollection services)
        {
            services.AddSingleton((_) => AppStateType.Create(new Dictionary<string, object>
            {
                { "Filter", Filter.All },

                { "Todos", new Dictionary<string, object>[]
                    {
                        new Dictionary<string, object>
                        {
                            { "Title",  "Get coffee" }
                        },
                        new Dictionary<string, object>
                        {
                            { "Title",  "Learn Blazor" }
                        }
                    }
                }
            }));
        }
    }
}
