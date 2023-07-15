using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_TRACE_LOGFILE structure stores information about a trace data source.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_trace_logfilea
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE_LOGFILEA
    {

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string LogFileName;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string LoggerName;

        /// LONGLONG->__int64
        public long CurrentTime;

        /// ULONG->unsigned int
        public uint BuffersRead;

        /// Anonymous_bd8036bd_5232_4556_8314_15a6ac04a086
        public EVENT_TRACE_LOGFILE_UNION1 Union1;

        /// HANDLE->void*
        public System.IntPtr CurrentEvent;

        /// HANDLE->void*
        public System.IntPtr LogfileHeader;

        /// HANDLE->void*
        public System.IntPtr BufferCallback;

        /// ULONG->unsigned int
        public uint BufferSize;

        /// ULONG->unsigned int
        public uint Filled;

        /// ULONG->unsigned int
        public uint EventsLost;

        /// Anonymous_5fb9dbd4_7630_4c7b_871e_d5fb58a36749
        public EVENT_TRACE_LOGFILE_UNION2 Union2;

        /// ULONG->unsigned int
        public uint IsKernelTrace;

        /// PVOID->void*
        public System.IntPtr Context;

    }

    /// <summary>
    /// The EVENT_TRACE_LOGFILE structure stores information about a trace data source.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_trace_logfilew
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE_LOGFILEW
    {

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string LogFileName;

        /// LPWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string LoggerName;

        /// LONGLONG->__int64
        public long CurrentTime;

        /// ULONG->unsigned int
        public uint BuffersRead;

        /// Anonymous_bd8036bd_5232_4556_8314_15a6ac04a086
        public EVENT_TRACE_LOGFILE_UNION1 Union1;

        /// HANDLE->void*
        public System.IntPtr CurrentEvent;

        /// HANDLE->void*
        public System.IntPtr LogfileHeader;

        /// HANDLE->void*
        public System.IntPtr BufferCallback;

        /// ULONG->unsigned int
        public uint BufferSize;

        /// ULONG->unsigned int
        public uint Filled;

        /// ULONG->unsigned int
        public uint EventsLost;

        /// Anonymous_5fb9dbd4_7630_4c7b_871e_d5fb58a36749
        public EVENT_TRACE_LOGFILE_UNION2 Union2;

        /// ULONG->unsigned int
        public uint IsKernelTrace;

        /// PVOID->void*
        public System.IntPtr Context;

    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct EVENT_TRACE_LOGFILE_UNION1
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint LogFileMode;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint ProcessTraceMode;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct EVENT_TRACE_LOGFILE_UNION2
    {

        /// HANDLE->void*
        [FieldOffset(0)]
        public System.IntPtr EventCallback;

        /// HANDLE->void*
        [FieldOffset(0)]
        public System.IntPtr EventRecordCallback;
    }
}