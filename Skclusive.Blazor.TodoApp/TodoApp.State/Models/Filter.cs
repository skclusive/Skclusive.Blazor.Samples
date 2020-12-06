using Skclusive.Mobx.StateTree;

namespace Skclusive.TodoApp.State
{
    public enum Filter : int
    {
        Active = 1,

        Completed = 2,

        All = 3
    }

    public partial class AppTypes
    {
        public readonly static IType<Filter, Filter> FilterType = Types.Late("LateFilterType", () => Types.Enumeration(Filter.Active, Filter.Completed, Filter.All));
    }
}
