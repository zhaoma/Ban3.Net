namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The MSV1_0_PROTOCOL_MESSAGE_TYPE enumeration lists the types of messages that can be sent to the MSV1_0 Authentication Package by calling the LsaCallAuthenticationPackage function.
    /// Each message corresponds to a dispatch routine and causes the MSV1_0 authentication package to perform a different task.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-msv1_0_protocol_message_type
    /// </summary>
    public enum MSV1_0_PROTOCOL_MESSAGE_TYPE
    {
        MsV1_0Lm20ChallengeRequest = 0,
        MsV1_0Lm20GetChallengeResponse,
        MsV1_0EnumerateUsers,
        MsV1_0GetUserInfo,
        MsV1_0ReLogonUsers,
        MsV1_0ChangePassword,
        MsV1_0ChangeCachedPassword,
        MsV1_0GenericPassthrough,
        MsV1_0CacheLogon,
        MsV1_0SubAuth,
        MsV1_0DeriveCredential,
        MsV1_0CacheLookup,
        MsV1_0SetProcessOption,
        MsV1_0ConfigLocalAliases,
        MsV1_0ClearCachedCredentials,
        MsV1_0LookupToken,
        MsV1_0ValidateAuth,
        MsV1_0CacheLookupEx,
        MsV1_0GetCredentialKey,
        MsV1_0SetThreadOption,
        MsV1_0DecryptDpapiMasterKey,
        MsV1_0GetStrongCredentialKey,
        MsV1_0TransferCred,
        MsV1_0ProvisionTbal,
        MsV1_0DeleteTbalSecrets
    }
}