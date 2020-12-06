using System.Collections.Generic;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using Skclusive.Mobx.StateTree.Proxy;

namespace Skclusive.TodoDesktop.State
{
    public interface ITodo
    {
        string Title { set; get; }

        bool Done { set; get; }

        void Toggle();

        void Remove();

        void Edit(string title);
    }

    public partial class AppTypes
    {
        public readonly static IType<IDictionary<string, object>, ITodo> TodoType = Types.Late("LateTodoType", () => Types.
            Object<ITodo>("TodoType")
            .Proxy(x => x.ActAsProxy<ITodo>())
            .Mutable(o => o.Title, Types.String)
            .Mutable(o => o.Done, Types.Boolean)
            .Action(o => o.Toggle(), (o) => o.Done = !o.Done)
            .Action<string>(o => o.Edit(null), (o, title) => o.Title = title)
            .Action(o => o.Remove(), (o) => o.GetRoot<IAppState>().Remove(o)));

        public readonly static IType<IDictionary<string, object>[], IObservableList<INode, ITodo>> TodoListType = Types.Late("LateTodoListType", () => Types.List(TodoType));
    }
}
