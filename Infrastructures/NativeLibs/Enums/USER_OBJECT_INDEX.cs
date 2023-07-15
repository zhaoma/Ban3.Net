namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum USER_OBJECT_INDEX:uint
    {
        /// <summary>
        /// The handle flags. The pvInfo parameter must point to a USEROBJECTFLAGS structure.
        /// </summary>
        UOI_FLAGS = 1,

        /// <summary>
        /// The name of the object, as a string.
        /// </summary>
        UOI_NAME = 2,

        /// <summary>
        /// The type name of the object, as a string.
        /// </summary>
        UOI_TYPE = 3,

        /// <summary>
        /// The SID structure that identifies the user that is currently associated with the specified object.
        /// If no user is associated with the object, the value returned in the buffer pointed to by lpnLengthNeeded is zero.
        /// Note that SID is a variable length structure.
        /// You will usually make a call to GetUserObjectInformation to determine the length of the SID before retrieving its value.
        /// </summary>
        UOI_USER_SID = 4,

        /// <summary>
        /// The size of the desktop heap, in KB, as a ULONG value.
        /// The hObj parameter must be a handle to a desktop object, otherwise, the function fails.
        /// Windows Server 2003 and Windows XP/2000:  This value is not supported.
        /// </summary>
        UOI_HEAPSIZE = 5,

        /// <summary>
        /// TRUE if the hObj parameter is a handle to the desktop object that is receiving input from the user. FALSE otherwise.
        /// Windows Server 2003 and Windows XP/2000:  This value is not supported.
        /// </summary>
        UOI_IO = 6,

        /// <summary>
        /// Sets the exception handling behavior when calling TimerProc. hObj must be the process handle returned by the GetCurrentProcess function.
        /// The pvInfo parameter must point to a BOOL. If TRUE, Windows will enclose its calls to TimerProc with an exception handler that consumes and discards all exceptions.
        /// This has been the default behavior since Windows 2000, although that may change in future versions of Windows.
        /// If pvInfo points to FALSE, Windows will not enclose its calls to TimerProc with an exception handler. A setting of FALSE is recommended.
        /// Otherwise, the application could behave unpredictably, and could be more vulnerable to security exploits.
        /// </summary>
        UOI_TIMERPROC_EXCEPTION_SUPPRESSION = 7
    }
}