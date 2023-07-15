using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SECURITY_QUALITY_OF_SERVICE data structure contains information used to support client impersonation.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-security_quality_of_service
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_QUALITY_OF_SERVICE
    {
        public uint Length;
        public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
        public uint ContextTrackingMode;
        public bool EffectiveOnly;
    }
}