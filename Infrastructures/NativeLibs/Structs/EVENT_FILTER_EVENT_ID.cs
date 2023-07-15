using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_FILTER_EVENT_ID structure defines event IDs used in an EVENT_FILTER_DESCRIPTOR structure for an event ID or stack walk filter.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_event_id
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_FILTER_EVENT_ID
    {
        /// BOOLEAN->BYTE->unsigned char
        public byte FilterIn;

        /// UCHAR->unsigned char
        public byte Reserved;

        /// USHORT->unsigned short
        public ushort Count;

        /// USHORT[1]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U2)]
        public ushort[] Events;
    }
}