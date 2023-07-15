using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The LSA_REFERENCED_DOMAIN_LIST structure contains information about the domains referenced in a lookup operation.
    /// https://learn.microsoft.com/en-us/windows/win32/api/lsalookup/ns-lsalookup-lsa_referenced_domain_list
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LSA_REFERENCED_DOMAIN_LIST
    {
        public uint Entries;
        public IntPtr Domains;
    }
}