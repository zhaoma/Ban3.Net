using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SID_AND_ATTRIBUTES_HASH structure specifies a hash values for the specified array of security identifiers (SIDs).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-sid_and_attributes_hash
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SID_AND_ATTRIBUTES_HASH
    {
        /// DWORD->unsigned int
        public uint SidCount;

        /// PSID_AND_ATTRIBUTES->_SID_AND_ATTRIBUTES*
        public System.IntPtr SidAttr;

        /// SID[]
        public SID[] Hash;
    }
}