//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:29
//  function:	PTM_CONTROL_INTERFACE.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ptm_control_interface
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PTM_CONTROL_INTERFACE
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
        public System.IntPtr QueryGranularity;

        /// PVOID->void*
        public System.IntPtr QueryTimeSource;

        /// PVOID->void*
        public System.IntPtr Enable;

        /// PVOID->void*
        public System.IntPtr Disable;
    }
}

