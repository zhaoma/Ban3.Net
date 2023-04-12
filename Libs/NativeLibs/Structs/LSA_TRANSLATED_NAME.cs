using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The LSA_TRANSLATED_NAME structure is used with the LsaLookupSids function to return information about the account identified by a SID.
    /// https://learn.microsoft.com/en-us/windows/win32/api/lsalookup/ns-lsalookup-lsa_translated_name
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LSA_TRANSLATED_NAME
    {
        public SID_NAME_USE Use;
        public LSA_UNICODE_STRING Name;
        public uint DomainIndex;
    }
}