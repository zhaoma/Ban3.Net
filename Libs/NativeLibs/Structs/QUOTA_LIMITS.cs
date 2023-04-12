using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The QUOTA_LIMITS structure describes the amount of system resources available to a user.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-quota_limits
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct QUOTA_LIMITS
    {

        /// SIZE_T->ULONG_PTR->unsigned int
        public uint PagedPoolLimit;

        /// SIZE_T->ULONG_PTR->unsigned int
        public uint NonPagedPoolLimit;

        /// SIZE_T->ULONG_PTR->unsigned int
        public uint MinimumWorkingSetSize;

        /// SIZE_T->ULONG_PTR->unsigned int
        public uint MaximumWorkingSetSize;

        /// SIZE_T->ULONG_PTR->unsigned int
        public uint PagefileLimit;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER TimeLimit;
    }
}