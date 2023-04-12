using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_ENUMERATE_VALUE_KEY_INFORMATION
    {    
        /// PVOID->void*
        public System.IntPtr Object;

        /// ULONG->unsigned int
        public uint Index;

        /// PVOID->void*
        public KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass;

        /// PVOID->void*
        public System.IntPtr KeyValueInformation;

        /// ULONG->unsigned int
        public uint Length;

        /// PULONG->ULONG*
        public System.IntPtr ResultLength;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;
    }
}
