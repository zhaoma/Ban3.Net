using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_DEVICE_CLAIMS structure defines the device claims for the token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_device_claims
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_DEVICE_CLAIMS
    {
        public IntPtr DeviceClaims;
    }
}