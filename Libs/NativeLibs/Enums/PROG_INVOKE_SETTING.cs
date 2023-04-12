namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The PROG_INVOKE_SETTING enumeration indicates the initial setting of the function used to track the progress of a call
    /// to the TreeSetNamedSecurityInfo or TreeResetNamedSecurityInfo function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/accctrl/ne-accctrl-prog_invoke_setting
    /// </summary>
    public enum PROG_INVOKE_SETTING
    {
        ProgressInvokeNever,
        ProgressInvokeEveryObject,
        ProgressInvokeOnError,
        ProgressCancelOperation,
        ProgressRetryOperation,
        ProgressInvokePrePostError
    }
}