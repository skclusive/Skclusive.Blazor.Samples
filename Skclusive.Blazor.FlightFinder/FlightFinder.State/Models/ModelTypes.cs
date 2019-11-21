using System;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    public class DateTimeOptions : ICustomTypeOptions<string, DateTime>
    {
        public string Name => "DateTime";

        public DateTime FromSnapshot(string snapshot)
        {
            return DateTime.Parse(snapshot);
        }

        public bool IsTargetType(object value)
        {
            return value is DateTime;
        }

        public string ToSnapshot(DateTime value)
        {
            return value.ToLongTimeString();
        }

        public string Validate(string snapshot)
        {
            if (!DateTime.TryParse(snapshot, out var _))
            {
                return $"{snapshot} is not DateTime value";
            }

            return string.Empty;
        }
    }

    public static class ModelTypes
    {
        public readonly static IType<string, DateTime> DateTimeType = Types.Custom(new DateTimeOptions());
    }
}
