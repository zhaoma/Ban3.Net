namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies whether Protected Process Light (PPL) is enabled.
    /// https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_protection_level_information
    /// </summary>
    public enum PROTECTION_LEVEL
    {
        /// <summary>
        /// For internal use only.
        /// </summary>
        PROTECTION_LEVEL_WINTCB_LIGHT,
        
        /// <summary>
        /// For internal use only.
        /// </summary>
        PROTECTION_LEVEL_WINDOWS,

        /// <summary>
        /// For internal use only.
        /// </summary>
        PROTECTION_LEVEL_WINDOWS_LIGHT,
        
        /// <summary>
        /// For internal use only.
        /// </summary>
        PROTECTION_LEVEL_ANTIMALWARE_LIGHT,

        /// <summary>
        /// For internal use only.
        /// </summary>
        PROTECTION_LEVEL_LSA_LIGHT,

        /// <summary>
        /// Not implemented.
        /// </summary>
        PROTECTION_LEVEL_WINTCB,

        /// <summary>
        /// Not implemented.
        /// </summary>
        PROTECTION_LEVEL_CODEGEN_LIGHT,

        /// <summary>
        /// Not implemented.
        /// </summary>
        PROTECTION_LEVEL_AUTHENTICODE,

        /// <summary>
        /// The process is a third party app that is using process protection.
        /// </summary>
        PROTECTION_LEVEL_PPL_APP,

        /// <summary>
        /// The process is not protected. 
        /// </summary>
        PROTECTION_LEVEL_NONE
    }
}