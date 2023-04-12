using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_TRANSPORT_ADDRESS structure specifies the addresses (local and remote) used for a particular HTTP connection.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_transport_address
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_TRANSPORT_ADDRESS
    {
        /// <summary>
        /// A pointer to the remote IP address associated with this connection.
        /// For more information about how to access this address, see the Remarks section.
        /// </summary>
        public System.IntPtr pRemoteAddress;

        /// <summary>
        /// A pointer to the local IP address associated with this connection.
        /// </summary>
        public System.IntPtr pLocalAddress;
    }
}