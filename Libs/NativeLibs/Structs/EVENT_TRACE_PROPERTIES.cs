using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_TRACE_PROPERTIES structure contains information about an event tracing session.
    /// You use this structure with APIs such as StartTrace and ControlTrace when defining, updating, or querying the properties of a session.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_trace_properties
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE_PROPERTIES
    {

        /// HANDLE->void*
        public System.IntPtr Wnode;

        /// ULONG->unsigned int
        public uint BufferSize;

        /// ULONG->unsigned int
        public uint MinimumBuffers;

        /// ULONG->unsigned int
        public uint MaximumBuffers;

        /// ULONG->unsigned int
        public uint MaximumFileSize;

        /// ULONG->unsigned int
        public uint LogFileMode;

        /// ULONG->unsigned int
        public uint FlushTimer;

        /// ULONG->unsigned int
        public uint EnableFlags;

        /// Anonymous_749514f9_6262_4808_ac0e_ab05fcbe8a77
        public EVENT_TRACE_PROPERTIES_UNION Union1;

        /// ULONG->unsigned int
        public uint NumberOfBuffers;

        /// ULONG->unsigned int
        public uint FreeBuffers;

        /// ULONG->unsigned int
        public uint EventsLost;

        /// ULONG->unsigned int
        public uint BuffersWritten;

        /// ULONG->unsigned int
        public uint LogBuffersLost;

        /// ULONG->unsigned int
        public uint RealTimeBuffersLost;

        /// HANDLE->void*
        public System.IntPtr LoggerThreadId;

        /// ULONG->unsigned int
        public uint LogFileNameOffset;

        /// ULONG->unsigned int
        public uint LoggerNameOffset;

    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct EVENT_TRACE_PROPERTIES_UNION
    {

        /// LONG->int
        [FieldOffset(0)]
        public int AgeLimit;

        /// LONG->int
        [FieldOffset(0)]
        public int FlushThreshold;
    }
}