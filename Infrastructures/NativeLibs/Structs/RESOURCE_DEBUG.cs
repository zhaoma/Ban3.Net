using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RESOURCE_DEBUG
    {
        /// WORD->unsigned short
        public ushort Type;

        /// WORD->unsigned short
        public ushort CreatorBackTraceIndex;

        /// _RTL_CRITICAL_SECTION*
        public IntPtr CriticalSection;

        /// LIST_ENTRY->_LIST_ENTRY
        public LIST_ENTRY ProcessLocksList;

        /// DWORD->unsigned int
        public uint EntryCount;

        /// DWORD->unsigned int
        public uint ContentionCount;

        /// DWORD[2]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
        public uint[] Spare;
    }
}
