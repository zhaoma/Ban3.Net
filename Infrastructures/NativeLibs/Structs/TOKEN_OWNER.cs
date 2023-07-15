using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_OWNER structure contains the default owner security identifier (SID) that will be applied to newly created objects.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_owner
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_OWNER
    {
        public System.IntPtr Owner;
    }
}