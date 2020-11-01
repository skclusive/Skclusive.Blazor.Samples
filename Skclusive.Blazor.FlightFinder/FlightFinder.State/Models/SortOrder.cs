using System;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
	public enum SortOrder : int
    {
        Price = 1,

        Duration = 2
    }

	public static class SortOrderExtensions
	{
		public static string ToDisplayString(this SortOrder sortOrder)
		{
			switch (sortOrder)
			{
				case SortOrder.Price: return "Cheapest";

				case SortOrder.Duration: return "Quickest";

                default: throw new ArgumentException("Unknown sort order: " + sortOrder.ToString());
			}
		}
	}

    public partial class AppTypes
    {
        public readonly static IType<SortOrder, SortOrder> SortOderType = Types.Late("LateSortOrderType", () => Types.Enumeration(SortOrder.Price, SortOrder.Duration));
    }
}
