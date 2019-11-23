using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;
using Skclusive.Blazor.TodoApp.Models;

namespace Skclusive.Blazor.TodoApp.Converters
{
    public class TodoSnapshotConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ITodoSnapshot));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(TodoSnapshot));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(TodoSnapshot));
        }
    }
}
