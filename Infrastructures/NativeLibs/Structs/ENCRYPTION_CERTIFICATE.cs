//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/9 20:26
//  function:	ENCRYPTION_CERTIFICATE.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a certificate and the SID of its owner.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/ns-winefs-encryption_certificate
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ENCRYPTION_CERTIFICATE
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
        /// A pointer to an EFS_CERTIFICATE_BLOB structure.
        /// </summary>
        public EFS_CERTIFICATE_BLOB pCertBlob;
    }
}

