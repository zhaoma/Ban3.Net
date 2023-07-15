using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the session and the information that the session used to enable the provider.
    /// This information is returned by EnumerateTraceGuidsEx as part of a TRACE_PROVIDER_INSTANCE_INFO block.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_enable_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_ENABLE_INFO
    {
        /// ULONG->unsigned int
        public uint IsEnabled;

        /// UCHAR->unsigned char
        public byte Level;

        /// UCHAR->unsigned char
        public byte Reserved1;

        /// USHORT->unsigned short
        public ushort LoggerId;

        /// ULONG->unsigned int
        public uint EnableProperty;

        /// ULONG->unsigned int
        public uint Reserved2;

        /// ULONGLONG->unsigned __int64
        public ulong MatchAnyKeyword;

        /// ULONGLONG->unsigned __int64
        public ulong MatchAllKeyword;
    }
}