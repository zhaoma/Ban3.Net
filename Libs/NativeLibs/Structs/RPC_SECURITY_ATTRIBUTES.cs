using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The RPC_SECURITY_ATTRIBUTES structure represents security attributes that can be set through the Remote Procedure Call Protocol Extensions.
    /// https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-rrp/bc37b8cf-8c94-4804-ad53-0aaf5eaf0ecb
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RPC_SECURITY_ATTRIBUTES
    {
        /// DWORD->unsigned int
        public uint nLength;

        /// PVOID->void*
        public RPC_SECURITY_DESCRIPTOR RpcSecurityDescriptor;

        /// BOOLEAN->BYTE->unsigned char
        public byte bInheritHandle;
    }
}