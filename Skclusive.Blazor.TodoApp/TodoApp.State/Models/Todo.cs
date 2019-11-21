using System;
using Newtonsoft.Json;
using Skclusive.Mobx.Observable;
using Skclusive.Mobx.StateTree;

namespace Skclusive.Blazor.TodoApp.Models
{
    #region ITodo

    public interface ITodoSnapshot
    {
        string Title { set; get; }

        bool Done { set; get; }
    }

    public interface ITodoActions
    {
        void Toggle();

        void Remove();

        void Edit(string title);
    }

    public interface ITodo : ITodoSnapshot, ITodoActions
    {
    }

    public class TodoSnapshot : ITodoSnapshot
    {
        public string Title { set; get; }

        public bool Done { set; get; }
    }

    internal class TodoProxy : ObservableProxy<ITodo, INode>, ITodo
    {
        public override ITodo Proxy => this;

        public TodoProxy(IObservableObject<ITodo, INode> target) : base(target)
        {
        }

        public string Title
        {
            get => Read<string>(nameof(Title));
            set => Write(nameof(Title), value);
        }

        public bool Done
        {
            get => Read<bool>(nameof(Done));
            set => Write(nameof(Done), value);
        }

        public void Toggle()
        {
            (Target as dynamic).Toggle();
        }

        public void Remove()
        {
            (Target as dynamic).Remove();
        }

        public void Edit(string title)
        {
            (Target as dynamic).Edit(title);
        }
    }

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

    #endregion
}
