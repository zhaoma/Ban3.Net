using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the extended data that Event Tracing for Windows (ETW) collects as part of the event data.
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/ns-evntcons-event_header_extended_data_item
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_HEADER_EXTENDED_DATA_ITEM
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        public ushort Reserved1;

        /// USHORT->unsigned short
        public ushort ExtType;

        /// Anonymous_37690024_02d1_469a_af63_60d5336f96cc
        public EVENT_HEADER_EXTENDED_DATA_ITEM_STRUCT Struct1;

        /// USHORT->unsigned short
        public ushort DataSize;

        /// ULONGLONG->unsigned __int64
        public ulong DataPtr;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EVENT_HEADER_EXTENDED_DATA_ITEM_STRUCT
    {

        /// Linkage : 1
        ///Reserved2 : 15
        public uint bitvector1;

        public uint Linkage
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

        public uint Reserved2
        {
            get
            {
                return ((uint)(((this.bitvector1 & 65534u)
                                / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                                           | this.bitvector1)));
            }
        }
    }
}