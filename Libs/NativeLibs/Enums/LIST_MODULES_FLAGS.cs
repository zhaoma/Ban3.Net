namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum LIST_MODULES_FLAGS:uint
    {
        /// <summary>
        /// List the 32-bit modules. 
        /// </summary>
        LIST_MODULES_32BIT = 0x01,

        /// <summary>
        /// List the 64-bit modules. 
        /// </summary>
        LIST_MODULES_64BIT = 0x02,

        /// <summary>
        /// List all modules. 
        /// </summary>
        LIST_MODULES_ALL = 0x03,

        /// <summary>
        /// Use the default behavior. 
        /// </summary>
        LIST_MODULES_DEFAULT = 0x0
    }
}