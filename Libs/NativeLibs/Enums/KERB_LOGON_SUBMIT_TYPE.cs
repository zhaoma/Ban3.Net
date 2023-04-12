namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KERB_LOGON_SUBMIT_TYPE enumeration identifies the type of logon being requested.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-kerb_logon_submit_type
    /// </summary>
    public enum KERB_LOGON_SUBMIT_TYPE
    {
        /// <summary>
        /// Perform an interactive logon.
        /// </summary>
        KerbInteractiveLogon = 2,

        /// <summary>
        /// Logon using a smart card.
        /// </summary>
        KerbSmartCardLogon = 6,

        /// <summary>
        /// Unlock a workstation.
        /// </summary>
        KerbWorkstationUnlockLogon = 7,

        /// <summary>
        /// Unlock a workstation using a smart card.
        /// </summary>
        KerbSmartCardUnlockLogon = 8,

        /// <summary>
        /// Logon using a proxy server.
        /// </summary>
        KerbProxyLogon = 9,

        /// <summary>
        /// Logon using a valid Kerberos ticket as a credential.
        /// </summary>
        KerbTicketLogon = 10,

        /// <summary>
        /// Unlock a workstation by using a Kerberos ticket.
        /// </summary>
        KerbTicketUnlockLogon = 11,

        /// <summary>
        /// Perform a service for user logon.
        /// </summary>
        KerbS4ULogon = 12,

        /// <summary>
        /// Logon interactively using a certificate stored on a smart card.
        /// </summary>
        KerbCertificateLogon = 13,

        /// <summary>
        /// Perform a service for user logon using a certificate stored on a smart card.
        /// </summary>
        KerbCertificateS4ULogon = 14,

        /// <summary>
        /// Unlock a workstation using a certificate stored on a smart card.
        /// </summary>
        KerbCertificateUnlockLogon = 15,

        /// 
        KerbNoElevationLogon = 83,

        /// 
        KerbLuidLogon = 84
    }
}