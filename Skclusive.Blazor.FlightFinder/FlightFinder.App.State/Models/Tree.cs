using Skclusive.Core.Collection;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Skclusive.FlightFinder.App.State
{
    #region ITree

    public interface ITreeSnapshot
    {
        IBranchSnapshot[] Branches { set; get; }
    }

    public interface ITreeActions
    {
        void AddBranch(IBranchSnapshot branch);
    }

    public interface ITree : ITreeActions
    {
        IList<IBranch> Branches { set; get; }
    }

    internal class TreeSnapshot : ITreeSnapshot
    {
        public IBranchSnapshot[] Branches { set; get; }
    }

    internal class TreeProxy : ObservableProxy<ITree, INode>, ITree
    {
        public override ITree Proxy => this;

        public TreeProxy(IObservableObject<ITree, INode> target) : base(target)
        {
        }

        public IList<IBranch> Branches
        {
            get => Read<IList<IBranch>>(nameof(Branches));
            set => Write(nameof(Branches), value);
        }

        public void AddBranch(IBranchSnapshot branch)
        {
            (Target as dynamic).AddBranch(branch);
        }
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IObjectType<ITreeSnapshot, ITree> TreeType = Types.
                        Object<ITreeSnapshot, ITree>("Tree")
                       .Proxy(x => new TreeProxy(x))
                       .Snapshot(() => new TreeSnapshot())
                       .Mutable(o => o.Branches, Types.List(Types.Late("LateBranch", () => BranchType)))
                        .Action<IBranchSnapshot>(o => o.AddBranch(default), (o, branch) => o.Branches.Add(BranchType.Create(branch)));
    }
}
