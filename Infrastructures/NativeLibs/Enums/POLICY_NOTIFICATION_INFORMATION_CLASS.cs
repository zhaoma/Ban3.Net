namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POLICY_NOTIFICATION_INFORMATION_CLASS enumeration defines the types of policy information and policy domain information for which your application can request notification of changes.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_notification_information_class
    /// </summary>
    public enum POLICY_NOTIFICATION_INFORMATION_CLASS
    {
        PolicyNotifyAuditEventsInformation = 1,
        PolicyNotifyAccountDomainInformation,
        PolicyNotifyServerRoleInformation,
        PolicyNotifyDnsDomainInformation,
        PolicyNotifyDomainEfsInformation,
        PolicyNotifyDomainKerberosTicketInformation,
        PolicyNotifyMachineAccountPasswordInformation,
        PolicyNotifyGlobalSaclInformation,
        PolicyNotifyMax
    }
}