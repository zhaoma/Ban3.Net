using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_FILTER_LEVEL_KW structure defines event IDs used in an EVENT_FILTER_DESCRIPTOR structure for a stack walk level-keyword filter.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_level_kw
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_FILTER_LEVEL_KW
    {
        /// ULONGLONG->unsigned __int64
        public ulong MatchAnyKeyword;

        /// ULONGLONG->unsigned __int64
        public ulong MatchAllKeyword;

        /// UCHAR->unsigned char
        public byte Level;

        /// BOOLEAN->BYTE->unsigned char
        public byte FilterIn;

    }
}