using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the header data that must precede the filter data that is defined in the instrumentation manifest.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_filter_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_FILTER_HEADER
    {

        /// USHORT->unsigned short
        public ushort Id;

        /// UCHAR->unsigned char
        public byte Version;

        /// UCHAR[5]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string Reserved;

        /// ULONGLONG->unsigned __int64
        public ulong InstanceId;

        /// ULONG->unsigned int
        public uint Size;

        /// ULONG->unsigned int
        public uint NextOffset;
    }
}