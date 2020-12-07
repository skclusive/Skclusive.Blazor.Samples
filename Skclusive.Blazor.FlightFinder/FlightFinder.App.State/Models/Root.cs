using Skclusive.Core.Collection;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Skclusive.FlightFinder.App.State
{
    #region IRoot

    public interface IRootSnapshot
    {
        ITreeSnapshot Tree { set; get; }
    }

    public interface IRootActions
    {
    }

    public interface IRoot : IRootActions
    {
        ITree Tree { set; get; }
    }

    internal class RootSnapshot : IRootSnapshot
    {
        public ITreeSnapshot Tree { set; get; }
    }

    internal class RootProxy : ObservableProxy<IRoot, INode>, IRoot
    {
        public override IRoot Proxy => this;

        public RootProxy(IObservableObject<IRoot, INode> target) : base(target)
        {
        }

        public ITree Tree
        {
            get => Read<ITree>(nameof(Tree));
            set => Write(nameof(Tree), value);
        }
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IObjectType<IRootSnapshot, IRoot> RootType = Types.
                        Object<IRootSnapshot, IRoot>("Root")
                       .Proxy(x => new RootProxy(x))
                       .Snapshot(() => new RootSnapshot())
                       .Mutable(o => o.Tree, Types.Late("LateTree", () => TreeType));
    }
}
