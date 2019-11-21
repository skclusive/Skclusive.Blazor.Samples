using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using System.Collections.Generic;
using System.Linq;

namespace Skclusive.Blazor.TodoApp.Models
{
    #region ITodoStore

    public interface ITodoStoreSnapshot
    {
        string Filter { set; get; }

        ITodoSnapshot[] Todos { set; get; }
    }

    public interface ITodoStoreActions
    {
        void AddTodo(string title);

        void SetFilter(string filter);

        void Remove(ITodo todo);

        void CompleteAll();

        void ClearCompleted();
    }

    public interface ITodoStore : ITodoStoreActions
    {
        IList<ITodo> Todos { set; get; }

        IList<ITodo> FilteredTodos { get; }

        int TotalCount { get; }

        int ActiveCount { get; }

        int CompletedCount { get; }

        string Filter { set; get; }
    }

    public class TodoStoreSnapshot : ITodoStoreSnapshot
    {
        public TodoStoreSnapshot()
        {
        }

        public TodoStoreSnapshot(TodoSnapshot[] todos)
        {
            Todos = todos;
        }

        public string Filter { set; get; }

        public ITodoSnapshot[] Todos { set; get; }
    }

    internal class TodoStoreProxy : ObservableProxy<ITodoStore, INode>, ITodoStore
    {
        public override ITodoStore Proxy => this;

        public TodoStoreProxy(IObservableObject<ITodoStore, INode> target) : base(target)
        {
        }

        public string Filter
        {
            get => Read<string>(nameof(Filter));
            set => Write(nameof(Filter), value);
        }

        public IList<ITodo> Todos
        {
            get => Read<IList<ITodo>>(nameof(Todos));
            set => Write(nameof(Todos), value);
        }

        public IList<ITodo> FilteredTodos => Read<IList<ITodo>>(nameof(FilteredTodos));

        public int TotalCount => Read<int>(nameof(TotalCount));

        public int ActiveCount => Read<int>(nameof(ActiveCount));

        public int CompletedCount => Read<int>(nameof(CompletedCount));

        public void AddTodo(string title)
        {
            (Target as dynamic).AddTodo(title);
        }

        public void Remove(ITodo todo)
        {
            (Target as dynamic).Remove(todo);
        }

        public void SetFilter(string filter)
        {
            (Target as dynamic).SetFilter(filter);
        }

        public void CompleteAll()
        {
            (Target as dynamic).CompleteAll();
        }

        public void ClearCompleted()
        {
            (Target as dynamic).ClearCompleted();
        }
    }

    #endregion
}
