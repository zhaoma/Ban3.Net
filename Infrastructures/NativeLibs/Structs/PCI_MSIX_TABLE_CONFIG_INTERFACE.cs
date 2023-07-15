using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PCI_MSIX_TABLE_CONFIG_INTERFACE structure enables device drivers to modify their MSI-X interrupt settings. 
    /// This structure describes the GUID_MSIX_TABLE_CONFIG_INTERFACE interface.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_pci_msix_table_config_interface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PCI_MSIX_TABLE_CONFIG_INTERFACE
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
        public System.IntPtr SetTableEntry;

        /// PVOID->void*
        public System.IntPtr MaskTableEntry;

        /// PVOID->void*
        public System.IntPtr UnmaskTableEntry;

        /// PVOID->void*
        public System.IntPtr GetTableEntry;

        /// PVOID->void*
        public System.IntPtr GetTableSize;
    }
}
