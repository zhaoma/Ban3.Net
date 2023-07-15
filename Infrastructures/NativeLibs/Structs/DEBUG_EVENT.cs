using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Describes a debugging event.
    /// https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-debug_event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_EVENT
    {

        /// DWORD->unsigned int
        public uint dwDebugEventCode;

        /// DWORD->unsigned int
        public uint dwProcessId;

        /// DWORD->unsigned int
        public uint dwThreadId;

        /// Anonymous_7b4c34ae_4ce0_4bbd_ac97_c5a1d3f477ff
        public DEBUG_EVENT_UNION u;

    }


    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct DEBUG_EVENT_UNION
    {

        /// EXCEPTION_DEBUG_INFO->_EXCEPTION_DEBUG_INFO
        [FieldOffset(0)]
        public EXCEPTION_DEBUG_INFO Exception;

        /// CREATE_THREAD_DEBUG_INFO->_CREATE_THREAD_DEBUG_INFO
        [FieldOffset(0)]
        public CREATE_THREAD_DEBUG_INFO CreateThread;

        /// CREATE_PROCESS_DEBUG_INFO->_CREATE_PROCESS_DEBUG_INFO
        [FieldOffset(0)]
        public CREATE_PROCESS_DEBUG_INFO CreateProcessInfo;

        /// EXIT_THREAD_DEBUG_INFO->_EXIT_THREAD_DEBUG_INFO
        [FieldOffset(0)]
        public EXIT_THREAD_DEBUG_INFO ExitThread;

        /// EXIT_PROCESS_DEBUG_INFO->_EXIT_PROCESS_DEBUG_INFO
        [FieldOffset(0)]
        public EXIT_PROCESS_DEBUG_INFO ExitProcess;

        /// LOAD_DLL_DEBUG_INFO->_LOAD_DLL_DEBUG_INFO
        [FieldOffset(0)]
        public LOAD_DLL_DEBUG_INFO LoadDll;

        /// UNLOAD_DLL_DEBUG_INFO->_UNLOAD_DLL_DEBUG_INFO
        [FieldOffset(0)]
        public UNLOAD_DLL_DEBUG_INFO UnloadDll;

        /// OUTPUT_DEBUG_STRING_INFO->_OUTPUT_DEBUG_STRING_INFO
        [FieldOffset(0)]
        public OUTPUT_DEBUG_STRING_INFO DebugString;

        /// RIP_INFO->_RIP_INFO
        [FieldOffset(0)]
        public RIP_INFO RipInfo;
    }
    

}