//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/9 20:34
//  function:	ENCRYPTION_CERTIFICATE_LIST.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a list of certificates.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/ns-winefs-encryption_certificate_list
    /// </summary>
	public struct ENCRYPTION_CERTIFICATE_LIST
    {
        /// <summary>
        /// The number of certificates in the list.
        /// </summary>
        public uint nCert_Hash;

        /// <summary>
        /// A pointer to the first ENCRYPTION_CERTIFICATE structure in the list.
        /// </summary>
        public ENCRYPTION_CERTIFICATE[] pUsers;
    }
}

