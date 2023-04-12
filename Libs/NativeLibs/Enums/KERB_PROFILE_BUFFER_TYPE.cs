namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KERB_PROFILE_BUFFER_TYPE enumeration lists the type of logon profile returned.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-kerb_profile_buffer_type
    /// </summary>
    public enum KERB_PROFILE_BUFFER_TYPE
    {
        /// <summary>
        /// The buffer contains information about an interactive logon session.
        /// </summary>
        KerbInteractiveProfile = 2,

        /// 
        KerbSmartCardProfile = 4,

        /// <summary>
        /// The buffer contains information about a Kerberos logon session.
        /// </summary>
        KerbTicketProfile = 6
    }
}