using AppKit;
using Microsoft.MobileBlazorBindings.WebView.macOS;

namespace Skclusive.Dashboard.Host.MacOS
{
    internal static class MainClass
    {
        private static void Main(string[] args)
        {
            BlazorHybridMacOS.Init();
            NSApplication.Init();
            NSApplication.SharedApplication.Delegate = new AppDelegate();
            NSApplication.Main(args);
        }
    }
}
