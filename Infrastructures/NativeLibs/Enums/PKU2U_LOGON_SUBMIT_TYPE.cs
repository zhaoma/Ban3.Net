namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Indicates the type of logon message passed in a PKU2U_CERTIFICATE_S4U_LOGON structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-pku2u_logon_submit_type
    /// </summary>
    public enum PKU2U_LOGON_SUBMIT_TYPE
    {
        /// <summary>
        /// The logon message is a PKU2U certificate.
        /// </summary>
        Pku2uCertificateS4ULogon = 14
    }
}