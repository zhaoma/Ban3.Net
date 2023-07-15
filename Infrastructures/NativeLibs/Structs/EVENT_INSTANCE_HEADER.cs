using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_INSTANCE_HEADER structure contains standard event tracing information common to all events written by TraceEventInstance.
    /// The structure also contains registration handles for the event trace class and related parent event,
    /// which you use to trace instances of a transaction or hierarchical relationships between related events.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntrace/ns-evntrace-event_instance_header
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_INSTANCE_HEADER
    {


        /// USHORT->unsigned short
        public ushort Size;

        /// Anonymous_b42dde79_3a4f_4bd8_b9e2_19b07764a241
        public Anonymous_b42dde79_3a4f_4bd8_b9e2_19b07764a241 Union1;

        /// Anonymous_6285be46_415b_4121_85c0_4f6caca7b892
        public Anonymous_6285be46_415b_4121_85c0_4f6caca7b892 Union2;

        /// ULONG->unsigned int
        public uint ThreadId;

        /// ULONG->unsigned int
        public uint ProcessId;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER TimeStamp;

        /// ULONGLONG->unsigned __int64
        public ulong RegHandle;

        /// ULONG->unsigned int
        public uint InstanceId;

        /// ULONG->unsigned int
        public uint ParentInstanceId;

        /// Anonymous_4ff8496e_de5b_4c3d_a063_d795b39ddb16
        public Anonymous_4ff8496e_de5b_4c3d_a063_d795b39ddb16 Union3;

        /// ULONGLONG->unsigned __int64
        public ulong ParentRegHandle;

    }


    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_17c8f463_8d86_4217_b4ab_6e940a270625
    {

        /// UCHAR->unsigned char
        public byte HeaderType;

        /// UCHAR->unsigned char
        public byte MarkerFlags;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_b42dde79_3a4f_4bd8_b9e2_19b07764a241
    {

        /// USHORT->unsigned short
        [FieldOffset(0)]
        public ushort FieldTypeFlags;

        /// Anonymous_17c8f463_8d86_4217_b4ab_6e940a270625
        [FieldOffset(0)]
        public Anonymous_17c8f463_8d86_4217_b4ab_6e940a270625 DUMMYSTRUCTNAME;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_91eae0e7_64c4_48ad_a4f3_3eff86645bc2
    {

        /// UCHAR->unsigned char
        public byte Type;

        /// UCHAR->unsigned char
        public byte Level;

        /// USHORT->unsigned short
        public ushort Version;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_6285be46_415b_4121_85c0_4f6caca7b892
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint Version;

        /// Anonymous_91eae0e7_64c4_48ad_a4f3_3eff86645bc2
        [FieldOffset(0)]
        public Anonymous_91eae0e7_64c4_48ad_a4f3_3eff86645bc2 Class;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_a98fcc91_4946_4678_912d_70aab8ae47d2
    {

        /// ULONG->unsigned int
        public uint KernelTime;

        /// ULONG->unsigned int
        public uint UserTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_15f07600_09c3_4460_aa83_45bf96c71f09
    {

        /// ULONG->unsigned int
        public uint EventId;

        /// ULONG->unsigned int
        public uint Flags;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Anonymous_4ff8496e_de5b_4c3d_a063_d795b39ddb16
    {

        /// Anonymous_a98fcc91_4946_4678_912d_70aab8ae47d2
        [FieldOffset(0)]
        public Anonymous_a98fcc91_4946_4678_912d_70aab8ae47d2 DUMMYSTRUCTNAME;

        /// ULONG64->unsigned __int64
        [FieldOffset(0)]
        public ulong ProcessorTime;

        /// Anonymous_15f07600_09c3_4460_aa83_45bf96c71f09
        [FieldOffset(0)]
        public Anonymous_15f07600_09c3_4460_aa83_45bf96c71f09 DUMMYSTRUCTNAME2;
    }
}