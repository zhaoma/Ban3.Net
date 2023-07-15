using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains performance information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-performance_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PERFORMANCE_INFORMATION
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public uint cb;

        /// <summary>
        /// The number of pages currently committed by the system. Note that committing pages (using VirtualAlloc with MEM_COMMIT) changes this value immediately;
        /// however, the physical memory is not charged until the pages are accessed.
        /// </summary>
        public uint CommitTotal;

        /// <summary>
        /// The current maximum number of pages that can be committed by the system without extending the paging file(s).
        /// This number can change if memory is added or deleted, or if pagefiles have grown, shrunk, or been added.
        /// If the paging file can be extended, this is a soft limit.
        /// </summary>
        public uint CommitLimit;

        /// <summary>
        /// The maximum number of pages that were simultaneously in the committed state since the last system reboot.
        /// </summary>
        public uint CommitPeak;

        /// <summary>
        /// The amount of actual physical memory, in pages.
        /// </summary>
        public uint PhysicalTotal;

        /// <summary>
        /// The amount of physical memory currently available, in pages.
        /// This is the amount of physical memory that can be immediately reused without having to write its contents to disk first.
        /// It is the sum of the size of the standby, free, and zero lists.
        /// </summary>
        public uint PhysicalAvailable;

        /// <summary>
        /// The amount of system cache memory, in pages.
        /// This is the size of the standby list plus the system working set.
        /// </summary>
        public uint SystemCache;

        /// <summary>
        /// The sum of the memory currently in the paged and nonpaged kernel pools, in pages.
        /// </summary>
        public uint KernelTotal;

        /// <summary>
        /// The memory currently in the paged kernel pool, in pages.
        /// </summary>
        public uint KernelPaged;

        /// <summary>
        /// The memory currently in the nonpaged kernel pool, in pages.
        /// </summary>
        public uint KernelNonpaged;

        /// <summary>
        /// The size of a page, in bytes.
        /// </summary>
        public uint PageSize;

        /// <summary>
        /// The current number of open handles.
        /// </summary>
        public uint HandleCount;

        /// <summary>
        /// The current number of processes.
        /// </summary>
        public uint ProcessCount;

        /// <summary>
        /// The current number of threads.
        /// </summary>
        public uint ThreadCount;
    }
}