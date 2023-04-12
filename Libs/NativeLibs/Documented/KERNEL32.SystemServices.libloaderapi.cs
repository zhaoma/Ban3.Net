using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// libloaderapi.h      This header is used by multiple technologies.
    /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-adddlldirectory
    /// </summary>
    public static partial class KERNEL32
    {
        /*

        9 (0x0009),  (0x), AddDllDirectory, api-ms-win-core-libraryloader-l1-1-0.AddDllDirectory, None
        294 (0x0126),  (0x), DisableThreadLibraryCalls, 0x00020680, None
        437 (0x01b5),  (0x), FreeLibrary, 0x0001cf90, None
        438 (0x01b6),  (0x), FreeLibraryAndExitThread, 0x000217f0, None
        439 (0x01b7),  (0x), FreeLibraryWhenCallbackReturns, NTDLL.TpCallbackUnloadDllOnCompletion, None

        637 (0x027d),  (0x), GetModuleFileNameA, 0x0001f960, None
        638 (0x027e),  (0x), GetModuleFileNameW, 0x0001e6e0, None
        639 (0x027f),  (0x), GetModuleHandleA, 0x0001f870, None
        640 (0x0280),  (0x), GetModuleHandleExA, 0x00021750, None
        641 (0x0281),  (0x), GetModuleHandleExW, 0x0001fdf0, None
        642 (0x0282),  (0x), GetModuleHandleW, 0x0001d8f0, None
        
        697 (0x02b9),  (0x), GetProcAddress, 0x0001b690, None
        969 (0x03c9),  (0x), LoadLibraryA, 0x00020cb0, None
        970 (0x03ca),  (0x), LoadLibraryExA, 0x00020380, None
        971 (0x03cb),  (0x), LoadLibraryExW, 0x0001b590, None
        972 (0x03cc),  (0x), LoadLibraryW, 0x000206a0, None
        1217 (0x04c1),  (0x), RemoveDllDirectory, api-ms-win-core-libraryloader-l1-1-0.RemoveDllDirectory, None
        1309 (0x051d),  (0x), SetDefaultDllDirectories, api-ms-win-core-libraryloader-l1-1-0.SetDefaultDllDirectories, None

         */

        /// <summary>
        /// Adds a directory to the process DLL search path.
        /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-adddlldirectory
        /// </summary>
        /// <param name="NewDirectory">
        /// An absolute path to the directory to add to the search path. 
        /// For example, to add the directory Dir2 to the process DLL search path, specify \Dir2.
        /// </param>
        /// <returns>
        /// If the function succeeds, 
        /// the return value is an opaque pointer that can be passed to RemoveDllDirectory to remove the DLL from the process DLL search path.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern int AddDllDirectory(
            [MarshalAs(UnmanagedType.LPWStr)] string NewDirectory
            );

        /// <summary>
        /// The cookie returned by AddDllDirectory when the directory was added to the search path.
        /// </summary>
        /// <param name="Cookie"></param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveDllDirectory(
            int Cookie
            );

        /// <summary>
        /// Specifies a default set of directories to search when the calling process loads a DLL. 
        /// This search path is used when LoadLibraryEx is called with no LOAD_LIBRARY_SEARCH flags.
        /// </summary>
        /// <param name="DirectoryFlags">The directories to search.(Flags Enums)</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetDefaultDllDirectories(
            uint DirectoryFlags
            );

        /// <summary>
        /// Disables the DLL_THREAD_ATTACH and DLL_THREAD_DETACH notifications for the specified dynamic-link library (DLL). 
        /// This can reduce the size of the working set for some applications.
        /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-disablethreadlibrarycalls
        /// </summary>
        /// <param name="hLibModule">
        /// A handle to the DLL module for which the DLL_THREAD_ATTACH and DLL_THREAD_DETACH notifications are to be disabled. 
        /// The LoadLibrary, LoadLibraryEx, or GetModuleHandle function returns this handle. 
        /// Note that you cannot call GetModuleHandle with NULL because this returns the base address of the executable image, not the DLL image.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. The DisableThreadLibraryCalls function fails if the DLL specified by hModule has active static thread local storage, or if hModule is an invalid module handle.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableThreadLibraryCalls(
            IntPtr hLibModule
            );

        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, 
        /// if necessary, decrements its reference count. 
        /// When the reference count reaches zero, 
        /// the module is unloaded from the address space of the calling process and the handle is no longer valid.
        /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-freelibrary
        /// </summary>
        /// <param name="hLibModule">
        /// A handle to the loaded library module. 
        /// The LoadLibrary, LoadLibraryEx,GetModuleHandle, or GetModuleHandleEx function returns this handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call the GetLastError function.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(
            IntPtr hLibModule
            );

        /// <summary>
        /// Decrements the reference count of a loaded dynamic-link library (DLL) by one, 
        /// then calls ExitThread to terminate the calling thread. 
        /// The function does not return.
        /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-freelibraryandexitthread
        /// </summary>
        /// <param name="hLibModule">A handle to the DLL module whose reference count the function decrements.</param>
        /// <param name="dwExitCode">The exit code for the calling thread.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern void FreeLibraryAndExitThread(
            IntPtr hLibModule,
            int dwExitCode
            );

        /// <summary>
        /// Retrieves the fully qualified path for the file that contains the specified module. 
        /// The module must have been loaded by the current process.
        /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulefilenamea
        /// </summary>
        /// <param name="hModule">
        /// A handle to the loaded module whose path is being requested.
        /// If this parameter is NULL, GetModuleFileName retrieves the path of the executable file of the current process.
        /// </param>
        /// <param name="lpFilename">A pointer to a buffer that receives the fully qualified path of the module.</param>
        /// <param name="nSize">The size of the lpFilename buffer, in TCHARs.</param>
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetModuleFileNameA(
            IntPtr hModule, 
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpFilename, 
            uint nSize
            );

        /// same as GetModuleFileNameA
        [DllImport(Dll, SetLastError = true)]
        public static extern uint GetModuleFileNameW(
            IntPtr hModule,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpFilename,
            uint nSize
            );

        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// To avoid the race conditions described in the Remarks section, use the GetModuleHandleEx function.
        /// </summary>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file). 
        /// If the file name extension is omitted, the default library extension .dll is appended.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified module.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetModuleHandleA(
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpModuleName
            );

        /// same as GetModuleHandleA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetModuleHandleW(
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpModuleName
            );

        /// <summary>
        /// Retrieves a module handle for the specified module and increments the module's reference count unless GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT is specified.
        /// The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="lpModuleName"></param>
        /// <param name="phModule"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return:MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleHandleExA(
            uint dwFlags,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpModuleName,
            ref IntPtr phModule
            );

        /// same as GetModuleHandleExA
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleHandleExW(
            uint dwFlags,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpModuleName,
            ref IntPtr phModule
            );

        /// <summary>
        /// Retrieves the address of an exported function (also known as a procedure) or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="lib">A handle to the DLL module that contains the function or variable.</param>
        /// <param name="funcName">
        /// The function or variable name, or the function's ordinal value. 
        /// If this parameter is an ordinal value, 
        /// it must be in the low-order word; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the exported function or variable.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// public delegate int FARPROC();
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr GetProcAddress(
            IntPtr hModule, 
            string lpProcName
            );

        /// <summary>
        /// Loads the specified module into the address space of the calling process.
        /// </summary>
        /// <param name="lpLibFileName">
        /// The name of the module. 
        /// This can be either a library module (a .dll file) 
        /// or an executable module (an .exe file). If the specified module is an executable module, 
        /// static imports are not loaded; instead, 
        /// the module is loaded as if by LoadLibraryEx with the DONT_RESOLVE_DLL_REFERENCES flag.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the module.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr LoadLibraryA(
            [MarshalAs(UnmanagedType.LPStr)] string lpLibFileName
            );

        /// same as LoadLibraryA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr LoadLibraryW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName
            );

        /// <summary>
        /// Loads the specified module into the address space of the calling process. 
        /// The specified module may cause other modules to be loaded.
        /// https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-loadlibraryexa
        /// </summary>
        /// <param name="lpLibFileName">A string that specifies the file name of the module to load.</param>
        /// <param name="hFile">This parameter is reserved for future use. It must be NULL.</param>
        /// <param name="dwFlags">The action to be taken when loading the module. If no flags are specified, the behavior of this function is identical to that of the LoadLibrary function.</param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr LoadLibraryExA(
            [MarshalAs(UnmanagedType.LPStr)] string lpLibFileName,
            IntPtr hFile,
            uint dwFlags
            );

        /// same as LoadLibraryExA
        [DllImport(Dll, SetLastError = true)]
        public static extern IntPtr LoadLibraryExW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName,
            IntPtr hFile,
            uint dwFlags
            );


    }
}
