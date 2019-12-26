using WebWindows.Blazor;
using System;

namespace Skclusive.Blazor.Dashboard.Native.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>("Blazor Dashboard", "wwwroot/index.html");
        }
    }
}
