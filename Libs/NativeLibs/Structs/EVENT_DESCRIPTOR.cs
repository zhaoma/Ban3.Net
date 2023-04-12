using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_DESCRIPTOR structure contains information (metadata) about an ETW event.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_DESCRIPTOR
    {

        /// USHORT->unsigned short
        public ushort Id;

        /// UCHAR->unsigned char
        public byte Version;

        /// UCHAR->unsigned char
        public byte Channel;

        /// UCHAR->unsigned char
        public byte Level;

        /// UCHAR->unsigned char
        public byte Opcode;

        /// USHORT->unsigned short
        public ushort Task;

        /// ULONGLONG->unsigned __int64
        public ulong Keyword;
    }
}