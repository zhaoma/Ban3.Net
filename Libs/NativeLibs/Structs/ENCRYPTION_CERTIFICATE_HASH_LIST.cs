//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/9 20:33
//  function:	ENCRYPTION_CERTIFICATE_HASH_LIST.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a list of certificate hashes.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/ns-winefs-encryption_certificate_hash_list
    /// </summary>
	public struct ENCRYPTION_CERTIFICATE_HASH_LIST
	{
        /// <summary>
        /// The number of certificate hashes in the list.
        /// </summary>
        public uint nCert_Hash;

        /// <summary>
        /// A pointer to the first ENCRYPTION_CERTIFICATE_HASH structure in the list.
        /// </summary>
        public ENCRYPTION_CERTIFICATE_HASH[] pUsers;
    }
}

