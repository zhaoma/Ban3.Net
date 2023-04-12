using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a certificate.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/ns-winefs-efs_certificate_blob
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EFS_CERTIFICATE_BLOB
    {
        /// <summary>
        /// A certificate encoding type. This member can be one of the following values.
        /// CRYPT_ASN_ENCODING
        /// CRYPT_NDR_ENCODING
        /// X509_ASN_ENCODING
        /// X509_NDR_ENCODING
        /// </summary>
        public uint dwCertEncodingType;

        /// <summary>
        /// The number of bytes in the pbData buffer.
        /// </summary>
        public uint cbData;

        /// <summary>
        /// The binary certificate.
        /// The dwCertEncodingType member specifies the format for this certificate.
        /// </summary>
        public IntPtr pbData;
    }

}
