using System;
using System.Collections.Generic;
using System.Linq;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.TodoApp.Models
{
    public class ModelTypes
    {
        public readonly static IObjectType<ITodoSnapshot, ITodo> TodoType = Types.
                        Object<ITodoSnapshot, ITodo>("Todo")
                       .Proxy(x => new TodoProxy(x))
                       .Snapshot(() => new TodoSnapshot())
                       .Mutable(o => o.Title, Types.String)
                       .Mutable(o => o.Done, Types.Boolean)
                       .Action(o => o.Toggle(), (o) => o.Done = !o.Done)
                       .Action<string>(o => o.Edit(null), (o, title) => o.Title = title)
                       .Action(o => o.Remove(), (o) => o.GetRoot<ITodoStore>().Remove(o));

        private readonly static IDictionary<Filter, Func<ITodo, bool>> FilterMapping = new Dictionary<Filter, Func<ITodo, bool>>
        {
            { Filter.All, (_) => true },
            { Filter.Active, (todo) => !todo.Done },
            { Filter.Completed, (todo) => todo.Done }
        };

        public readonly static IType<ITodoSnapshot[], IObservableList<INode, ITodo>> TodoListType = Types.List(TodoType);

        public readonly static IType<Filter, Filter> FilterType = Types.Enumeration("Filter", Filter.Active, Filter.Completed, Filter.All);

        public readonly static IObjectType<ITodoStoreSnapshot, ITodoStore> StoreType = Types.
                        Object<ITodoStoreSnapshot, ITodoStore>("Store")
                       .Proxy(x => new TodoStoreProxy(x))
                       .Snapshot(() => new TodoStoreSnapshot())
                       .Mutable(o => o.Todos, TodoListType)
                       .Mutable(o => o.Filter, FilterType)
                       .View(o => o.TotalCount, Types.Int, (o) => o.Todos.Count())
                       .View(o => o.CompletedCount, Types.Int, (o) => o.Todos.Where(t => t.Done).Count())
                       .View(o => o.FilteredTodos, TodoListType, (o) => o.Todos.Where(FilterMapping[o.Filter]).ToList())
                       .View(o => o.ActiveCount, Types.Int, (o) => o.TotalCount - o.CompletedCount)
                       .Action((o) => o.CompleteAll(), (o) => o.Todos.Select(todo => todo.Done = true).ToList())
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
                       .Action<ITodo>((o) => o.Remove(null), (o, x) => o.Todos.Remove(x));
    }
}
