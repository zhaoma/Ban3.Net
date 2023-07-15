using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VALENTW
    {
        /// LPSTR->CHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ve_valuename;

        /// DWORD->unsigned int
        public uint ve_valuelen;

        /// DWORD_PTR->ULONG_PTR->unsigned int
        public uint ve_valueptr;

        /// DWORD->unsigned int
        public uint ve_type;
    }
}
