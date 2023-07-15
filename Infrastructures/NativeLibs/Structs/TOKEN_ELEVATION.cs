using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_ELEVATION structure indicates whether a token has elevated privileges.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_elevation
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_ELEVATION
    {
        public uint TokenIsElevated;
    }
}