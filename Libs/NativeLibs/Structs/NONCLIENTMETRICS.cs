using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NONCLIENTMETRICSA
    {
        /// UINT->unsigned int
        public uint cbSize;

        /// int
        public int iBorderWidth;

        /// int
        public int iScrollWidth;

        /// int
        public int iScrollHeight;

        /// int
        public int iCaptionWidth;

        /// int
        public int iCaptionHeight;

        /// LOGFONTA->tagLOGFONTA
        public LOGFONTA lfCaptionFont;

        /// int
        public int iSmCaptionWidth;

        /// int
        public int iSmCaptionHeight;

        /// LOGFONTA->tagLOGFONTA
        public LOGFONTA lfSmCaptionFont;

        /// int
        public int iMenuWidth;

        /// int
        public int iMenuHeight;

        /// LOGFONTA->tagLOGFONTA
        public LOGFONTA lfMenuFont;

        /// LOGFONTA->tagLOGFONTA
        public LOGFONTA lfStatusFont;

        /// LOGFONTA->tagLOGFONTA
        public LOGFONTA lfMessageFont;

        /// int
        public int iPaddedBorderWidth;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct tagNONCLIENTMETRICSW
    {

        /// UINT->unsigned int
        public uint cbSize;

        /// int
        public int iBorderWidth;

        /// int
        public int iScrollWidth;

        /// int
        public int iScrollHeight;

        /// int
        public int iCaptionWidth;

        /// int
        public int iCaptionHeight;

        /// LOGFONTW->tagLOGFONTW
        public LOGFONTW lfCaptionFont;

        /// int
        public int iSmCaptionWidth;

        /// int
        public int iSmCaptionHeight;

        /// LOGFONTW->tagLOGFONTW
        public LOGFONTW lfSmCaptionFont;

        /// int
        public int iMenuWidth;

        /// int
        public int iMenuHeight;

        /// LOGFONTW->tagLOGFONTW
        public LOGFONTW lfMenuFont;

        /// LOGFONTW->tagLOGFONTW
        public LOGFONTW lfStatusFont;

        /// LOGFONTW->tagLOGFONTW
        public LOGFONTW lfMessageFont;

        /// int
        public int iPaddedBorderWidth;
    }
}