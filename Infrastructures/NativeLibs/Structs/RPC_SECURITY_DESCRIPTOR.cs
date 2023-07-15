using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The RPC_SECURITY_DESCRIPTOR structure represents the RPC security descriptors.
    /// https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-rrp/9729e781-8eb9-441b-82ca-e898f98d29c2
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RPC_SECURITY_DESCRIPTOR
    {
        /// PBYTE->BYTE*
        public System.IntPtr lpSecurityDescriptor;

        /// DWORD->unsigned int
        public uint cbInSecurityDescriptor;

        /// DWORD->unsigned int
        public uint cbOutSecurityDescriptor;
    }
}