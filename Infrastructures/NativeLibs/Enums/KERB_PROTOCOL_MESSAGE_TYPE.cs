namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KERB_PROTOCOL_MESSAGE_TYPE enumeration lists the types of messages
    /// that can be sent to the Kerberos authentication package by calling the LsaCallAuthenticationPackage function.
    /// Each message corresponds to a dispatch routine and causes the Kerberos authentication package to perform a different task.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-kerb_protocol_message_type
    /// </summary>
    public enum KERB_PROTOCOL_MESSAGE_TYPE
    {
        KerbDebugRequestMessage = 0,
        KerbQueryTicketCacheMessage,
        KerbChangeMachinePasswordMessage,
        KerbVerifyPacMessage,
        KerbRetrieveTicketMessage,
        KerbUpdateAddressesMessage,
        KerbPurgeTicketCacheMessage,
        KerbChangePasswordMessage,
        KerbRetrieveEncodedTicketMessage,
        KerbDecryptDataMessage,
        KerbAddBindingCacheEntryMessage,
        KerbSetPasswordMessage,
        KerbSetPasswordExMessage,

        KerbQueryTicketCacheExMessage,
        KerbPurgeTicketCacheExMessage,
        KerbRefreshSmartcardCredentialsMessage,
        KerbAddExtraCredentialsMessage = 17,
        KerbQuerySupplementalCredentialsMessage,
        KerbTransferCredentialsMessage,
        KerbQueryTicketCacheEx2Message,
        KerbSubmitTicketMessage,
        KerbAddExtraCredentialsExMessage,
        KerbQueryKdcProxyCacheMessage,
        KerbPurgeKdcProxyCacheMessage,
        KerbQueryTicketCacheEx3Message,
        KerbCleanupMachinePkinitCredsMessage,
        KerbAddBindingCacheEntryExMessage,
        KerbQueryBindingCacheMessage,
        KerbPurgeBindingCacheMessage,
        KerbPinKdcMessage,
        KerbUnpinAllKdcsMessage,
        KerbQueryDomainExtendedPoliciesMessage,
        KerbQueryS4U2ProxyCacheMessage,
        KerbRetrieveKeyTabMessage,
        KerbRefreshPolicyMessage,
        KerbPrintCloudKerberosDebugMessage
    }
}