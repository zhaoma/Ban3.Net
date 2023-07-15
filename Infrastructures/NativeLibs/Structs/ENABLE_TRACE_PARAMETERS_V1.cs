using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The ENABLE_TRACE_PARAMETERS_V1 structure contains information used to enable a provider via EnableTraceEx2.
    /// This structure is obsolete.
    /// Use ENABLE_TRACE_PARAMETERS instead.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-enable_trace_parameters_v1
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENABLE_TRACE_PARAMETERS_V1
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

    }
}