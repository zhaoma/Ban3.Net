using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_DEFAULT_DACL structure specifies a discretionary access control list (DACL).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_default_dacl
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_DEFAULT_DACL
    {

        public IntPtr DefaultDacl;
    }
}