using WebWindows.Blazor;
using System;

namespace Skclusive.Blazor.Messenger.Native.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>("Blazor Messenger", "wwwroot/index.html");
        }
    }
}
