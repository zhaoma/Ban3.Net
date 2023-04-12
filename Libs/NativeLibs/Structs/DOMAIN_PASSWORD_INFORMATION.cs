using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The DOMAIN_PASSWORD_INFORMATION structure contains information about a domain's password policy, such as the minimum length for passwords and how unique passwords must be.
    /// It is used in the MSV1_0_CHANGEPASSWORD_RESPONSE structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-domain_password_information
    /// </summary>
    public struct DOMAIN_PASSWORD_INFORMATION
    {

        /// USHORT->unsigned short
        public ushort MinPasswordLength;

        /// USHORT->unsigned short
        public ushort PasswordHistoryLength;

        /// ULONG->unsigned int
        public DOMAIN_PASSWORD_PROPERTIES PasswordProperties;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER MaxPasswordAge;

        /// LARGE_INTEGER->_LARGE_INTEGER
        public LARGE_INTEGER MinPasswordAge;

    }
}