using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Returned by EnumerateTraceGuids. Contains information about an event trace provider.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_guid_properties
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_GUID_PROPERTIES
    {
        /// GUID->_GUID
        public GUID Guid;

        /// ULONG->unsigned int
        public uint GuidType;

        /// ULONG->unsigned int
        public uint LoggerId;

        /// ULONG->unsigned int
        public uint EnableLevel;

        /// ULONG->unsigned int
        public uint EnableFlags;

        /// BOOLEAN->BYTE->unsigned char
        public byte IsEnable;
    }
}