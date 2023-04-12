using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_STATE_INFO structure is used to enable or disable a Server Session or URL Group.
    /// This structure must be used when setting or querying the HttpServerStateProperty on a URL Group or Server Session.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_state_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_STATE_INFO
    {
       public HTTP_PROPERTY_FLAGS Flags;
      public  HTTP_ENABLED_STATE State;
    }
}