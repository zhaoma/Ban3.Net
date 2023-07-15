using Ban3.Infrastructures.NativeLibs.Interfaces.Modules;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Extensions
{
    public static partial class Helper
    {

        public static bool Open(this IClipboard _,IntPtr hWndNewOwner)
        {
            return Documented.USER32.OpenClipboard(hWndNewOwner);
        }

        public static bool Open(this IClipboard _)
        {
            return _.Open(IntPtr.Zero);
        }

        public static bool Close(this IClipboard _) { 
            return Documented.USER32.CloseClipboard(); 
        }

        public static bool Empty(this IClipboard _)
        {
            return Documented.USER32.EmptyClipboard();
        }

        public static uint RegisterFormat(IClipboard _,string lpszFormat)
        {
            return Documented.USER32.RegisterClipboardFormatW(new StringBuilder(lpszFormat));
        }

        public static IntPtr Get(this IClipboard _,uint format)
        {
            return Documented.USER32.GetClipboardData(format);
        }

        public static IntPtr Set(this IClipboard _,uint format,IntPtr hMem)
        {
            return Documented.USER32.SetClipboardData(format,hMem);
        }

        public static string GetString(this IClipboard _)
        {
            var ip = _.Get((uint)Enums.STANDARD_CLIPBOARD_FORMATS.CF_TEXT);
            return Marshal.PtrToStringAnsi(ip);
        }

        public static bool SetString(this IClipboard _, string value)
        {
            var ip = _.Set((uint)Enums.STANDARD_CLIPBOARD_FORMATS.CF_TEXT, Marshal.StringToHGlobalAnsi(value));
            return ip != null && ip != IntPtr.Zero;
        }
    }
}
