namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TRUSTEE_FORM enumeration contains values that indicate the type of data pointed to by the ptstrName member of the TRUSTEE structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/accctrl/ne-accctrl-trustee_form
    /// </summary>
    public enum TRUSTEE_FORM
    {
        TRUSTEE_IS_SID,
        TRUSTEE_IS_NAME,
        TRUSTEE_BAD_FORM,
        TRUSTEE_IS_OBJECTS_AND_SID,
        TRUSTEE_IS_OBJECTS_AND_NAME
    }
}