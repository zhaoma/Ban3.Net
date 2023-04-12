using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ETW_BUFFER_CONTEXT structure provides context information about the event.
    /// An instance of the ETW_BUFFER_CONTEXT structure is included in the EVENT_RECORD and EVENT_TRACE structures.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-etw_buffer_context
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ETW_BUFFER_CONTEXT
    {
        /// Anonymous_80777bca_eb74_46b6_8d48_9884dfaeb9f1
        public ETW_BUFFER_CONTEXT_UNION Union1;

        /// <summary>
        /// Identifier of the session that logged the event.
        /// </summary>
        public ushort LoggerId;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct ETW_BUFFER_CONTEXT_UNION
    {

        /// Anonymous_06268289_d5c4_4826_95b5_6392f5aa57c8
        [FieldOffset(0)]
        public ETW_BUFFER_CONTEXT_DUMMY DUMMYSTRUCTNAME;

        /// USHORT->unsigned short
        [FieldOffset(0)]
        public ushort ProcessorIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ETW_BUFFER_CONTEXT_DUMMY
    {
        /// <summary>
        /// The number of the CPU on which the provider process was running.
        /// The number is zero on a single-processor computer.
        /// </summary>
        public byte ProcessorNumber;

        /// <summary>
        /// Alignment between events (always eight).
        /// </summary>
        public byte Alignment;
    }
}