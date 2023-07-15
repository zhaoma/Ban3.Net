using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TRACE_LOGFILE_HEADER structure contains information about an event tracing session and its events.
    /// It is the raw data format of the trace information data in the header of an ETW log file.
    /// It is also a part of the information returned by OpenTrace and provided to the BufferCallback during trace processing.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-trace_logfile_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_LOGFILE_HEADER
    {
        /// ULONG->unsigned int
        public uint BufferSize;

        /// Anonymous_10c08314_7a7e_48f0_a728_8522bb36d1b6
        public TRACE_LOGFILE_HEADER_UNION1 Union1;

        /// ULONG->unsigned int
        public uint ProviderVersion;

        /// ULONG->unsigned int
        public uint NumberOfProcessors;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER EndTime;

        /// ULONG->unsigned int
        public uint TimerResolution;

        /// ULONG->unsigned int
        public uint MaximumFileSize;

        /// ULONG->unsigned int
        public uint LogFileMode;

        /// ULONG->unsigned int
        public uint BuffersWritten;

        /// Anonymous_a5f62b8c_5a9c_419b_80ef_85ace1e422a2
        public TRACE_LOGFILE_HEADER_UNION2 Union2;

        /// PWCHAR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string LoggerName;

        /// PWCHAR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string LogFileName;

        /// PVOID->void*
        public TIME_ZONE_INFORMATION TimeZone;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER BootTime;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER PerfFreq;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER StartTime;

        /// ULONG->unsigned int
        public uint ReservedFlags;

        /// ULONG->unsigned int
        public uint BuffersLost;


    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct TRACE_LOGFILE_HEADER_UNION1
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint Version;

        /// Anonymous_2edda42b_0f4c_4416_96c9_39112236fe37
        [FieldOffset(0)]
        public TRACE_LOGFILE_HEADER_DETAIL VersionDetail;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_LOGFILE_HEADER_DETAIL
    {

        /// UCHAR->unsigned char
        public byte MajorVersion;

        /// UCHAR->unsigned char
        public byte MinorVersion;

        /// UCHAR->unsigned char
        public byte SubVersion;

        /// UCHAR->unsigned char
        public byte SubMinorVersion;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct TRACE_LOGFILE_HEADER_UNION2
    {

        /// GUID->_GUID
        [FieldOffset(0)]
        public GUID LogInstanceGuid;

        /// Anonymous_90687aca_daea_4c75_9021_274a20160668
        [FieldOffset(0)]
        public TRACE_LOGFILE_HEADER_DUMMY DUMMYSTRUCTNAME;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TRACE_LOGFILE_HEADER_DUMMY
    {

        /// ULONG->unsigned int
        public uint StartBuffers;

        /// ULONG->unsigned int
        public uint PointerSize;

        /// ULONG->unsigned int
        public uint EventsLost;

        /// ULONG->unsigned int
        public uint CpuSpeedInMHz;
    }

}