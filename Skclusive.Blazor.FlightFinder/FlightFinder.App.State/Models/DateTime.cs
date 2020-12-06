using System;
using Skclusive.Mobx.StateTree;

namespace Skclusive.FlightFinder.App.State
{
    internal class DateTimeOptions : ICustomTypeOptions<DateTime, DateTime>
    {
        public string Name => "DateTime";

        public DateTime FromSnapshot(DateTime snapshot)
        {
            return snapshot;
        }

        public bool IsTargetType(object value)
        {
            return value is DateTime;
        }

        public DateTime ToSnapshot(DateTime value)
        {
            return value;
        }

        public string Validate(DateTime snapshot)
        {
            return string.Empty;
        }
    }

    public partial class AppTypes
    {
        public readonly static IType<DateTime, DateTime> DateTimeType = Types.Late("LateDateTimeType", () => Types.Custom(new DateTimeOptions()));
    }
}
