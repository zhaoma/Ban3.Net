using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Provides configuration parameters to OpenTraceFromBufferStream, OpenTraceFromFile, OpenTraceFromRealTimeLogger, OpenTraceFromRealTimeLoggerWithAllocationOptions functions.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-etw_open_trace_options
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ETW_OPEN_TRACE_OPTIONS
    {
        /// PVOID->void*
        public ETW_PROCESS_TRACE_MODES ProcessTraceModes;

        /// PVOID->void*
        public System.IntPtr EventCallback;

        /// void*
        public System.IntPtr EventCallbackContext;

        /// PVOID->void*
        public System.IntPtr BufferCallback;

        /// void*
        public System.IntPtr BufferCallbackContext;
    }
}