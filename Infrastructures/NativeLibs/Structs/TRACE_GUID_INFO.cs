using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Returned by EnumerateTraceGuidsEx.
    /// Defines the header to the list of sessions that enabled a provider.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_guid_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_GUID_INFO
    {    
        /// ULONG->unsigned int
        public uint InstanceCount;

        /// ULONG->unsigned int
        public uint Reserved;

    }
}