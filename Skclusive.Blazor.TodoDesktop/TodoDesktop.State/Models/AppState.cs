using Skclusive.Mobx.StateTree;
using System.Collections.Generic;
using System.Linq;
using System;
using Skclusive.Mobx.StateTree.Proxy;

namespace Skclusive.Blazor.TodoDesktop.Models
{
    #region IAppState

    public interface IAppStateSnapshot
    {
        Filter Filter { set; get; }

        ITodoSnapshot[] Todos { set; get; }
    }

    public interface IAppStateActions
    {
        void AddTodo(string title);

        void SetFilter(Filter filter);

        void Remove(ITodo todo);

        void CompleteAll();

        void ClearCompleted();
    }

    public interface IAppState : IAppStateActions
    {
        IList<ITodo> Todos { set; get; }

        IList<ITodo> FilteredTodos { get; }

        int TotalCount { get; }

        int ActiveCount { get; }

        int CompletedCount { get; }

        bool AllCompleted { get; }

        Filter Filter { set; get; }
    }

    public class AppStateSnapshot : IAppStateSnapshot
    {
        public Filter Filter { set; get; }

        public ITodoSnapshot[] Todos { set; get; }
    }

    #endregion

    public partial class AppTypes
    {
        private readonly static IDictionary<Filter, Func<ITodo, bool>> FilterMapping = new Dictionary<Filter, Func<ITodo, bool>>
        {
            { Filter.All, (_) => true },
            { Filter.Active, (todo) => !todo.Done },
            { Filter.Completed, (todo) => todo.Done }
        };

        public readonly static IType<IAppStateSnapshot, IAppState> AppStateType = Types.Late("LateAppStateType", () => Types.
            Object<IAppStateSnapshot, IAppState>("AppStateType")
            .Proxy(x => x.ActAsProxy<IAppState>())
            .Snapshot(() => new AppStateSnapshot())
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
                o.Todos.Insert(0, TodoType.Create(new TodoSnapshot { Title = title }));
            })
            .Action<ITodo>((o) => o.Remove(null), (o, x) => o.Todos.Remove(x)));
    }
}
