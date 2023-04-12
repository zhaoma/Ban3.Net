namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// bit flags that specifies properties of the object handle.
    /// </summary>
    public enum OBJECT_HANDLE_FLAGS : uint
    {
        Zero=0,

        /// <summary>
        /// If this flag is set, a child process created with the bInheritHandles parameter of CreateProcess set to TRUE will inherit the object handle. 
        /// </summary>
        HANDLE_FLAG_INHERIT = 0x00000001,

        /// <summary>
        /// If this flag is set, calling the CloseHandle function will not close the object handle. 
        /// </summary>
        HANDLE_FLAG_PROTECT_FROM_CLOSE = 0x00000002
    }
}