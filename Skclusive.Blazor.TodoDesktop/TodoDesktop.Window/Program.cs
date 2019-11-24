using WebWindows.Blazor;
using System;

namespace Skclusive.Blazor.TodoDesktop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>("Blazor TodoDesktop", "wwwroot/index.html");
        }
    }
}
