using System.Collections.Generic;

namespace Skclusive.Messenger.App.View
{
    public static class ChatSamples
    {
        public static readonly IEnumerable<ChatItem> Chats = new List<ChatItem>
        {
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=11",
                Name = "Jordyn Frank",
                Info = "You sent a photo • 2:04 PM",
                Responded = true
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=12",
                Name = "Marwan Combs",
                Info = "Where r u? • 1:54 PM",
                Bold = true
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=13",
                Name = "Imaad Casey",
                Info = "You: Good to see u • SAT",
                Active = true
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=14",
                Name = "Philip Rhodes",
                Info = "You: Lorem ipsum • THU",
                Responded = true
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=15",
                Name = "Chardonnay Raymond",
                Info = "Chardonnay called you • THU"
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=16",
                Name = "Akram Farmer",
                Info = "You: still look forw... • THU",
                Responded = true
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=17",
                Name = "Nichola Mackie",
                Info = "You: https://mui... • DEC 10"
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=18",
                Name = "Ines Page",
                Info = "You called Ines • DEC 9"
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=19",
                Name = "Ephraim Gonzalez",
                Info = "I think you can d... • DEC 9",
                Responded = true
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=20",
                Name = "Tyrell Stark",
                Info = "Okay, I think... • DEC 6"
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=21",
                Name = "Tasha Whitmore",
                Info = "You sent an attach... • NOV 30"
            },
            new ChatItem
            {
                Avatar = "https://i.pravatar.cc/300?img=22",
                Name = "Hawwa Davenport",
                Info = "okay kub • NOV 28"
            }
        };
    }
}
