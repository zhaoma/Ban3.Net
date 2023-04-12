using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Describes a local identifier for an adapter.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-luid
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LUID
    {
        /// DWORD->unsigned int
        public uint LowPart;

        /// LONG->int
        public int HighPart;
    }
}