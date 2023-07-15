using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EVENT_DATA_DESCRIPTOR structure defines a block of data that will be used in an ETW event.
    /// This structure is typically initialized using the EventDataDescCreate function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntprov/ns-evntprov-event_data_descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_DATA_DESCRIPTOR
    {
        /// ULONGLONG->unsigned __int64
        public ulong Ptr;

        /// ULONG->unsigned int
        public uint Size;

        /// Anonymous_5952117e_24b0_4dcc_b964_3ebbe205a256
        public EVENT_DATA_DESCRIPTOR_UNION Union1;
        
    }

    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct EVENT_DATA_DESCRIPTOR_UNION
    {

        /// ULONG->unsigned int
        [FieldOffset(0)]
        public uint Reserved;

        /// Anonymous_d609e56c_f2a1_42cc_a42e_6daf5d01918f
        [FieldOffset(0)]
        public EVENT_DATA_DESCRIPTOR_DUMMY DUMMYSTRUCTNAME;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_DATA_DESCRIPTOR_DUMMY
    {
        /// UCHAR->unsigned char
        public byte Type;

        /// UCHAR->unsigned char
        public byte Reserved1;

        /// USHORT->unsigned short
        public ushort Reserved2;
    }

}