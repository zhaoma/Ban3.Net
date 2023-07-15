using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the PCI_ATS_INTERFACE structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-pci_ats_interface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_ATS_INTERFACE
    {    
        /// USHORT->unsigned short
        public ushort Size;

        /// USHORT->unsigned short
        public ushort Version;

        /// PVOID->void*
        public System.IntPtr Context;

        /// PVOID->void*
        public System.IntPtr InterfaceReference;

        /// PVOID->void*
        public System.IntPtr InterfaceDereference;

        /// PVOID->void*
        public System.IntPtr SetAddressTranslationServices;

        /// UCHAR->unsigned char
        public byte InvalidateQueueDepth;
    }
}
