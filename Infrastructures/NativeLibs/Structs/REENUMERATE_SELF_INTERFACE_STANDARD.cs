//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:31
//  function:	REENUMERATE_SELF_INTERFACE_STANDARD.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reenumerate_self_interface_standard
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REENUMERATE_SELF_INTERFACE_STANDARD
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
        public System.IntPtr SurpriseRemoveAndReenumerateSelf;
    }
}

