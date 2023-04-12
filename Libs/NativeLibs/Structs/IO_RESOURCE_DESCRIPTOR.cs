using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_RESOURCE_DESCRIPTOR structure describes a range of raw hardware resources, of one type, that can be used by a device. 
    /// An array of IO_RESOURCE_DESCRIPTOR structures is contained within each IO_RESOURCE_LIST structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_resource_descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IO_RESOURCE_DESCRIPTOR
    {
        /// <summary>
        /// Specifies whether this resource description is required, preferred, or alternative.
        /// </summary>
        public byte Option;

        /// UCHAR->unsigned char
        public byte Type;

        /// UCHAR->unsigned char
        public byte ShareDisposition;

        /// UCHAR->unsigned char
        public byte Spare1;

        /// USHORT->unsigned short
        public ushort Flags;

        /// USHORT->unsigned short
        public ushort Spare2;

        /// Anonymous_e14c4904_d8e1_4a2d_82d2_e9a7f4e7bdac
        public IO_RESOURCE_DESCRIPTOR_UNION u;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct IO_RESOURCE_DESCRIPTOR_UNION
    {

        /// Anonymous_d319c12c_98f7_4296_8c69_9c4ad33a0d9d
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_PORT Port;

        /// Anonymous_26a2ddd5_e5aa_43c0_8baf_846e6b7c9ed2
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_MEMORY Memory;

        /// Anonymous_9f97fc3d_f4cc_4446_b2b9_6346d465a382
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_INTERRUPT Interrupt;

        /// Anonymous_ed2aac16_fa5e_4100_b3b4_045689a1cec8
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_DMA Dma;

        /// Anonymous_12a3fe08_c36a_47ce_9a3d_4d65b42d69de
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_DMAV3 DmaV3;

        /// Anonymous_270446a9_a4a3_40ba_9662_d4a940a7629e
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_GENERIC Generic;

        /// Anonymous_f25c5317_ffb1_49e1_917f_7f9c33bfe1b1
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_DEVICEPRIVATE DevicePrivate;

        /// Anonymous_49148715_e4b6_42ac_b96b_85243e6c25a7
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_BUSNUMBER BusNumber;

        /// Anonymous_b2d90f0c_74d9_4016_bda7_8ab6e6bb3787
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_CONFIGDATA ConfigData;

        /// Anonymous_1e24cb7c_e3f2_47ea_be66_2c2b86df5ae4
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_MEMORY40 Memory40;

        /// Anonymous_e2f3202a_7578_47c8_89cc_79760a80bb69
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_MEMORY48 Memory48;

        /// Anonymous_e98da180_16dd_4b2a_896b_ed9ec27f6e82
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_MEMORY64 Memory64;

        /// Anonymous_4892d8d6_3191_4329_861c_eaffc327db69
        [FieldOffset(0)]
        public IO_RESOURCE_DESCRIPTOR_CONNECTION Connection;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_PORT
    {

        /// ULONG->unsigned int
        public uint Length;

        /// ULONG->unsigned int
        public uint Alignment;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MinimumAddress;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MaximumAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_MEMORY
    {

        /// ULONG->unsigned int
        public uint Length;

        /// ULONG->unsigned int
        public uint Alignment;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MinimumAddress;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MaximumAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_INTERRUPT
    {

        /// ULONG->unsigned int
        public uint MinimumVector;

        /// ULONG->unsigned int
        public uint MaximumVector;

        /// USHORT->unsigned short
        public ushort AffinityPolicy;

        /// USHORT->unsigned short
        public ushort Group;

        /// USHORT->unsigned short
        public ushort PriorityPolicy;

        /// KAFFINITY->ULONG_PTR->unsigned int
        public uint TargetedProcessors;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_DMA
    {

        /// ULONG->unsigned int
        public uint MinimumChannel;

        /// ULONG->unsigned int
        public uint MaximumChannel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_DMAV3
    {

        /// ULONG->unsigned int
        public uint RequestLine;

        /// ULONG->unsigned int
        public uint Reserved;

        /// ULONG->unsigned int
        public uint Channel;

        /// ULONG->unsigned int
        public uint TransferWidth;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_GENERIC
    {

        /// ULONG->unsigned int
        public uint Length;

        /// ULONG->unsigned int
        public uint Alignment;

        /// USHORT->unsigned short
        public PHYSICAL_ADDRESS MinimumAddress;

        /// USHORT->unsigned short
        public PHYSICAL_ADDRESS MaximumAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_DEVICEPRIVATE
    {

        /// ULONG[3]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_BUSNUMBER
    {

        /// ULONG->unsigned int
        public uint Length;

        /// ULONG->unsigned int
        public uint MinBusNumber;

        /// ULONG->unsigned int
        public uint MaxBusNumber;

        /// ULONG->unsigned int
        public uint Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_CONFIGDATA
    {

        /// ULONG->unsigned int
        public uint Priority;

        /// ULONG->unsigned int
        public uint Reserved1;

        /// ULONG->unsigned int
        public uint Reserved2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_MEMORY40
    {

        /// ULONG->unsigned int
        public uint Length40;

        /// ULONG->unsigned int
        public uint Alignment40;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MinimumAddress;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MaximumAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_MEMORY48
    {

        /// ULONG->unsigned int
        public uint Length48;

        /// ULONG->unsigned int
        public uint Alignment48;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MinimumAddress;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MaximumAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_MEMORY64
    {

        /// ULONG->unsigned int
        public uint Length64;

        /// ULONG->unsigned int
        public uint Alignment64;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MinimumAddress;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS MaximumAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_RESOURCE_DESCRIPTOR_CONNECTION
    {

        /// UCHAR->unsigned char
        public byte Class;

        /// UCHAR->unsigned char
        public byte Type;

        /// UCHAR->unsigned char
        public byte Reserved1;

        /// UCHAR->unsigned char
        public byte Reserved2;

        /// ULONG->unsigned int
        public uint IdLowPart;

        /// ULONG->unsigned int
        public uint IdHighPart;
    }
}
