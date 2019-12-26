using System.Runtime.InteropServices;

namespace Skclusive.Blazor.Dashboard.App.View.Common
{
    internal static class PlatformInfo
    {
        public static bool IsWebAssembly { get; }

        static PlatformInfo()
        {
            IsWebAssembly = RuntimeInformation.IsOSPlatform(OSPlatform.Create("WEBASSEMBLY"));
        }
    }
}
