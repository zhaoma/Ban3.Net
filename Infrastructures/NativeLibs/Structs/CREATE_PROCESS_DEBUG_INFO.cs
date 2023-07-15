using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains process creation information that can be used by a debugger.
    /// https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-create_process_debug_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CREATE_PROCESS_DEBUG_INFO
    {
        /// HANDLE->void*
        public System.IntPtr hFile;

        /// HANDLE->void*
        public System.IntPtr hProcess;

        /// HANDLE->void*
        public System.IntPtr hThread;

        /// LPVOID->void*
        public System.IntPtr lpBaseOfImage;

        /// DWORD->unsigned int
        public uint dwDebugInfoFileOffset;

        /// DWORD->unsigned int
        public uint nDebugInfoSize;

        /// LPVOID->void*
        public System.IntPtr lpThreadLocalBase;

        /// LPTHREAD_START_ROUTINE->PTHREAD_START_ROUTINE
        public PTHREAD_START_ROUTINE lpStartAddress;

        /// LPVOID->void*
        public System.IntPtr lpImageName;

        /// WORD->unsigned short
        public ushort fUnicode;
    }

    /// Return Type: DWORD->unsigned int
    ///lpThreadParameter: LPVOID->void*
    public delegate uint PTHREAD_START_ROUTINE(IntPtr lpThreadParameter);
}