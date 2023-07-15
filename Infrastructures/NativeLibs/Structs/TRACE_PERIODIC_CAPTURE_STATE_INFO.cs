using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Used with TraceQueryInformation and TraceSetInformation to get or set information relating to a periodic capture state.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_periodic_capture_state_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_PERIODIC_CAPTURE_STATE_INFO
    {
        /// <summary>
        /// The frequency of state captures in seconds.
        /// </summary>
        public uint CaptureStateFrequencyInSeconds;

        /// <summary>
        /// The number of providers.
        /// </summary>
        public ushort ProviderCount;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public ushort Reserved;
    }
}