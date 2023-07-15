namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The ACL_INFORMATION_CLASS enumeration contains values that specify the type of information being assigned to or retrieved from an access control list (ACL).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-acl_information_class
    /// </summary>
    public enum ACL_INFORMATION_CLASS
    {
        AclRevisionInformation = 1,
        AclSizeInformation
    }
}