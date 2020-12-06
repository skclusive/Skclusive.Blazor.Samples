using System;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Reactive.App.State
{
    #region ICounter

    public interface ICounter
    {

        bool Ticking { get; set; }

        int Count { get; set; }
    }

    public interface ICounterActions
    {
        void Begin();

        void Continue();

        void End();
    }

    public interface ICounterObservable : ICounter, ICounterActions
    {
    }

    public class Counter : ICounter
    {
        public int Count { get; set; }

        public bool Ticking { get; set; }
    }

    internal class CounterProxy : ObservableProxy<ICounterObservable, INode>, ICounterObservable
    {
        public override ICounterObservable Proxy => this;

        public CounterProxy(IObservableObject<ICounterObservable, INode> target) : base(target)
        {
        }

        public int Count
        {
            get => Read<int>(nameof(Count));
            set => Write(nameof(Count), value);
        }

        public bool Ticking
        {
            get => Read<bool>(nameof(Ticking));
            set => Write(nameof(Ticking), value);
        }

        public void Begin()
        {
            (Target as dynamic).Begin();
        }

        public void Continue()
        {
            (Target as dynamic).Continue();
        }

        public void End()
        {
            (Target as dynamic).End();
        }
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<ICounter, ICounterObservable> CounterType = Types.Late("LateCounterType", () => Types.
            Object<ICounter, ICounterObservable>("CounterType")
            .Proxy(x => new CounterProxy(x))
            .Snapshot(() => new Counter())
            .Mutable(o => o.Count, Types.Int)
            .Mutable(o => o.Ticking, Types.Boolean)
            .Action(o => o.Begin(), (o) => o.Ticking = true)
            .Action(o => o.Continue(), (o) => o.Count++)
            .Action(o => o.End(), (o) => o.Ticking = false));
    }
}
