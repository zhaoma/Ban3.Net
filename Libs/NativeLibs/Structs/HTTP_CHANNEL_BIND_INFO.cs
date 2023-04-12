using System;
using Ban3.Infrastructures.NativeLibs.Enums;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_CHANNEL_BIND_INFO structure is used to set or query channel bind authentication.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_channel_bind_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_CHANNEL_BIND_INFO
    {
        public HTTP_AUTHENTICATION_HARDENING_LEVELS Hardening;
        public uint Flags;
        public IntPtr ServiceNames;
        public uint NumberOfServiceNames;
    }
}