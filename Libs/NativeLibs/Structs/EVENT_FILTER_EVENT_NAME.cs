using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_FILTER_EVENT_NAME structure defines event IDs used in an EVENT_FILTER_DESCRIPTOR structure for an event name or stalk walk name filter.
    /// This filter will only be applied to events that are otherwise enabled on the logging session, via level/keyword in the enable call.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_event_name
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_FILTER_EVENT_NAME
    {

        /// ULONGLONG->unsigned __int64
        public ulong MatchAnyKeyword;

        /// ULONGLONG->unsigned __int64
        public ulong MatchAllKeyword;

        /// UCHAR->unsigned char
        public byte Level;

        /// BOOLEAN->BYTE->unsigned char
        public byte FilterIn;

        /// USHORT->unsigned short
        public ushort NameCount;

        /// UCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Names;
    }
}