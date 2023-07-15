using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains partition information pulled from an ETW trace.
    /// Most commonly used as a return structure for QueryTraceProcessingHandle.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-etw_trace_partition_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ETW_TRACE_PARTITION_INFORMATION
    {

        /// GUID->_GUID
        public GUID PartitionId;

        /// GUID->_GUID
        public GUID ParentId;

        /// LONG64->__int64
        public long QpcOffsetFromRoot;

        /// ULONG->unsigned int
        public uint PartitionType;
    }
}