using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winuser.h Windows GDI parts
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-beginpaint
    /// </summary>
    public static partial class USER32
    {
        /*
         
        1521 (0x05f1),  (0x), BeginPaint, 0x00033b20, None
        1542 (0x0606),  (0x), ChangeDisplaySettingsA, 0x00085da0, None
        1543 (0x0607),  (0x), ChangeDisplaySettingsExA, 0x00031010, None
        1544 (0x0608),  (0x), ChangeDisplaySettingsExW, 0x00027190, None
        1545 (0x0609),  (0x), ChangeDisplaySettingsW, 0x0008c0b0, None
        1586 (0x0632),  (0x), ClientToScreen, 0x000117c0, None
        1600 (0x0640),  (0x), CopyRect, 0x00023c30, None
        1713 (0x06b1),  (0x), DrawAnimatedRects, 0x00033de0, None
        1714 (0x06b2),  (0x), DrawCaption, 0x0007dc80, None
        1717 (0x06b5),  (0x), DrawEdge, 0x00023000, None
        1718 (0x06b6),  (0x), DrawFocusRect, 0x00030400, None
        1720 (0x06b8),  (0x), DrawFrameControl, 0x000900a0, None
        1725 (0x06bd),  (0x), DrawStateA, 0x00079d20, None
        1726 (0x06be),  (0x), DrawStateW, 0x00028340, None
        1727 (0x06bf),  (0x), DrawTextA, 0x00058330, None
        1728 (0x06c0),  (0x), DrawTextExA, 0x000583b0, None
        1729 (0x06c1),  (0x), DrawTextExW, 0x0001e7d0, None
        1730 (0x06c2),  (0x), DrawTextW, 0x0001e720, None
        1751 (0x06d7),  (0x), EndPaint, 0x00033f20, None
        1759 (0x06df),  (0x), EnumDisplayDevicesA, 0x00008bc0, None
        1760 (0x06e0),  (0x), EnumDisplayDevicesW, 0x00027350, None
        1761 (0x06e1),  (0x), EnumDisplayMonitors, 0x00033f30, None
        1762 (0x06e2),  (0x), EnumDisplaySettingsA, 0x00008990, None
        1763 (0x06e3),  (0x), EnumDisplaySettingsExA, 0x000089b0, None
        1764 (0x06e4),  (0x), EnumDisplaySettingsExW, 0x00008850, None
        1765 (0x06e5),  (0x), EnumDisplaySettingsW, 0x00008830, None
        1774 (0x06ee),  (0x), EqualRect, 0x00023950, None
        1777 (0x06f1),  (0x), ExcludeUpdateRgn, 0x00033f40, None
        1779 (0x06f3),  (0x), FillRect, 0x000232d0, None
        1786 (0x06fa),  (0x), FrameRect, 0x000303d0, None
        1829 (0x0725),  (0x), GetDC, 0x00026290, None
        1830 (0x0726),  (0x), GetDCEx, 0x00034040, None
        1901 (0x076d),  (0x), GetMonitorInfoA, 0x0002dd40, None
        1902 (0x076e),  (0x), GetMonitorInfoW, 0x00020800, None
        1957 (0x07a5),  (0x), GetSysColorBrush, 0x00028150, None
        1962 (0x07aa),  (0x), GetTabbedTextExtentA, 0x00058580, None
        1963 (0x07ab),  (0x), GetTabbedTextExtentW, 0x00058680, None
        1973 (0x07b5),  (0x), GetUpdateRect, 0x0002b3d0, None
        1974 (0x07b6),  (0x), GetUpdateRgn, 0x000898d0, None
        2016 (0x07e0),  (0x), GrayStringA, 0x00089a80, None
        2017 (0x07e1),  (0x), GrayStringW, 0x00089ae0, None
        2030 (0x07ee),  (0x), InflateRect, 0x00004e70, None
        2053 (0x0805),  (0x), IntersectRect, 0x00013b10, None
        2054 (0x0806),  (0x), InvalidateRect, 0x000345b0, None
        2055 (0x0807),  (0x), InvalidateRgn, 0x000345c0, None
        2056 (0x0808),  (0x), InvertRect, 0x000261f0, None
        2081 (0x0821),  (0x), IsRectEmpty, 0x00023480, None
        2102 (0x0836),  (0x), LoadBitmapA, 0x00031e60, None
        2103 (0x0837),  (0x), LoadBitmapW, 0x0002bcb0, None
        2125 (0x084d),  (0x), LockWindowUpdate, 0x000346a0, None
        2147 (0x0863),  (0x), MapWindowPoints, 0x0000b9f0, None
        2162 (0x0872),  (0x), MonitorFromPoint, 0x00029620, None
        2163 (0x0873),  (0x), MonitorFromRect, 0x000136e0, None
        2164 (0x0874),  (0x), MonitorFromWindow, 0x00021140, None
        2175 (0x087f),  (0x), OffsetRect, 0x0000ae10, None
        2186 (0x088a),  (0x), PaintDesktop, 0x0007de20, None
        2204 (0x089c),  (0x), PtInRect, 0x000136b0, None
        2237 (0x08bd),  (0x), RedrawWindow, 0x00034980, None
        2271 (0x08df),  (0x), ReleaseDC, 0x00023ca0, None
        2283 (0x08eb),  (0x), ScreenToClient, 0x00011cf0, None
        2363 (0x093b),  (0x), SetRect, 0x00023a00, None
        2364 (0x093c),  (0x), SetRectEmpty, 0x000239e0, None
        2397 (0x095d),  (0x), SetWindowRgn, 0x000145f0, None
        2423 (0x0977),  (0x), SubtractRect, 0x0002a100, None
        2431 (0x097f),  (0x), TabbedTextOutA, 0x00058710, None
        2432 (0x0980),  (0x), TabbedTextOutW, 0x00058840, None
        2451 (0x0993),  (0x), UnionRect, 0x00023d30, None
        2471 (0x09a7),  (0x), UpdateWindow, 0x000131f0, None
        2482 (0x09b2),  (0x), ValidateRect, 0x00035000, None
        2483 (0x09b3),  (0x), ValidateRgn, 0x00001e00, None
        2497 (0x09c1),  (0x), WindowFromDC, 0x00035040, None
         
         */
    }
}
