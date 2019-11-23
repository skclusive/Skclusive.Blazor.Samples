using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.TodoApp.Models
{
    public enum Filter : int
    {
        Active = 1,

        Completed = 2,

        All = 3
    }

    public partial class AppTypes
    {
        public readonly static IType<Filter, Filter> FilterType = Types.Late("LateFilterType", () => Types.Enumeration("FilterType", Filter.Active, Filter.Completed, Filter.All));
    }
}
