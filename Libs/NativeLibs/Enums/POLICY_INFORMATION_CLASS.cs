namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POLICY_INFORMATION_CLASS enumeration defines values that indicate the type of information to set or query in a Policy object.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_information_class
    /// </summary>
    public enum POLICY_INFORMATION_CLASS
    {
        PolicyAuditLogInformation = 1,
        PolicyAuditEventsInformation,
        PolicyPrimaryDomainInformation,
        PolicyPdAccountInformation,
        PolicyAccountDomainInformation,
        PolicyLsaServerRoleInformation,
        PolicyReplicaSourceInformation,
        PolicyDefaultQuotaInformation,
        PolicyModificationInformation,
        PolicyAuditFullSetInformation,
        PolicyAuditFullQueryInformation,
        PolicyDnsDomainInformation,
        PolicyDnsDomainInformationInt,
        PolicyLocalAccountDomainInformation,
        PolicyMachineAccountInformation,
        PolicyLastEntry

    }
}