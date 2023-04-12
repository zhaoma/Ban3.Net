using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Provided to the BufferCallback as the ConsumerInfo parameter and provides details on the current processing session.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-etw_buffer_callback_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ETW_BUFFER_CALLBACK_INFORMATION
    {
        /// <summary>
        /// The TraceHandle for this processing session.
        /// </summary>
        public System.IntPtr TraceHandle;

        /// <summary>
        /// TRACE_LOGFILE_HEADER structure containing trace processing status (previously-existing structure).
        /// </summary>
        public System.IntPtr LogfileHeader;

        /// <summary>
        /// The count of how many buffers have been processed up to this point.
        /// </summary>
        public uint BuffersRead;
    }
}