using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_FILTER_DESCRIPTOR structure defines the filter data that a session passes to the provider's enable callback function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_FILTER_DESCRIPTOR
    {
        /// ULONGLONG->unsigned __int64
        public ulong Ptr;

        /// ULONG->unsigned int
        public uint Size;

        /// ULONG->unsigned int
        public uint Type;
    }
}