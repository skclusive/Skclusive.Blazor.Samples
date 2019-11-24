using System;
using Newtonsoft.Json;

namespace Skclusive.Blazor.TodoDesktop.Converters
{
    public class JsonTypeConverter<I, T> : JsonConverter
        where T : class, I
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(I));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(T));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(T));
        }
    }
}
