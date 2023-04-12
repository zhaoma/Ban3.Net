using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SCATTER_GATHER_LIST
    {
        /// ULONG->unsigned int
        public uint NumberOfElements;

        /// ULONG_PTR->unsigned int
        public uint Reserved;

        /// ULONG[]
        public SCATTER_GATHER_ELEMENT[] Elements;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct SCATTER_GATHER_ELEMENT
    {

        /// ULONG->unsigned int
        public uint Address;

        /// ULONG->unsigned int
        public uint Length;

        /// ULONG_PTR->unsigned int
        public uint Reserved;
    }
}
