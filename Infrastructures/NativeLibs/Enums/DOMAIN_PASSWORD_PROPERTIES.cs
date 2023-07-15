using System;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Flags that describe the password properties. 
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ns-ntsecapi-domain_password_information
    /// </summary>
    [Flags]
    public enum DOMAIN_PASSWORD_PROPERTIES : long
    {
        /// <summary>
        /// The password must have a mix of at least two of the following types of characters:
        /// Uppercase characters
        /// Lowercase characters
        /// Numerals
        /// </summary>
        DOMAIN_PASSWORD_COMPLEX = 0x00000001L,

        /// <summary>
        /// The password cannot be changed without logging on.
        /// Otherwise, if your password has expired, you can change your password and then log on.
        /// </summary>
        DOMAIN_PASSWORD_NO_ANON_CHANGE = 0x00000002L,

        /// <summary>
        /// Forces the client to use a protocol that does not allow the domain controller to get the plaintext password.
        /// </summary>
        DOMAIN_PASSWORD_NO_CLEAR_CHANGE = 0x00000004L,

        /// <summary>
        /// Allows the built-in administrator account to be locked out from network logons.
        /// </summary>
        DOMAIN_LOCKOUT_ADMINS = 0x00000008L,

        /// <summary>
        /// The directory service is storing a plaintext password for all users instead of a hash function of the password.
        /// </summary>
        DOMAIN_PASSWORD_STORE_CLEARTEXT = 0x00000010L,

        /// <summary>
        /// Removes the requirement that the machine account password be automatically changed every week.
        /// This value should not be used as it can weaken security.
        /// </summary>
        DOMAIN_REFUSE_PASSWORD_CHANGE = 0x00000020L
    }
}