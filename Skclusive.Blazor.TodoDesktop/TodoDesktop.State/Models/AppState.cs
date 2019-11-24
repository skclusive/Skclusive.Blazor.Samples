using Skclusive.Mobx.StateTree;
using System.Collections.Generic;
using System.Linq;
using System;
using Skclusive.Mobx.StateTree.Proxy;

namespace Skclusive.Blazor.TodoDesktop.Models
{
    public interface IAppState
    {
        IList<ITodo> Todos { set; get; }

        IList<ITodo> FilteredTodos { get; }

        int TotalCount { get; }

        int ActiveCount { get; }

        int CompletedCount { get; }

        bool AllCompleted { get; }

        Filter Filter { set; get; }

        void AddTodo(string title);

        void SetFilter(Filter filter);

        void Remove(ITodo todo);

        void CompleteAll();

        void ClearCompleted();
    }

    public partial class AppTypes
    {
        private readonly static IDictionary<Filter, Func<ITodo, bool>> FilterMapping = new Dictionary<Filter, Func<ITodo, bool>>
        {
            { Filter.All, (_) => true },
            { Filter.Active, (todo) => !todo.Done },
            { Filter.Completed, (todo) => todo.Done }
        };

        public readonly static IType<IDictionary<string, object>, IAppState> AppStateType = Types.Late("LateAppStateType", () => Types.
            Object<IAppState>("AppStateType")
            .Proxy(x => x.ActAsProxy<IAppState>())
            .Mutable(o => o.Todos, TodoListType)
            .Mutable(o => o.Filter, FilterType)
            .View(o => o.TotalCount, Types.Int, (o) => o.Todos.Count())
            .View(o => o.CompletedCount, Types.Int, (o) => o.Todos.Where(t => t.Done).Count())
            .View(o => o.FilteredTodos, TodoListType, (o) => o.Todos.Where(FilterMapping[o.Filter]).ToList())
            .View(o => o.ActiveCount, Types.Int, (o) => o.TotalCount - o.CompletedCount)
            .View(o => o.AllCompleted, Types.Boolean, (o) => o.CompletedCount == o.TotalCount)
            .Action((o) => o.CompleteAll(), (o) =>
            {
                var toggle = !o.AllCompleted;
                foreach (var todo in o.Todos)
                    todo.Done = toggle;
            })
            .Action((o) => o.ClearCompleted(), (o) =>
            {
                foreach (var completed in o.Todos.Where(todo => todo.Done).ToArray())
                    o.Todos.Remove(completed);
            })
            .Action<Filter>((o) => o.SetFilter(Filter.All), (o, filter) => o.Filter = filter)
            .Action<string>((o) => o.AddTodo(null), (o, title) =>
            {
                o.Todos.Insert(0, TodoType.Create(new Dictionary<string, object> { { "Title", title } }));
            })
            .Action<ITodo>((o) => o.Remove(null), (o, x) => o.Todos.Remove(x)));
    }
}
