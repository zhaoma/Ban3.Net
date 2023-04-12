namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POLICY_LSA_SERVER_ROLE enumeration type defines values that indicate the role of an LSA server. The LsaQueryInformationPolicy and LsaSetInformationPolicy functions use this enumeration type when their InformationClass parameters are set to PolicyLsaServerRoleInformation.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_lsa_server_role
    /// </summary>
    public enum POLICY_LSA_SERVER_ROLE
    {
        PolicyServerRoleBackup = 2,
        PolicyServerRolePrimary
    }
}