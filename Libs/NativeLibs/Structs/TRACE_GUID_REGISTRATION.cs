using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Used with RegisterTraceGuids to register event trace classes.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_guid_registration
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_GUID_REGISTRATION
    {    
        /// LPCGUID->GUID*
        public System.IntPtr Guid;

        /// HANDLE->void*
        public System.IntPtr RegHandle;

    }
}