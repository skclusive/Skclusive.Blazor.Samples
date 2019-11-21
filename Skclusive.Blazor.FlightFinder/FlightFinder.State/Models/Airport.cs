using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.FlightFinder.Models
{
    #region IAirport

    public interface IAirportSnapshot
    {
        string Code { get; set; }

		string DisplayName { get; set; }
    }

    public interface IAirportActions
    {
    }

    public interface IAirport : IAirportSnapshot, IAirportActions
    {
    }

    public class AirportSnapshot : IAirportSnapshot
    {
        public string Code { get; set; }

		public string DisplayName { get; set; }
    }

    internal class AirportProxy : ObservableProxy<IAirport, INode>, IAirport
    {
        public override IAirport Proxy => this;

        public AirportProxy(IObservableObject<IAirport, INode> target) : base(target)
        {
        }

        public string Code
        {
            get => Read<string>(nameof(Code));
            set => Write(nameof(Code), value);
        }

        public bool DisplayName
        {
            get => Read<bool>(nameof(DisplayName));
            set => Write(nameof(DisplayName), value);
        }
    }

    public class AirportSnapshotConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IAirportSnapshot));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(AirportSnapshot));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(AirportSnapshot));
        }
    }

    #endregion
}
