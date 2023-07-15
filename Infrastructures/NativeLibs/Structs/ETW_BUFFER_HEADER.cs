using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The header structure of an ETW buffer.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-etw_buffer_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ETW_BUFFER_HEADER
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] Reserved1;

        /// <summary>
        /// The time when the buffer was flushed. It will be in the raw clock type of the session from which the buffer was collected (for example, QueryPerformanceCounter, CPU timestamp counter, or GetSystemTimeAsFileTime).
        /// </summary>
        public LARGE_INTEGER TimeStamp;

        /// <summary>
        /// Reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] Reserved2;

        /// <summary>
        /// Contains information about the processor and logger that generated this buffer. See ETW_BUFFER_CONTEXT.
        /// </summary>
        public ETW_BUFFER_CONTEXT ClientContext;

        /// ULONG->unsigned int
        public uint Reserved3;

        /// <summary>
        /// The size of the valid data in the buffer.
        /// This is the size of the ETW_BUFFER_HEADER and the event data.
        /// When a buffer is copied, it is common to only allocate enough memory to store the valid data (for example, only FilledBytes bytes are allocated and copied),
        /// so recipients of a buffer should not read beyond this offset.
        /// </summary>
        public uint FilledBytes;

        /// <summary>
        /// Reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.U4)]
        public uint[] Reserved4;

    }
}