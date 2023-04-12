using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_DESCRIPTION
    {    
        /// ULONG->unsigned int
        public uint Version;

        /// BOOLEAN->BYTE->unsigned char
        public byte Master;

        /// BOOLEAN->BYTE->unsigned char
        public byte ScatterGather;

        /// BOOLEAN->BYTE->unsigned char
        public byte DemandMode;

        /// BOOLEAN->BYTE->unsigned char
        public byte AutoInitialize;

        /// BOOLEAN->BYTE->unsigned char
        public byte Dma32BitAddresses;

        /// BOOLEAN->BYTE->unsigned char
        public byte IgnoreCount;

        /// BOOLEAN->BYTE->unsigned char
        public byte Reserved1;

        /// BOOLEAN->BYTE->unsigned char
        public byte Dma64BitAddresses;

        /// ULONG->unsigned int
        public uint BusNumber;

        /// ULONG->unsigned int
        public uint DmaChannel;

        /// ULONG->unsigned int
        public INTERFACE_TYPE InterfaceType;

        /// ULONG->unsigned int
        public DMA_WIDTH DmaWidth;

        /// ULONG->unsigned int
        public DMA_SPEED DmaSpeed;

        /// ULONG->unsigned int
        public uint MaximumLength;

        /// ULONG->unsigned int
        public uint DmaPort;

        /// ULONG->unsigned int
        public uint DmaAddressWidth;

        /// ULONG->unsigned int
        public uint DmaControllerInstance;

        /// ULONG->unsigned int
        public uint DmaRequestLine;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS DeviceAddress;

    }
}
