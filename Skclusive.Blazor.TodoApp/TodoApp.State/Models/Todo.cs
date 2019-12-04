using Skclusive.Blazor.TodoApp.Extension;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.TodoApp.Models
{
    #region ITodo

    public interface ITodoSnapshot
    {
        string Title { set; get; }

        bool Done { set; get; }
    }

    public interface ITodoActions
    {
        void Toggle();

        void Remove();

        void Edit(string title);
    }

    public interface ITodo : ITodoSnapshot, ITodoActions
    {
    }

    public class TodoSnapshot : ITodoSnapshot
    {
        public string Title { set; get; }

        public bool Done { set; get; }
    }

    internal class TodoProxy : ObservableProxy<ITodo, INode>, ITodo
    {
        public override ITodo Proxy => this;

        public TodoProxy(IObservableObject<ITodo, INode> target) : base(target)
        {
        }

        public string Title
        {
            get => Read<string>(nameof(Title));
            set => Write(nameof(Title), value);
        }

        public bool Done
        {
            get => Read<bool>(nameof(Done));
            set => Write(nameof(Done), value);
        }

        public void Toggle()
        {
            (Target as dynamic).Toggle();
        }

        public void Remove()
        {
            (Target as dynamic).Remove();
        }

        public void Edit(string title)
        {
            (Target as dynamic).Edit(title);
        }
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<ITodoSnapshot, ITodo> TodoType = Types.Late("LateTodoType", () => Types.
            Object<ITodoSnapshot, ITodo>("TodoType")
            .Proxy(x => new TodoProxy(x))
            .Snapshot(() => new TodoSnapshot())
            .Mutable(o => o.Title, Types.String)
            .Mutable(o => o.Done, Types.Boolean)
            .Action(o => o.Toggle(), (o) => o.Done = !o.Done)
            .Action<string>(o => o.Edit(null), (o, title) => o.Title = title)
            .Action(o => o.Remove(), (o) => o.GetRoot<IAppState>().Remove(o)));

        public readonly static IType<ITodoSnapshot[], IObservableList<INode, ITodo>> TodoListType = Types.Late("LateTodoListType", () => Types.List(TodoType));
    }
}
