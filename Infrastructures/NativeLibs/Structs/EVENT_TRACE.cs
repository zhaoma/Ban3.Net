using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_TRACE structure is used to deliver event information to an event trace consumer.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_trace
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE
    {

        /// PVOID->void*
        public EVENT_TRACE_HEADER Header;

        /// ULONG->unsigned int
        public uint InstanceId;

        /// ULONG->unsigned int
        public uint ParentInstanceId;

        /// GUID->_GUID
        public GUID ParentGuid;

        /// PVOID->void*
        public System.IntPtr MofData;

        /// ULONG->unsigned int
        public uint MofLength;

        /// Anonymous_52ed5a3d_aba4_45d1_8aae_65a8e7ef7fe7
        public EVENT_TRACE_UNION Union1;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct EVENT_TRACE_UNION
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint ClientContext;

        /// PVOID->void*
        [FieldOffset(0)]
        public ETW_BUFFER_CONTEXT BufferContext;
    }
}