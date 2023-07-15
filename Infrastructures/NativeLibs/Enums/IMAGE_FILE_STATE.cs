namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The state of the image file
    /// </summary>
    public enum IMAGE_FILE_STATE:ushort
    {
        /// <summary>
        /// The file is an executable image.
        /// This value is defined as IMAGE_NT_OPTIONAL_HDR32_MAGIC in a 32-bit application and as IMAGE_NT_OPTIONAL_HDR64_MAGIC in a 64-bit application. 
        /// </summary>
        IMAGE_NT_OPTIONAL_HDR_MAGIC,

        /// <summary>
        /// The file is an executable image.
        /// </summary>
        IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b,

        /// <summary>
        /// The file is an executable image. 
        /// </summary>
        IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b,

        /// <summary>
        /// The file is a ROM image. 
        /// </summary>
        IMAGE_ROM_OPTIONAL_HDR_MAGIC = 0x107
    }
}