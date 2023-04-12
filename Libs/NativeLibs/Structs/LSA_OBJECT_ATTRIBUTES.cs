using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The LSA_OBJECT_ATTRIBUTES structure is used with the LsaOpenPolicy function to specify the attributes of the connection to the Policy object.
    /// When you call LsaOpenPolicy, initialize the members of this structure to NULL or zero because the function does not use the information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/lsalookup/ns-lsalookup-lsa_object_attributes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LSA_OBJECT_ATTRIBUTES
    {
        /// ULONG->unsigned int
        public uint Length;

        /// HANDLE->void*
        public System.IntPtr RootDirectory;

        /// PVOID->void*
        public System.IntPtr ObjectName;

        /// ULONG->unsigned int
        public uint Attributes;

        /// PVOID->void*
        public System.IntPtr SecurityDescriptor;

        /// PVOID->void*
        public System.IntPtr SecurityQualityOfService;
    }
}