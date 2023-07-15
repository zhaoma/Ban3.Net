using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the PCI_SECURITY_INTERFACE2 structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-pci_security_interface2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_SECURITY_INTERFACE2
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

        /// ULONG->unsigned int
        public uint Flags;

        /// ULONG->unsigned int
        public uint SupportedScenarios;

        /// PVOID->void*
        public System.IntPtr SetAccessControlServices;
    }
}
