namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The MSV1_0_PROFILE_BUFFER_TYPE enumeration lists the kind of logon profile returned.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-msv1_0_profile_buffer_type
    /// </summary>
    public enum MSV1_0_PROFILE_BUFFER_TYPE
    {
        MsV1_0InteractiveProfile = 2,
        MsV1_0Lm20LogonProfile,
        MsV1_0SmartCardProfile
    }
}