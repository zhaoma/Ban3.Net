//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/4/1 17:40
//  function:	Psapi.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
using Ban3.Infrastructures.NativeLibs.Structs;
using System.Runtime.InteropServices;
using System.Text;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Documented
{

    /// <summary>
    /// Process Status API (PSAPI) 
    /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/
    /// </summary>
    public static class PSAPI
    {
        const string Dll = "psapi.dll";

        /*
         *
        1 (0x0001),  (0x), EmptyWorkingSet, 0x000013c0, None
        2 (0x0002),  (0x), EnumDeviceDrivers, 0x00001090, None
        3 (0x0003),  (0x), EnumPageFilesA, 0x000013e0, None
        4 (0x0004),  (0x), EnumPageFilesW, 0x00001400, None
        5 (0x0005),  (0x), EnumProcessModules, 0x00001010, None
        6 (0x0006),  (0x), EnumProcessModulesEx, 0x00001420, None
        7 (0x0007),  (0x), EnumProcesses, 0x00001030, None
        8 (0x0008),  (0x), GetDeviceDriverBaseNameA, 0x00001440, None
        9 (0x0009),  (0x), GetDeviceDriverBaseNameW, 0x000010b0, None
        10 (0x000a),  (0x), GetDeviceDriverFileNameA, 0x00001460, None
        11 (0x000b),  (0x), GetDeviceDriverFileNameW, 0x00001480, None
        12 (0x000c),  (0x), GetMappedFileNameA, 0x000014a0, None
        13 (0x000d),  (0x), GetMappedFileNameW, 0x000014c0, None
        14 (0x000e),  (0x), GetModuleBaseNameA, 0x000014e0, None
        15 (0x000f),  (0x), GetModuleBaseNameW, 0x000010d0, None
        16 (0x0010),  (0x), GetModuleFileNameExA, 0x00001500, None
        17 (0x0011),  (0x), GetModuleFileNameExW, 0x00001050, None
        18 (0x0012),  (0x), GetModuleInformation, 0x000010f0, None
        19 (0x0013),  (0x), GetPerformanceInfo, 0x00001520, None
        20 (0x0014),  (0x), GetProcessImageFileNameA, 0x00001540, None
        21 (0x0015),  (0x), GetProcessImageFileNameW, 0x00001070, None
        22 (0x0016),  (0x), GetProcessMemoryInfo, 0x00001560, None
        23 (0x0017),  (0x), GetWsChanges, 0x000015a0, None
        24 (0x0018),  (0x), GetWsChangesEx, 0x00001580, None
        25 (0x0019),  (0x), InitializeProcessForWsWatch, 0x000015c0, None
        26 (0x001a),  (0x), QueryWorkingSet, 0x00001600, None
        27 (0x001b),  (0x), QueryWorkingSetEx, 0x000015e0, None
         *
         */

        /// <summary>
        /// Removes as many pages as possible from the working set of the specified process.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-emptyworkingset
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right and the PROCESS_SET_QUOTA access right.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool EmptyWorkingSet(
            IntPtr hProcess
        );

        /// <summary>
        /// Retrieves the load address for each device driver in the system.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-enumdevicedrivers
        /// </summary>
        /// <param name="lpImageBase">An array that receives the list of load addresses for the device drivers.</param>
        /// <param name="cb">
        /// The size of the lpImageBase array, in bytes.
        /// If the array is not large enough to store the load addresses, the lpcbNeeded parameter receives the required size of the array.
        /// </param>
        /// <param name="lpcbNeeded">The number of bytes returned in the lpImageBase array.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDeviceDrivers(
            ref IntPtr lpImageBase,
            uint cb,
            ref uint lpcbNeeded
        );

        /// <summary>
        /// Calls the callback routine for each installed pagefile in the system.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-enumpagefilesa
        /// </summary>
        /// <param name="pCallBackRoutine">A pointer to the routine called for each pagefile.</param>
        /// <param name="pContext">The user-defined data passed to the callback routine.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumPageFilesA(
            out IntPtr pCallBackRoutine,
            IntPtr pContext
        );

        /// almost same as EnumPageFilesA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumPageFilesW(
            IntPtr pCallBackRoutine,
            IntPtr pContext
        );

        /// <summary>
        /// Retrieves the process identifier for each process object in the system.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-enumprocesses
        /// </summary>
        /// <param name="lpidProcess">[out] lpidProcess:A pointer to an array that receives the list of process identifiers.</param>
        /// <param name="cb">[in] cb:The size of the pProcessIds array, in bytes.</param>
        /// <param name="lpcbNeeded">[out] lpcbNeeded:The number of bytes returned in the pProcessIds array.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumProcesses(
            out uint lpidProcess, 
            uint cb,
            out uint lpcbNeeded
        );

        /// <summary>
        /// Retrieves a handle for each module in the specified process.
        /// To control whether a 64-bit application enumerates 32-bit modules, 64-bit modules, or both types of modules, use the EnumProcessModulesEx function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-enumprocessmodules
        /// </summary>
        /// <param name="hProcess">A handle to the process.</param>
        /// <param name="lphModule">An array that receives the list of module handles.</param>
        /// <param name="cb">The size of the lphModule array, in bytes.</param>
        /// <param name="lpcbNeeded">The number of bytes required to store all module handles in the lphModule array.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumProcessModules(
            IntPtr hProcess,
            out IntPtr lphModule,
            uint cb,
            out uint lpcbNeeded
        );

        /// <summary>
        /// Retrieves a handle for each module in the specified process that meets the specified filter criteria.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-enumprocessmodulesex
        /// </summary>
        /// <param name="hProcess">A handle to the process.</param>
        /// <param name="lphModule">An array that receives the list of module handles.</param>
        /// <param name="cb">The size of the lphModule array, in bytes.</param>
        /// <param name="lpcbNeeded">The number of bytes required to store all module handles in the lphModule array.</param>
        /// <param name="dwFilterFlag"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumProcessModulesEx(
            IntPtr hProcess,
            ref IntPtr lphModule,
            uint cb,
            ref uint lpcbNeeded,
            LIST_MODULES_FLAGS dwFilterFlag
        );

        /// <summary>
        /// Retrieves the base name of the specified device driver.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getdevicedriverbasenamea
        /// </summary>
        /// <param name="ImageBase">
        /// The load address of the device driver.
        /// This value can be retrieved using the EnumDeviceDrivers function.
        /// </param>
        /// <param name="lpFilename"></param>
        /// <param name="nSize"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetDeviceDriverBaseNameA(
            IntPtr ImageBase,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpFilename,
            uint nSize
        );

        /// almost same as GetDeviceDriverBaseNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetDeviceDriverBaseNameW(
            IntPtr ImageBase,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpBaseName,
            uint nSize
        );

        /// <summary>
        /// Retrieves the path available for the specified device driver.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getdevicedriverfilenamea
        /// </summary>
        /// <param name="ImageBase">The load address of the device driver.</param>
        /// <param name="lpFilename">A pointer to the buffer that receives the path to the device driver.</param>
        /// <param name="nSize">
        /// The size of the lpFilename buffer, in characters.
        /// If the buffer is not large enough to store the path plus the terminating null character, the string is truncated.
        /// </param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetDeviceDriverFileNameA(
            IntPtr ImageBase,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpFilename,
            uint nSize
        );

        /// almost same as GetDeviceDriverFileNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetDeviceDriverFileNameW(
            IntPtr ImageBase,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpFilename,
            uint nSize
        );

        /// <summary>
        /// Checks whether the specified address is within a memory-mapped file in the address space of the specified process.
        /// If so, the function returns the name of the memory-mapped file.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getmappedfilenamea
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the PROCESS_QUERY_INFORMATION access right.
        /// </param>
        /// <param name="lpv">The address to be verified.</param>
        /// <param name="lpFilename">A pointer to the buffer that receives the name of the memory-mapped file to which the address specified by lpv belongs.</param>
        /// <param name="nSize">The size of the lpFilename buffer, in characters.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetMappedFileNameA(
            IntPtr hProcess,
            IntPtr lpv,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpFilename,
            uint nSize
        );

        /// almost same as GetMappedFileNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetMappedFileNameW(
            IntPtr hProcess,
            IntPtr lpv,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpFilename,
            uint nSize
        );

        /// <summary>
        /// Retrieves the base name of the specified module.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getmodulebasenamea
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process that contains the module.
        /// The handle must have the PROCESS_QUERY_INFORMATION and PROCESS_VM_READ access rights.
        /// </param>
        /// <param name="hModule">
        /// A handle to the module. If this parameter is NULL,
        /// this function returns the name of the file used to create the calling process.
        /// </param>
        /// <param name="lpBaseName">
        /// A pointer to the buffer that receives the base name of the module.
        /// If the base name is longer than maximum number of characters specified by the nSize parameter, the base name is truncated.
        /// </param>
        /// <param name="nSize">The size of the lpBaseName buffer, in characters.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetModuleBaseNameA(
            IntPtr hProcess,
            IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpBaseName,
            uint nSize
        );

        /// almost same as GetModuleBaseNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetModuleBaseNameW(
            IntPtr hProcess,
            IntPtr hModule,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpBaseName,
            uint nSize
        );

        /// <summary>
        /// Retrieves the fully qualified path for the file containing the specified module.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getmodulefilenameexa
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process that contains the module.
        /// The handle must have the PROCESS_QUERY_INFORMATION and PROCESS_VM_READ access rights.
        /// The GetModuleFileNameEx function does not retrieve the path for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag.
        /// </param>
        /// <param name="hModule">
        /// A handle to the module.
        /// If this parameter is NULL, GetModuleFileNameEx returns the path of the executable file of the process specified in hProcess.
        /// </param>
        /// <param name="lpFilename">
        /// A pointer to a buffer that receives the fully qualified path to the module.
        /// If the size of the file name is larger than the value of the nSize parameter,
        /// the function succeeds but the file name is truncated and null-terminated.
        /// </param>
        /// <param name="nSize">The size of the lpFilename buffer, in characters.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetModuleFileNameExA(
            IntPtr hProcess,
            IntPtr hModule,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpFilename,
            uint nSize
        );

        /// almost same as GetModuleFileNameExA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetModuleFileNameExW(
            IntPtr hProcess,
            IntPtr hModule,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpFilename,
            uint nSize
        );

        /// <summary>
        /// Retrieves information about the specified module in the MODULEINFO structure.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getmoduleinformation
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process that contains the module.
        /// The handle must have the PROCESS_QUERY_INFORMATION and PROCESS_VM_READ access rights.
        /// </param>
        /// <param name="hModule">A handle to the module.</param>
        /// <param name="lpmodinfo">A pointer to the MODULEINFO structure that receives information about the module.</param>
        /// <param name="cb">The size of the MODULEINFO structure, in bytes.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleInformation(
            IntPtr hProcess,
            IntPtr hModule,
            out MODULEINFO lpmodinfo,
            uint cb
        );

        /// <summary>
        /// Retrieves the performance values contained in the PERFORMANCE_INFORMATION structure.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getperformanceinfo
        /// </summary>
        /// <param name="pPerformanceInformation">
        /// A pointer to a PERFORMANCE_INFORMATION structure that receives the performance information.
        /// </param>
        /// <param name="cb">The size of the PERFORMANCE_INFORMATION structure, in bytes.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo(
            out IntPtr pPerformanceInformation,
            uint cb
        );

        /// <summary>
        /// Retrieves the name of the executable file for the specified process.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getprocessimagefilenamea
        /// </summary>
        /// <param name="hProcess">A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.</param>
        /// <param name="lpImageFileName">A pointer to a buffer that receives the full path to the executable file.</param>
        /// <param name="nSize">The size of the lpImageFileName buffer, in characters.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetProcessImageFileNameA(
            IntPtr hProcess,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpImageFileName,
            uint nSize
        );

        /// almost same as GetProcessImageFileNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetProcessImageFileNameW(
            IntPtr hProcess,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpImageFileName,
            uint nSize
        );

        /// <summary>
        /// Retrieves information about the memory usage of the specified process.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getprocessmemoryinfo
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
        /// For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP: The handle must have the PROCESS_QUERY_INFORMATION and PROCESS_VM_READ access rights.
        /// </param>
        /// <param name="ppsmemCounters">
        /// A pointer to the PROCESS_MEMORY_COUNTERS or PROCESS_MEMORY_COUNTERS_EX structure that receives information about the memory usage of the process.
        /// </param>
        /// <param name="cb">The size of the ppsmemCounters structure, in bytes.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetProcessMemoryInfo(
            IntPtr hProcess,
            out IntPtr ppsmemCounters,
            uint cb
        );

        /// <summary>
        /// Retrieves information about the pages that have been added to the working set of the specified process since the last time this function or the InitializeProcessForWsWatch function was called.
        /// To retrieve extended information, use the GetWsChangesEx function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getwschanges
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process.
        /// The handle must have the PROCESS_QUERY_INFORMATION access right.
        /// For more information, see Process Security and Access Rights.
        /// </param>
        /// <param name="lpWatchInfo">
        /// A pointer to a user-allocated buffer that receives an array of PSAPI_WS_WATCH_INFORMATION structures.
        /// The array is terminated with a structure whose FaultingPc member is NULL.
        /// </param>
        /// <param name="cb">The size of the lpWatchInfo buffer, in bytes.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWsChanges(
            IntPtr hProcess,
            out IntPtr lpWatchInfo,
            uint cb
        );

        /// <summary>
        /// Retrieves extended information about the pages that have been added to the working set of the specified process since the last time this function or the InitializeProcessForWsWatch function was called.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-getwschangesex
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpWatchInfoEx">A pointer to a user-allocated buffer that receives an array of PSAPI_WS_WATCH_INFORMATION_EX structures.
        /// The array is terminated with a structure whose FaultingPc member is NULL.
        /// </param>
        /// <param name="cb">The size of the lpWatchInfoEx buffer, in bytes.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWsChangesEx(
            IntPtr hProcess,
            out IntPtr lpWatchInfoEx,
            uint cb
        );

        /// <summary>
        /// Initiates monitoring of the working set of the specified process.
        /// You must call this function before calling the GetWsChanges function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-initializeprocessforwswatch
        /// </summary>
        /// <param name="hProcess">A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION access right.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitializeProcessForWsWatch(
            IntPtr hProcess
        );

        public delegate bool PENUM_PAGE_FILE_CALLBACKA(
            System.IntPtr pContext,
            System.IntPtr pPageFileInfo,
            [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)]
            string lpFilename
        );

        public delegate bool PENUM_PAGE_FILE_CALLBACKW(
            System.IntPtr pContext,
            System.IntPtr pPageFileInfo,
            [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPWStr)]
            string lpFilename
        );

        /// <summary>
        /// Retrieves information about the pages currently added to the working set of the specified process.
        /// To retrieve working set information for a subset of virtual addresses, or to retrieve information about pages that are not part of the working set (such as AWE or large pages), use the QueryWorkingSetEx function.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-queryworkingset
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION and PROCESS_VM_READ access rights.
        /// </param>
        /// <param name="pv">
        /// A pointer to the buffer that receives the information. For more information, see PSAPI_WORKING_SET_INFORMATION.
        /// If the buffer pointed to by the pv parameter is not large enough to contain all working set entries for the target process,
        /// the function fails with ERROR_BAD_LENGTH.
        /// In this case, the NumberOfEntries member of the PSAPI_WORKING_SET_INFORMATION structure is set to the required number of entries,
        /// but the function does not return information about the working set entries.
        /// </param>
        /// <param name="cb">The size of the pv buffer, in bytes.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryWorkingSet(
            IntPtr hProcess,
            out IntPtr pv,
            uint cb
        );

        /// <summary>
        /// Retrieves extended information about the pages at specific virtual addresses in the address space of the specified process.
        /// https://learn.microsoft.com/en-us/windows/win32/api/psapi/nf-psapi-queryworkingsetex
        /// </summary>
        /// <param name="hProcess">A handle to the process.</param>
        /// <param name="pv">A pointer to an array of PSAPI_WORKING_SET_EX_INFORMATION structures.</param>
        /// <param name="cb">The size of the pv buffer, in bytes.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryWorkingSetEx(
            IntPtr hProcess,
            out IntPtr pv,
            uint cb
        );
    }
}
