namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRUSTED_INFORMATION_CLASS enumeration type defines values that indicate the type of information to set or query for a trusted domain.
    /// Each value has an associated structure that the LsaQueryTrustedDomainInfo and LsaSetTrustedDomainInformation functions use to store the information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-trusted_information_class
    /// </summary>
    public enum TRUSTED_INFORMATION_CLASS
    {
        TrustedDomainNameInformation = 1,
        TrustedControllersInformation,
        TrustedPosixOffsetInformation,
        TrustedPasswordInformation,
        TrustedDomainInformationBasic,
        TrustedDomainInformationEx,
        TrustedDomainAuthInformation,
        TrustedDomainFullInformation,
        TrustedDomainAuthInformationInternal,
        TrustedDomainFullInformationInternal,
        TrustedDomainInformationEx2Internal,
        TrustedDomainFullInformation2Internal,
        TrustedDomainSupportedEncryptionTypes,
        TrustedDomainAuthInformationInternalAes,
        TrustedDomainFullInformationInternalAes

    }
}