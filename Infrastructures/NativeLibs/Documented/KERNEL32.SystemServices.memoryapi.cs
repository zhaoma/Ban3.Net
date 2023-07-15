using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class KERNEL32
    {
        /*
         *
        23 (0x0017),  (0x), AllocateUserPhysicalPages, 0x0003ad40, None
        24 (0x0018),  (0x), AllocateUserPhysicalPagesNuma, 0x0003ad20, None
        201 (0x00c9),  (0x), CreateFileMappingFromApp, api-ms-win-core-memory-l1-1-1.CreateFileMappingFromApp, None
        203 (0x00cb),  (0x), CreateFileMappingNumaW, 0x0003b000, None
        204 (0x00cc),  (0x), CreateFileMappingW, 0x0001d0a0, None
        218 (0x00da),  (0x), CreateMemoryResourceNotification, 0x000210a0, None
        297 (0x0129),  (0x), DiscardVirtualMemory, api-ms-win-core-memory-l1-1-2.DiscardVirtualMemory, None
        428 (0x01ac),  (0x), FlushViewOfFile, 0x0003b5f0, None
        442 (0x01ba),  (0x), FreeUserPhysicalPages, 0x0003b630, None
        617 (0x0269),  (0x), GetLargePageMinimum, 0x0003b840, None
        636 (0x027c),  (0x), GetMemoryErrorHandlingCapabilities, 0x0003b860, None
        748 (0x02ec),  (0x), GetSystemFileCacheSize, 0x0003ba60, None
        820 (0x0334),  (0x), GetWriteWatch, 0x000161b0, None
        996 (0x03e4),  (0x), MapUserPhysicalPages, 0x0003c170, None
        998 (0x03e6),  (0x), MapViewOfFile, 0x0001dfb0, None
        999 (0x03e7),  (0x), MapViewOfFileEx, 0x0001d1b0, None
        1000 (0x03e8),  (0x), MapViewOfFileExNuma, 0x0003c190, None
        1001 (0x03e9),  (0x), MapViewOfFileFromApp, api-ms-win-core-memory-l1-1-1.MapViewOfFileFromApp, None
        1027 (0x0403),  (0x), OfferVirtualMemory, api-ms-win-core-memory-l1-1-2.OfferVirtualMemory, None
        1035 (0x040b),  (0x), OpenFileMappingW, 0x00020ee0, None
        1151 (0x047f),  (0x), ReclaimVirtualMemory, api-ms-win-core-memory-l1-1-2.ReclaimVirtualMemory, None
        1069 (0x042d),  (0x), PrefetchVirtualMemory, api-ms-win-core-memory-l1-1-1.PrefetchVirtualMemory, None
        1106 (0x0452),  (0x), QueryMemoryResourceNotification, 0x0003c440, None
        1195 (0x04ab),  (0x), RegisterBadMemoryNotification, 0x0003cb00, None
        1230 (0x04ce),  (0x), ResetWriteWatch, 0x00018310, None
        1374 (0x055e),  (0x), SetSystemFileCacheSize, 0x0003ced0, None
        1476 (0x05c4),  (0x), UnmapViewOfFile, 0x0001e7c0, None
        1477 (0x05c5),  (0x), UnmapViewOfFileEx, api-ms-win-core-memory-l1-1-1.UnmapViewOfFileEx, None
        1480 (0x05c8),  (0x), UnregisterBadMemoryNotification, 0x0003d0a0, None
        1498 (0x05da),  (0x), VirtualAlloc, 0x00018cd0, None
        1499 (0x05db),  (0x), VirtualAllocEx, 0x0003d0e0, None
        1500 (0x05dc),  (0x), VirtualAllocExNuma, 0x00024a00, None
        1501 (0x05dd),  (0x), VirtualFree, 0x0001a900, None
        1502 (0x05de),  (0x), VirtualFreeEx, 0x0003d100, None
        1503 (0x05df),  (0x), VirtualLock, 0x00024b10, None
        1504 (0x05e0),  (0x), VirtualProtect, 0x0001c430, None
        1505 (0x05e1),  (0x), VirtualProtectEx, 0x0003d120, None
        1506 (0x05e2),  (0x), VirtualQuery, 0x0001c960, None
        1507 (0x05e3),  (0x), VirtualQueryEx, 0x0001d7b0, None
        1508 (0x05e4),  (0x), VirtualUnlock, 0x0001cdb0, None
         *
         */

        /// <summary>
        /// Allocates physical memory pages to be mapped and unmapped within any Address Windowing Extensions (AWE) region of a specified process.
        /// 64-bit Windows on Itanium-based systems:  Due to the difference in page sizes, AllocateUserPhysicalPages is not supported for 32-bit applications.
        /// https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-allocateuserphysicalpages
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="NumberOfPages"></param>
        /// <param name="PageArray"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocateUserPhysicalPages(
            IntPtr hProcess,
            ref uint NumberOfPages,
            ref IntPtr PageArray);

        /// <summary>
        /// Allocates physical memory pages to be mapped and unmapped within any Address Windowing Extensions (AWE) region of a specified process and specifies the NUMA node for the physical memory.
        /// https://learn.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-allocateuserphysicalpagesnuma
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="NumberOfPages"></param>
        /// <param name="PageArray"></param>
        /// <param name="nndPreferred"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocateUserPhysicalPagesNuma(
            IntPtr hProcess,
            ref uint NumberOfPages,
            ref IntPtr PageArray,
            uint nndPreferred);


        [DllImport(Dll, SetLastError = true)]
        public static extern System.Int32 VirtualAllocEx(
            System.IntPtr hProcess,
            System.Int32 lpAddress,
            System.Int32 dwSize,
            System.Int16 flAllocationType,
            System.Int16 flProtect
        );

        [DllImport("Kernel32.dll")]
        public static extern System.Int32 VirtualAllocEx(
            int hProcess,
            int lpAddress,
            int dwSize,
            int flAllocationType,
            int flProtect
        );

        [DllImport("Kernel32.dll")]
        public static extern System.Int32 VirtualFreeEx(
            int hProcess,
            int lpAddress,
            int dwSize,
            int flAllocationType
        );

        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In, Out] byte[] buffer,
            int size,
            out IntPtr lpNumberOfBytesWritten);
    }
}