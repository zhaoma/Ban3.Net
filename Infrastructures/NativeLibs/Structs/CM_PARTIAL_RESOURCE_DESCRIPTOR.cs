using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// 
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_partial_resource_descriptor
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR
    {    
        /// UCHAR->unsigned char
        public RESOURCE_TYPE Type;

        /// UCHAR->unsigned char
        public SHARE_DISPOSITION ShareDisposition;

        /// USHORT->unsigned short
        public ushort Flags;

        /// Anonymous_e21be3c5_70b1_4c80_a070_64e6a02a5de8
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_VALUE u;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_VALUE
    {
        /// Anonymous_c2fc7085_138f_445f_b046_4f60eefd9cc4
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK Generic;

        /// Anonymous_ec255818_6df4_4db9_b420_24f209353cfe
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK Port;

        /// Anonymous_cbe88d1a_af84_43e8_bfe2_caa3a700b4ec
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_PAGE Interrupt;

        /// Anonymous_a1de93af_4333_4846_bc52_92f2756d8f91
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_DUMMY MessageInterrupt;

        /// Anonymous_2f086847_587a_483c_8512_3620d889eb71
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK Memory;

        /// Anonymous_8f130c07_6e4d_479b_a72b_577d7cac14d4
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_DMA Dma;

        /// Anonymous_11c7fc4b_9c69_4994_b06d_7372a9cddb81
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_DMAV3 DmaV3;

        /// Anonymous_8a4759fd_a6a4_4362_ac00_f239254523e2
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_DEVICEPRIVATE DevicePrivate;

        /// Anonymous_9ea9ef79_a2ed_4d72_ae79_3087f75471a1
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_BUSNUMBER BusNumber;

        /// Anonymous_5171fa9e_cf1a_439c_91d4_8d820c49081e
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_DEVICESPECIFICDATA DeviceSpecificData;

        /// Anonymous_6bd6a2b4_5cf7_4611_9e64_47bd2bba5b75
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK40 Memory40;

        /// Anonymous_501f586f_46fb_4aae_bcb9_3ec1a87defee
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK48 Memory48;

        /// Anonymous_2ad3800f_95b1_46a3_b805_71b2fdbe7c38
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK64 Memory64;

        /// Anonymous_25a6ed6f_3eff_4576_ba7d_387a6fe96bed
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_CONNECTION Connection;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK
    {

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS Start;

        /// ULONG->unsigned int
        public uint Length;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_PAGE
    {

        /// USHORT->unsigned short
        public ushort Level;

        /// USHORT->unsigned short
        public ushort Group;

        /// ULONG->unsigned int
        public uint Vector;

        /// KAFFINITY->ULONG_PTR->unsigned int
        public uint Affinity;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_VECTOR
    {

        /// USHORT->unsigned short
        public ushort Group;

        /// USHORT->unsigned short
        public ushort Reserved;

        /// USHORT->unsigned short
        public ushort MessageCount;

        /// ULONG->unsigned int
        public uint Vector;

        /// KAFFINITY->ULONG_PTR->unsigned int
        public uint Affinity;
    }

    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_DUMMYUNION
    {

        /// Anonymous_22282484_ed7f_4e1a_841f_373bb6e4a572
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_VECTOR Raw;

        /// Anonymous_ca168e9e_ac46_4a8d_bf33_c1503bcbac46
        [FieldOffset(0)]
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_PAGE Translated;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_DUMMY
    {

        /// Anonymous_e1218d27_d76a_498f_a96b_e3881c49ed3f
        public CM_PARTIAL_RESOURCE_DESCRIPTOR_DUMMYUNION DUMMYUNIONNAME;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_DMA
    {

        /// ULONG->unsigned int
        public uint Channel;

        /// ULONG->unsigned int
        public uint Port;

        /// ULONG->unsigned int
        public uint Reserved1;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_DMAV3
    {

        /// ULONG->unsigned int
        public uint Channel;

        /// ULONG->unsigned int
        public uint RequestLine;

        /// UCHAR->unsigned char
        public byte TransferWidth;

        /// UCHAR->unsigned char
        public byte Reserved1;

        /// UCHAR->unsigned char
        public byte Reserved2;

        /// UCHAR->unsigned char
        public byte Reserved3;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_DEVICEPRIVATE
    {

        /// ULONG[3]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] Data;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_BUSNUMBER
    {

        /// ULONG->unsigned int
        public uint Start;

        /// ULONG->unsigned int
        public uint Length;

        /// ULONG->unsigned int
        public uint Reserved;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_DEVICESPECIFICDATA
    {

        /// ULONG->unsigned int
        public uint DataSize;

        /// ULONG->unsigned int
        public uint Reserved1;

        /// ULONG->unsigned int
        public uint Reserved2;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK40
    {

        /// ULONG->unsigned int
        public uint Start;

        /// ULONG->unsigned int
        public uint Length40;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK48
    {

        /// ULONG->unsigned int
        public uint Start;

        /// ULONG->unsigned int
        public uint Length48;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_BLOCK64
    {

        /// ULONG->unsigned int
        public uint Start;

        /// ULONG->unsigned int
        public uint Length64;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CM_PARTIAL_RESOURCE_DESCRIPTOR_CONNECTION
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
