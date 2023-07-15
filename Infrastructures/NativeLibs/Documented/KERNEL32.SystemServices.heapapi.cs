using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// heapapi.h This header is used by System Services.
    /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         
        703 (0x02bf),  (0x), GetProcessHeap, 0x00016190, None
        704 (0x02c0),  (0x), GetProcessHeaps, 0x0003b980, None
        850 (0x0352),  (0x), HeapAlloc, NTDLL.RtlAllocateHeap, None
        851 (0x0353),  (0x), HeapCompact, 0x0003bbd0, None
        852 (0x0354),  (0x), HeapCreate, 0x00020710, None
        853 (0x0355),  (0x), HeapDestroy, 0x00021a60, None
        854 (0x0356),  (0x), HeapFree, 0x00015b50, None
        855 (0x0357),  (0x), HeapLock, 0x0003bbf0, None
        856 (0x0358),  (0x), HeapQueryInformation, 0x0003bc10, None
        857 (0x0359),  (0x), HeapReAlloc, NTDLL.RtlReAllocateHeap, None
        858 (0x035a),  (0x), HeapSetInformation, 0x00020ba0, None
        859 (0x035b),  (0x), HeapSize, NTDLL.RtlSizeHeap, None
        860 (0x035c),  (0x), HeapSummary, 0x0003bc30, None
        861 (0x035d),  (0x), HeapUnlock, 0x0003bc50, None
        862 (0x035e),  (0x), HeapValidate, 0x0001c8b0, None
        863 (0x035f),  (0x), HeapWalk, 0x0003bc70, None

         */

        /// <summary>
        /// Retrieves a handle to the default heap of the calling process. This handle can then be used in subsequent calls to the heap functions.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-getprocessheap
        /// </summary>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetProcessHeap();

        /// <summary>
        /// Returns the number of active heaps and retrieves handles to all of the active heaps for the calling process.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-getprocessheaps
        /// </summary>
        /// <param name="NumberOfHeaps"></param>
        /// <param name="ProcessHeaps"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetProcessHeaps(
            uint NumberOfHeaps,
            ref IntPtr ProcessHeaps);

        /// <summary>
        /// Allocates a block of memory from a heap. The allocated memory is not movable.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapalloc
        /// </summary>
        /// <param name="hHeap"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwBytes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr HeapAlloc(
            IntPtr hHeap,
            uint dwFlags,
            uint dwBytes
        );

        /// <summary>
        /// Returns the size of the largest committed free block in the specified heap.
        /// If the Disable heap coalesce on free global flag is set, this function also coalesces adjacent free blocks of memory in the heap.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapcompact
        /// </summary>
        /// <param name="hHeap"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint HeapCompact(
            IntPtr hHeap,
            uint dwFlags
        );

        /// <summary>
        /// Creates a private heap object that can be used by the calling process.
        /// The function reserves space in the virtual address space of the process and allocates physical storage for a specified initial portion of this block.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapcreate
        /// </summary>
        /// <param name="flOptions"></param>
        /// <param name="dwInitialSize"></param>
        /// <param name="dwMaximumSize"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr HeapCreate(
            uint flOptions,
            uint dwInitialSize,
            uint dwMaximumSize
        );

        /// <summary>
        /// Destroys the specified heap object.
        /// It decommits and releases all the pages of a private heap object, and it invalidates the handle to the heap.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapdestroy
        /// </summary>
        /// <param name="hHeap"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapDestroy(
            IntPtr hHeap
        );

        /// <summary>
        /// Frees a memory block allocated from a heap by the HeapAlloc or HeapReAlloc function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapfree
        /// </summary>
        /// <param name="hHeap"></param>
        /// <param name="dwFlags"></param>
        /// <param name="lpMem"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapFree(
            IntPtr hHeap,
            uint dwFlags,
            IntPtr lpMem
        );

        /// <summary>
        /// Attempts to acquire the critical section object, or lock, that is associated with a specified heap.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heaplock
        /// </summary>
        /// <param name="hHeap"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapLock(
            IntPtr hHeap
        );

        /// <summary>
        /// Retrieves information about the specified heap.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapqueryinformation
        /// </summary>
        /// <param name="hHeap"></param>
        /// <param name="HeapInformationClass"></param>
        /// <param name="HeapInformation"></param>
        /// <param name="HeapInformationLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapQueryInformation(
            IntPtr hHeap,
            uint HeapInformationClass,
            ref IntPtr HeapInformation,
            uint HeapInformationLength,
            ref uint ReturnLength
        );

        /// <summary>
        /// Reallocates a block of memory from a heap.
        /// This function enables you to resize a memory block and change other memory block properties.
        /// The allocated memory is not movable.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heaprealloc
        /// </summary>
        /// <param name="hHeap"></param>
        /// <param name="dwFlags"></param>
        /// <param name="lpMem"></param>
        /// <param name="dwBytes"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr HeapReAlloc(
            IntPtr hHeap,
            uint dwFlags,
            IntPtr lpMem,
            uint dwBytes
        );

        /// <summary>
        /// Enables features for a specified heap.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapsetinformation
        /// </summary>
        /// <param name="hHeap"></param>
        /// <param name="HeapInformationClass"></param>
        /// <param name="HeapInformation"></param>
        /// <param name="HeapInformationLength"></param>
        /// <param name="ReturnLength"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapSetInformation(
            IntPtr hHeap,
            uint HeapInformationClass,
            IntPtr HeapInformation,
            uint HeapInformationLength,
            uint ReturnLength
        );

        /// <summary>
        /// Retrieves the size of a memory block allocated from a heap by the HeapAlloc or HeapReAlloc function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapsize
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap in which the memory block resides.
        /// This handle is returned by either the HeapCreate or GetProcessHeap function.
        /// </param>
        /// <param name="dwFlags"></param>
        /// <param name="lpMem"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint HeapSize(
            IntPtr hHeap,
            uint dwFlags,
            IntPtr lpMem
        );

        /// <summary>
        /// Releases ownership of the critical section object, or lock, that is associated with a specified heap.
        /// It reverses the action of the HeapLock function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapunlock
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap to be unlocked.
        /// This handle is returned by either the HeapCreate or GetProcessHeap function.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapUnlock(
            IntPtr hHeap
        );

        /// <summary>
        /// Validates the specified heap.
        /// The function scans all the memory blocks in the heap and verifies that the heap control structures maintained by the heap manager are in a consistent state.
        /// You can also use the HeapValidate function to validate a single memory block within a specified heap without checking the validity of the entire heap.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapvalidate
        /// </summary>
        /// <param name="hHeap">A handle to the heap to be validated.</param>
        /// <param name="dwFlags">
        /// The heap access options. This parameter can be the following value.
        /// HEAP_NO_SERIALIZE   0x00000001  Serialized access will not be used.
        /// </param>
        /// <param name="lpMem">A pointer to a memory block within the specified heap. This parameter may be NULL.</param>
        /// <returns>If the specified heap or memory block is valid, the return value is nonzero.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapValidate(
            IntPtr hHeap,
            uint dwFlags,
            IntPtr lpMem
        );

        /// <summary>
        /// Enumerates the memory blocks in the specified heap.
        /// https://learn.microsoft.com/en-us/windows/win32/api/heapapi/nf-heapapi-heapwalk
        /// </summary>
        /// <param name="hHeap">A handle to the heap. This handle is returned by either the HeapCreate or GetProcessHeap function.</param>
        /// <param name="lpEntry">A pointer to a PROCESS_HEAP_ENTRY structure that maintains state information for a particular heap enumeration.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>

        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapWalk(
            IntPtr hHeap,
            ref IntPtr lpEntry
        );
    }
}
