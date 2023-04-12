using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RTL_PROCESS_MODULE_INFORMATION
    {
        public ulong Handle;
        public ulong MappedBase;
        public ulong ImageBase;
        public uint ImageSize;
        public uint Flags;
        public ushort LoadOrderIndex;
        public ushort InitOrderIndex;
        public ushort LoadCount;
        public ushort OffsetToFileName;
        public fixed byte FullPathName[256];
    }
}
