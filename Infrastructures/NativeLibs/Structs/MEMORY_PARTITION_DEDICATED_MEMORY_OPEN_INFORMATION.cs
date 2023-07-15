using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the MEMORY_PARTITION_DEDICATED_MEMORY_OPEN_INFORMATION structure.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-memory_partition_dedicated_memory_open_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_PARTITION_DEDICATED_MEMORY_OPEN_INFORMATION
    {    
        /// ULONG64->unsigned __int64
        public ulong DedicatedMemoryTypeId;

        /// ULONG->unsigned int
        public uint HandleAttributes;

        /// ACCESS_MASK->DWORD->unsigned int
        public uint DesiredAccess;

        /// HANDLE->void*
        public System.IntPtr DedicatedMemoryPartitionHandle;
    }
}
