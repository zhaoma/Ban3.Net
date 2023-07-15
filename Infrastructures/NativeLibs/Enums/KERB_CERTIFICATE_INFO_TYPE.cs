namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KERB_CERTIFICATE_INFO_TYPE enumeration specifies the type of certificate information that is provided.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-kerb_certificate_info_type
    /// </summary>
    public enum KERB_CERTIFICATE_INFO_TYPE
    {
        /// <summary>
        /// Identifies certificate hash information as defined by the KERB_CERTIFICATE_HASHINFO structure.
        /// </summary>
        CertHashInfo = 1
    }
}