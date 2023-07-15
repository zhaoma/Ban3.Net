using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_TRACE_HEADER structure contains standard event tracing information common to all events written by TraceEvent.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_trace_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_TRACE_HEADER
    {

        /// USHORT->unsigned short
        public ushort Size;

        /// Anonymous_f59b9b82_ef8c_4bc0_80ed_32c50410b47a
        public Anonymous_f59b9b82_ef8c_4bc0_80ed_32c50410b47a Union1;

        /// Anonymous_5b450588_1d7e_41fd_b407_a13f8b274369
        public Anonymous_5b450588_1d7e_41fd_b407_a13f8b274369 Union2;

        /// ULONG->unsigned int
        public uint ThreadId;

        /// ULONG->unsigned int
        public uint ProcessId;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER TimeStamp;

        /// Anonymous_c65292bb_2e0e_4535_a8a5_89a78028d983
        public Anonymous_c65292bb_2e0e_4535_a8a5_89a78028d983 Union3;

        /// Anonymous_81c7f0df_1b32_4851_9a3e_7b794ae7ffc4
        public Anonymous_81c7f0df_1b32_4851_9a3e_7b794ae7ffc4 Union4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_140e9ee7_55c0_4bfb_a989_cf1c5f6bfacb
    {

        /// UCHAR->unsigned char
        public byte HeaderType;

        /// UCHAR->unsigned char
        public byte MarkerFlags;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_f59b9b82_ef8c_4bc0_80ed_32c50410b47a
    {

        /// USHORT->unsigned short
        [FieldOffset(0)]
        public ushort FieldTypeFlags;

        /// Anonymous_140e9ee7_55c0_4bfb_a989_cf1c5f6bfacb
        [FieldOffset(0)]
        public Anonymous_140e9ee7_55c0_4bfb_a989_cf1c5f6bfacb DUMMYSTRUCTNAME;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_1534ea40_73a7_4344_8429_d3740629886c
    {

        /// UCHAR->unsigned char
        public byte Type;

        /// UCHAR->unsigned char
        public byte Level;

        /// USHORT->unsigned short
        public ushort Version;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_5b450588_1d7e_41fd_b407_a13f8b274369
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint Version;

        /// Anonymous_1534ea40_73a7_4344_8429_d3740629886c
        [FieldOffset(0)]
        public Anonymous_1534ea40_73a7_4344_8429_d3740629886c Class;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_c65292bb_2e0e_4535_a8a5_89a78028d983
    {

        /// GUID->_GUID
        [FieldOffset(0)]
        public GUID Guid;

        /// ULONGLONG->unsigned __int64
        [FieldOffset(0)]
        public ulong GuidPtr;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_1aab4947_defa_4db2_b20b_b992ad9606ea
    {

        /// ULONG->unsigned int
        public uint KernelTime;

        /// ULONG->unsigned int
        public uint UserTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_2cbee213_12e0_4cbf_b34f_d90c69d8523b
    {

        /// ULONG->unsigned int
        public uint ClientContext;

        /// ULONG->unsigned int
        public uint Flags;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_81c7f0df_1b32_4851_9a3e_7b794ae7ffc4
    {

        /// Anonymous_1aab4947_defa_4db2_b20b_b992ad9606ea
        [FieldOffset(0)]
        public Anonymous_1aab4947_defa_4db2_b20b_b992ad9606ea DUMMYSTRUCTNAME;

        /// ULONG64->unsigned __int64
        [FieldOffset(0)]
        public ulong ProcessorTime;

        /// Anonymous_2cbee213_12e0_4cbf_b34f_d90c69d8523b
        [FieldOffset(0)]
        public Anonymous_2cbee213_12e0_4cbf_b34f_d90c69d8523b DUMMYSTRUCTNAME2;
    }
}