
namespace Skclusive.Blazor.Messenger.App.View
{
    public enum ChatMessageType
    {
        Image,

        Text
    }

    public class ChatMessage
    {
        public ChatMessageType Type { set; get; }

        public string Text { set; get; }

        public string Src { set; get; }

        public string Alt { set; get; }
    }
}
