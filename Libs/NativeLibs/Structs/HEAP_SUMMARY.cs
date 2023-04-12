using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Represents a heap summary retrieved with a call to HeapSummary
    /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/ns-heapapi-heap_summary
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HEAP_SUMMARY
    {
        /// <summary>
        /// The size of this data structure, in bytes. Set this member to sizeof(HEAP_SUMMARY).
        /// </summary>
        public uint cb;

        /// <summary>
        /// The size of the allocated memory.
        /// </summary>
        public uint cbAllocated;

        /// <summary>
        /// The size of the committed memory.
        /// </summary>
        public uint cbCommitted;

        /// <summary>
        /// The size of the reserved memory.
        /// </summary>
        public uint cbReserved;

        /// <summary>
        /// The size of the maximum reserved memory.
        /// </summary>
        public uint cbMaxReserve;
    }
}