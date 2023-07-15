using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ENABLE_TRACE_PARAMETERS structure contains information used to enable a provider via EnableTraceEx2.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-enable_trace_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENABLE_TRACE_PARAMETERS
    {
        /// ULONG->unsigned int
        public uint Version;

        /// ULONG->unsigned int
        public uint EnableProperty;

        /// ULONG->unsigned int
        public uint ControlFlags;

        /// GUID->_GUID
        public GUID SourceId;

        /// PVOID->void*
        public System.IntPtr EnableFilterDesc;

        /// ULONG->unsigned int
        public uint FilterDescCount;

    }
}