namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POLICY_DOMAIN_INFORMATION_CLASS enumeration defines the type of policy domain information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_domain_information_class
    /// </summary>
    public enum POLICY_DOMAIN_INFORMATION_CLASS
    {

        PolicyDomainQualityOfServiceInformation = 1,
        PolicyDomainEfsInformation = 2,
        PolicyDomainKerberosTicketInformation
    }
}