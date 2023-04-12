using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines information about the event.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_HEADER
    {
        /// <summary>
        /// Size of the event record, in bytes.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Reserved.
        /// </summary>
        public ushort HeaderType;

        /// <summary>
        /// Flags that provide information about the event such as the type of session it was logged to and if the event contains extended data.
        /// </summary>
        public EVENT_HEADER_FLAGS Flags;

        /// <summary>
        /// Indicates the source to use for parsing the event data.
        /// </summary>
        public EVENT_HEADER_PROPERTY EventProperty;

        /// <summary>
        /// Identifies the thread that generated the event.
        /// </summary>
        public uint ThreadId;

        /// <summary>
        /// Identifies the process that generated the event.
        /// </summary>
        public uint ProcessId;

        /// <summary>
        /// Contains the time that the event occurred.
        /// The resolution is system time unless the ProcessTraceMode member of EVENT_TRACE_LOGFILE contains the PROCESS_TRACE_MODE_RAW_TIMESTAMP flag,
        /// in which case the resolution depends on the value of the Wnode.
        /// ClientContext member of EVENT_TRACE_PROPERTIES at the time the controller created the session.
        /// </summary>
        public LARGE_INTEGER TimeStamp;

        /// <summary>
        /// GUID that uniquely identifies the provider that logged the event.
        /// </summary>
        public GUID ProviderId;

        /// <summary>
        /// Defines the information about the event such as the event identifier and severity level.
        /// </summary>
        public EVENT_DESCRIPTOR EventDescriptor;

        /// Anonymous_17c2a8f6_21d1_4147_b9d8_479d0235c5bb
        public EVENT_HEADER_UNION Union1;

        /// <summary>
        /// Identifier that relates two events.
        /// </summary>
        public GUID ActivityId;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct EVENT_HEADER_UNION
    {

        /// Anonymous_fec0f95e_2983_48f7_bcbe_4c94ac097fa8
        [FieldOffset(0)]
        public EVENT_HEADER_DUMMY DUMMYSTRUCTNAME;

        /// <summary>
        /// For private sessions, the elapsed execution time for user-mode instructions, in CPU ticks.
        /// </summary>
        [FieldOffset(0)]
        public ulong ProcessorTime;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_HEADER_DUMMY
    {
        /// <summary>
        /// Elapsed execution time for kernel-mode instructions, in CPU time units.
        /// If you are using a private session, use the value in the ProcessorTime member instead.
        /// </summary>
        public uint KernelTime;

        /// <summary>
        /// Elapsed execution time for user-mode instructions, in CPU time units.
        /// If you are using a private session, use the value in the ProcessorTime member instead.
        /// </summary>
        public uint UserTime;
    }
}