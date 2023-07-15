//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/9 20:29
//  function:	ENCRYPTION_CERTIFICATE_HASH.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Security.Cryptography;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a certificate hash and display information for the certificate.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/ns-winefs-encryption_certificate_hash
    /// </summary>
	public struct ENCRYPTION_CERTIFICATE_HASH
    {
        /// <summary>
        /// The length of this structure, in bytes.
        /// </summary>
        public uint cbTotalLength;

        /// <summary>
        /// The SID of the user who owns the certificate.
        /// </summary>
        public IntPtr pUserSid;

        /// <summary>
        /// A pointer to an EFS_HASH_BLOB structure.
        /// </summary>
        public EFS_HASH_BLOB pHash;

        /// <summary>
        /// User-displayable information for the certificate.
        /// This is usually the user's common name and universal principal name (UPN).
        /// </summary>
        public string lpDisplayInformation;
    }
}

