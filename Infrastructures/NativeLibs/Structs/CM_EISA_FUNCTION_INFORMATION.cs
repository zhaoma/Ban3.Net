using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{

    [StructLayout(LayoutKind.Sequential)]
    public struct CM_EISA_FUNCTION_INFORMATION
    {

        /// ULONG->unsigned int
        public uint CompressedId;

        /// UCHAR->unsigned char
        public byte IdSlotFlags1;

        /// UCHAR->unsigned char
        public byte IdSlotFlags2;

        /// UCHAR->unsigned char
        public byte MinorRevision;

        /// UCHAR->unsigned char
        public byte MajorRevision;

        /// UCHAR[26]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 26)]
        public string Selections;

        /// UCHAR->unsigned char
        public byte FunctionFlags;

        /// UCHAR[80]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string TypeString;

        /// DWORD[9]
        public EISA_MEMORY_CONFIGURATION EisaMemory;

        /// DWORD[7]
        public EISA_IRQ_CONFIGURATION EisaIrq;

        /// DWORD[4]
        public EISA_DMA_CONFIGURATION EisaDma;

        /// DWORD[20]
        public EISA_PORT_CONFIGURATION EisaPort;

        /// UCHAR[60]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
        public string InitializationData;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EISA_MEMORY_CONFIGURATION
    {    
        /// DWORD->unsigned int
        public uint ConfigurationByte;

        /// UCHAR->unsigned char
        public byte DataSize;

        /// USHORT->unsigned short
        public ushort AddressLowWord;

        /// UCHAR->unsigned char
        public byte AddressHighByte;

        /// USHORT->unsigned short
        public ushort MemorySize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EISA_IRQ_CONFIGURATION
    {

        /// DWORD->unsigned int
        public uint ConfigurationByte;

        /// UCHAR->unsigned char
        public byte Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EISA_DMA_CONFIGURATION
    {

        /// DWORD->unsigned int
        public uint ConfigurationByte0;

        /// DWORD->unsigned int
        public uint ConfigurationByte1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EISA_PORT_CONFIGURATION
    {

        /// DWORD->unsigned int
        public uint Configuration;

        /// USHORT->unsigned short
        public ushort PortAddress;
    }

}
