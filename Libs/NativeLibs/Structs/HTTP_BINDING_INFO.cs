using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_BINDING_INFO structure is used to associate a URL Group with a request queue.
    /// This structure must be used when setting or querying the HttpServerBindingProperty on a URL Group.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_binding_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_BINDING_INFO
    {
        public HTTP_PROPERTY_FLAGS Flags;
        public IntPtr RequestQueueHandle;
    }
}