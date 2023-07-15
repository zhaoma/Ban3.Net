using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SECURITY_CAPABILITIES structure defines the security capabilities of the app container.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-security_capabilities
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_CAPABILITIES
    {
        /// PISID->_SID*
        public System.IntPtr AppContainerSid;

        /// PSID_AND_ATTRIBUTES->_SID_AND_ATTRIBUTES*
        public System.IntPtr Capabilities;

        /// DWORD->unsigned int
        public uint CapabilityCount;

        /// DWORD->unsigned int
        public uint Reserved;
    }
}