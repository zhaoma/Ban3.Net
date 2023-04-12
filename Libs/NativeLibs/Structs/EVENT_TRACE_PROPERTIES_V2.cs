using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_TRACE_PROPERTIES_V2 structure contains information about an event tracing session.
    /// You use this structure with APIs such as StartTrace and ControlTrace when defining, updating, or querying the properties of a session.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_trace_properties_v2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE_PROPERTIES_V2
    {

        /// HANDLE->void*
        public System.IntPtr Wnode;

        /// ULONG->unsigned int
        public uint BufferSize;

        /// ULONG->unsigned int
        public uint MinimumBuffers;

        /// ULONG->unsigned int
        public uint MaximumBuffers;

        /// ULONG->unsigned int
        public uint MaximumFileSize;

        /// ULONG->unsigned int
        public uint LogFileMode;

        /// ULONG->unsigned int
        public uint FlushTimer;

        /// ULONG->unsigned int
        public uint EnableFlags;

        /// Anonymous_bd1c8239_26ab_4c61_bdaf_1c1b0de7b6b1
        public EVENT_TRACE_PROPERTIES_V2_UNION1 Union1;

        /// ULONG->unsigned int
        public uint NumberOfBuffers;

        /// ULONG->unsigned int
        public uint FreeBuffers;

        /// ULONG->unsigned int
        public uint EventsLost;

        /// ULONG->unsigned int
        public uint BuffersWritten;

        /// ULONG->unsigned int
        public uint LogBuffersLost;

        /// ULONG->unsigned int
        public uint RealTimeBuffersLost;

        /// HANDLE->void*
        public System.IntPtr LoggerThreadId;

        /// ULONG->unsigned int
        public uint LogFileNameOffset;

        /// ULONG->unsigned int
        public uint LoggerNameOffset;

        /// Anonymous_a5d988d0_8027_4431_b0b6_3b0d218f9177
        public EVENT_TRACE_PROPERTIES_V2_UNION2 Union2;

        /// ULONG->unsigned int
        public uint FilterDescCount;

        /// PVOID->void*
        public System.IntPtr FilterDesc;

        /// Anonymous_e0404ff5_96c5_4659_870d_c9cb4b676a69
        public EVENT_TRACE_PROPERTIES_V2_UNION3 Union3;

    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct EVENT_TRACE_PROPERTIES_V2_UNION1
    {

        /// LONG->int
        [FieldOffset(0)]
        public int AgeLimit;

        /// LONG->int
        [FieldOffset(0)]
        public int FlushThreshold;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct EVENT_TRACE_PROPERTIES_V2_UNION2
    {

        /// Anonymous_f47e450d_fe95_4b45_856e_79b73aab6100
        [FieldOffset(0)]
        public EVENT_TRACE_PROPERTIES_V2_UNION2_DUMMY DUMMYSTRUCTNAME;

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint V2Control;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE_PROPERTIES_V2_UNION2_DUMMY
    {

        /// VersionNumber : 8
        public uint bitvector1;

        public uint VersionNumber
        {
            get
            {
                return ((uint)((this.bitvector1 & 255u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct EVENT_TRACE_PROPERTIES_V2_UNION3
    {

        /// Anonymous_d48d7f12_7a98_43bd_966a_a298a961feee
        [FieldOffset(0)]
        public EVENT_TRACE_PROPERTIES_V2_UNION3_DUMMY DUMMYSTRUCTNAME;

        /// ULONG64->unsigned __int64
        [FieldOffset(0)]
        public ulong V2Options;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE_PROPERTIES_V2_UNION3_DUMMY
    {

        /// Wow : 1
        ///QpcDeltaTracking : 1
        ///LargeMdlPages : 1
        ///ExcludeKernelStack : 1
        public uint bitvector1;

        public uint Wow
        {
            get
            {
                return ((uint)((this.bitvector1 & 1u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        public uint QpcDeltaTracking
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2u)
                                / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                                           | this.bitvector1)));
            }
        }

        public uint LargeMdlPages
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4u)
                                / 4)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4)
                                           | this.bitvector1)));
            }
        }

        public uint ExcludeKernelStack
        {
            get
            {
                return ((uint)(((this.bitvector1 & 8u)
                                / 8)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8)
                                           | this.bitvector1)));
            }
        }
    }

}