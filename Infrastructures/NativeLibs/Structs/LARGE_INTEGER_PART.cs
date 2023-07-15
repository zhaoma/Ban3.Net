using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LARGE_INTEGER_PART
    {
        /// ULONG->unsigned int
        public uint LowPart;

        /// LONG->int
        public int HighPart;

    }
}
