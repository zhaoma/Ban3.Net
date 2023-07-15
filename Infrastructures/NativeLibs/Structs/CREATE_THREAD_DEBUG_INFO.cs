using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CREATE_THREAD_DEBUG_INFO
    {
        /// HANDLE->void*
        public System.IntPtr hThread;

        /// LPVOID->void*
        public System.IntPtr lpThreadLocalBase;

        /// LPTHREAD_START_ROUTINE->PTHREAD_START_ROUTINE
        public PTHREAD_START_ROUTINE lpStartAddress;

    }
}