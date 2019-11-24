using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using Skclusive.Mobx.StateTree.Proxy;

namespace Skclusive.Blazor.TodoDesktop.Models
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

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<ITodoSnapshot, ITodo> TodoType = Types.Late("LateTodoType", () => Types.
            Object<ITodoSnapshot, ITodo>("TodoType")
            .Proxy(x => x.ActAsProxy<ITodo>())
            .Snapshot(() => new TodoSnapshot())
            .Mutable(o => o.Title, Types.String)
            .Mutable(o => o.Done, Types.Boolean)
            .Action(o => o.Toggle(), (o) => o.Done = !o.Done)
            .Action<string>(o => o.Edit(null), (o, title) => o.Title = title)
            .Action(o => o.Remove(), (o) => o.GetRoot<IAppState>().Remove(o)));

        public readonly static IType<ITodoSnapshot[], IObservableList<INode, ITodo>> TodoListType = Types.Late("LateTodoListType", () => Types.List(TodoType));
    }
}
