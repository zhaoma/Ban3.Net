namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum DLL_CHARACTERISTICS:uint
    {
        Reserved0x0001= 0x0001,
        Reserved0x0002 = 0x0002,
        Reserved0x0004 = 0x0004,
        Reserved0x0008 = 0x0008,

        /// <summary>
        /// The DLL can be relocated at load time. 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x0040,

        /// <summary>
        /// Code integrity checks are forced.
        /// If you set this flag and a section contains only uninitialized data,
        /// set the PointerToRawData member of IMAGE_SECTION_HEADER for that section to zero;
        /// otherwise,the image will fail to load because the digital signature cannot be verified. 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x0080,

        /// <summary>
        /// The image is compatible with data execution prevention (DEP). 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x0100,

        /// <summary>
        /// The image is isolation aware, but should not be isolated. 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200,

        /// <summary>
        /// The image does not use structured exception handling (SEH).
        /// No handlers can be called in this image. 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400,

        /// <summary>
        /// Do not bind the image. 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800,

        /// <summary>
        /// A WDM driver. 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,

        Reserved0x4000=0x4000,

        /// <summary>
        /// The image is terminal server aware. 
        /// </summary>
        IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000
    }
}