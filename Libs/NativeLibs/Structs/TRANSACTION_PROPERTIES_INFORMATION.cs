using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TRANSACTION_PROPERTIES_INFORMATION
    {

        /// ULONG->unsigned int
        public uint IsolationLevel;

        /// ULONG->unsigned int
        public uint IsolationFlags;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER Timeout;

        /// ULONG->unsigned int
        public uint Outcome;

        /// ULONG->unsigned int
        public uint DescriptionLength;

        /// WCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Description;

    }
}
