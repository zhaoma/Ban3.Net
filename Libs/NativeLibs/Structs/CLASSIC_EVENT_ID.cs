using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Identifies the kernel event for which you want to enable call stack tracing.
    /// Used with the TraceStackTracingInfo class of TraceSetInformation.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-classic_event_id
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLASSIC_EVENT_ID
    {
        /// GUID->_GUID
        public GUID EventGuid;

        /// UCHAR->unsigned char
        public byte Type;

        /// UCHAR[7]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Reserved;

    }
}