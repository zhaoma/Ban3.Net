using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Determines the version information of the trace processing API.
    /// This data is returned from TraceQueryInformation when called with the TraceVersionInfo information class.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_version_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_VERSION_INFO
    {
        /// <summary>
        /// The version of the trace processing API on the current system.
        /// </summary>
        public uint EtwTraceProcessingVersion;

        /// <summary>
        /// Not used.
        /// </summary>
        public uint Reserved;
    }
}