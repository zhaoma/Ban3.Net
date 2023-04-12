using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CRITICAL_SECTION
    {
        /// PRTL_CRITICAL_SECTION_DEBUG->_RTL_CRITICAL_SECTION_DEBUG*
        public System.IntPtr DebugInfo;

        /// LONG->int
        public int LockCount;

        /// LONG->int
        public int RecursionCount;

        /// HANDLE->void*
        public System.IntPtr OwningThread;

        /// HANDLE->void*
        public System.IntPtr LockSemaphore;

        /// ULONG_PTR->unsigned int
        public uint SpinCount;
    }
}