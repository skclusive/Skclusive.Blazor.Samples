using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Skclusive.Blazor.TodoDesktop.Models;
using static Skclusive.Blazor.TodoDesktop.Models.AppTypes;

namespace Skclusive.Blazor.TodoDesktop.Extension
{
    public static class TodoDesktopExtension
    {
        public static void AddTodoDesktop(this IServiceCollection services)
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
