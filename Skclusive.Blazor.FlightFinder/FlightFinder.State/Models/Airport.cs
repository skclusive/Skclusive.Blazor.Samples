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

        public string DisplayName
        {
            get => Read<string>(nameof(DisplayName));
            set => Write(nameof(DisplayName), value);
        }
    }

    #endregion

    public partial class AppTypes
    {
        public readonly static IType<IAirportSnapshot, IAirport> AirportType = Types.Late("LateAirportType", () => Types.
            Object<IAirportSnapshot, IAirport>("AirportType")
            .Proxy(x => new AirportProxy(x))
            .Snapshot(() => new AirportSnapshot())
            .Mutable(o => o.Code, Types.String)
            .Mutable(o => o.DisplayName, Types.String));

         public readonly static IType<IAirportSnapshot[], IObservableList<INode, IAirport>> AirportListType = Types.Late("LateAirportListType", () => Types.Optional(Types.List(AirportType), Array.Empty<IAirportSnapshot>()));
    }
}
