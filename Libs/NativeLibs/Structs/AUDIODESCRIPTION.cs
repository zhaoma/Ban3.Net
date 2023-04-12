using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information associated with audio descriptions.
    /// This structure is used with the SystemParametersInfo function when the SPI_GETAUDIODESCRIPTION or SPI_SETAUDIODESCRIPTION action value is specified.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-audiodescription
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AUDIODESCRIPTION
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this member to sizeof(AUDIODESCRIPTION).
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// If this member is TRUE, audio descriptions are enabled; Otherwise, this member is FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool Enabled;

        /// <summary>
        /// The locale identifier (LCID) of the language for the audio description.
        /// </summary>
        public uint Locale;
    }
}