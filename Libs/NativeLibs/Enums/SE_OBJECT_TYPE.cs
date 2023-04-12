namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The SE_OBJECT_TYPE enumeration contains values that correspond to the types of Windows objects that support security.
    /// The functions, such as GetSecurityInfo and SetSecurityInfo,
    /// that set and retrieve the security information of an object,
    /// use these values to indicate the type of object.
    /// https://learn.microsoft.com/en-us/windows/win32/api/accctrl/ne-accctrl-se_object_type
    /// </summary>
    public enum SE_OBJECT_TYPE
    {
        SE_UNKNOWN_OBJECT_TYPE,
        SE_FILE_OBJECT,
        SE_SERVICE,
        SE_PRINTER,
        SE_REGISTRY_KEY,
        SE_LMSHARE,
        SE_KERNEL_OBJECT,
        SE_WINDOW_OBJECT,
        SE_DS_OBJECT,
        SE_DS_OBJECT_ALL,
        SE_PROVIDER_DEFINED_OBJECT,
        SE_WMIGUID_OBJECT,
        SE_REGISTRY_WOW64_32KEY,
        SE_REGISTRY_WOW64_64KEY
    }
}