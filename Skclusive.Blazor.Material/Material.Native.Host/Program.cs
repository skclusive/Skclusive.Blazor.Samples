using WebWindows.Blazor;
using System;

namespace Skclusive.Blazor.Material.Native.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>("Blazor Material", "wwwroot/index.html");
        }
    }
}
