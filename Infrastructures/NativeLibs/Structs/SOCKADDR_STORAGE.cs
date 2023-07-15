namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SOCKADDR_STORAGE structure stores socket address information.
    /// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms740504(v=vs.85)
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct SOCKADDR_STORAGE
    {

        /// short
        public short ss_family;
        
        public string @__ss_pad1;

        /// __int64
        public long @__ss_align;
        
        public string @__ss_pad2;
    }
}