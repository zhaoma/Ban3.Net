using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winuser.h
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-appendmenua
    /// </summary>
    public static partial class USER32
    {
        /*
         
        1515 (0x05eb),  (0x), AppendMenuA, 0x0008ca40, None
        1516 (0x05ec),  (0x), AppendMenuW, 0x0001fae0, None
        1555 (0x0613),  (0x), CharLowerA, 0x0002ce30, None
        1556 (0x0614),  (0x), CharLowerBuffA, 0x000871c0, None
        1557 (0x0615),  (0x), CharLowerBuffW, 0x000871e0, None
        1558 (0x0616),  (0x), CharLowerW, 0x00031ea0, None
        1559 (0x0617),  (0x), CharNextA, 0x0002b1c0, None
        1560 (0x0618),  (0x), CharNextExA, 0x00087200, None
        1561 (0x0619),  (0x), CharNextW, 0x0002bc60, None
        1562 (0x061a),  (0x), CharPrevA, 0x00001e20, None
        1563 (0x061b),  (0x), CharPrevExA, 0x00087220, None
        1564 (0x061c),  (0x), CharPrevW, 0x00087240, None
        1565 (0x061d),  (0x), CharToOemA, 0x000286e0, None
        1566 (0x061e),  (0x), CharToOemBuffA, 0x0007e2e0, None
        1567 (0x061f),  (0x), CharToOemBuffW, 0x0007e330, None
        1568 (0x0620),  (0x), CharToOemW, 0x0007e390, None
        1569 (0x0621),  (0x), CharUpperA, 0x000298e0, None
        1570 (0x0622),  (0x), CharUpperBuffA, 0x00087260, None
        1571 (0x0623),  (0x), CharUpperBuffW, 0x00001360, None
        1572 (0x0624),  (0x), CharUpperW, 0x00026ca0, None
        1576 (0x0628),  (0x), CheckMenuItem, 0x0001f810, None
        1577 (0x0629),  (0x), CheckMenuRadioItem, 0x00001910, None
        1587 (0x0633),  (0x), ClipCursor, 0x00033be0, None
        1596 (0x063c),  (0x), CopyAcceleratorTableA, 0x00051cf0, None
        1597 (0x063d),  (0x), CopyAcceleratorTableW, 0x00033c70, None
        1604 (0x0644),  (0x), CreateCaret, 0x0002bdb0, None
        1605 (0x0645),  (0x), CreateCursor, 0x00031950, None
        1616 (0x0650),  (0x), CreateIcon, 0x00051f30, None
        1617 (0x0651),  (0x), CreateIconFromResource, 0x00052000, None
        1618 (0x0652),  (0x), CreateIconFromResourceEx, 0x000259b0, None
        1619 (0x0653),  (0x), CreateIconIndirect, 0x000158b0, None
        1622 (0x0656),  (0x), CreateMenu, 0x00031fe0, None
        1623 (0x0657),  (0x), CreatePopupMenu, 0x0002c980, None
        1679 (0x068f),  (0x), DeleteMenu, 0x00033d00, None
        1681 (0x0691),  (0x), DestroyAcceleratorTable, 0x00027a40, None
        1682 (0x0692),  (0x), DestroyCaret, 0x0002c890, None
        1683 (0x0693),  (0x), DestroyCursor, 0x00029020, None
        1685 (0x0695),  (0x), DestroyIcon, 0x00029020, None
        1686 (0x0696),  (0x), DestroyMenu, 0x00033d50, None
        1721 (0x06b9),  (0x), DrawIcon, 0x00089670, None
        1722 (0x06ba),  (0x), DrawIconEx, 0x000263e0, None
        1723 (0x06bb),  (0x), DrawMenuBar, 0x00032570, None
        1740 (0x06cc),  (0x), EnableMenuItem, 0x0001f890, None
        1750 (0x06d6),  (0x), EndMenu, 0x00033f10, None
        1801 (0x0709),  (0x), GetCaretBlinkTime, 0x00033fc0, None
        1802 (0x070a),  (0x), GetCaretPos, 0x00033fd0, None
        1815 (0x0717),  (0x), GetClipCursor, 0x00033fe0, None
        1825 (0x0721),  (0x), GetCursor, 0x00034020, None
        1826 (0x0722),  (0x), GetCursorFrameInfo, 0x0002c630, None
        1827 (0x0723),  (0x), GetCursorInfo, 0x00034030, None
        1828 (0x0724),  (0x), GetCursorPos, 0x00027e30, None
        1857 (0x0741),  (0x), GetIconInfo, 0x00027060, None
        1858 (0x0742),  (0x), GetIconInfoExA, 0x000521d0, None
        1859 (0x0743),  (0x), GetIconInfoExW, 0x0002a010, None
        1882 (0x075a),  (0x), GetMenu, 0x0002a520, None
        1883 (0x075b),  (0x), GetMenuBarInfo, 0x00034190, None
        1884 (0x075c),  (0x), GetMenuCheckMarkDimensions, 0x000795c0, None
        1886 (0x075e),  (0x), GetMenuDefaultItem, 0x000291d0, None
        1887 (0x075f),  (0x), GetMenuInfo, 0x000016d0, None
        1888 (0x0760),  (0x), GetMenuItemCount, 0x000262c0, None
        1889 (0x0761),  (0x), GetMenuItemID, 0x0002a680, None
        1890 (0x0762),  (0x), GetMenuItemInfoA, 0x0008cc20, None
        1891 (0x0763),  (0x), GetMenuItemInfoW, 0x0001fcf0, None
        1892 (0x0764),  (0x), GetMenuItemRect, 0x000341a0, None
        1893 (0x0765),  (0x), GetMenuState, 0x0001f930, None
        1894 (0x0766),  (0x), GetMenuStringA, 0x0008cd20, None
        1895 (0x0767),  (0x), GetMenuStringW, 0x00030e60, None
        1908 (0x0774),  (0x), GetPhysicalCursorPos, 0x00027e30, None
        1955 (0x07a3),  (0x), GetSubMenu, 0x0002a1f0, None
        1959 (0x07a7),  (0x), GetSystemMenu, 0x00034350, None
        2018 (0x07e2),  (0x), HideCaret, 0x00028f60, None
        2019 (0x07e3),  (0x), HiliteMenuItem, 0x000344a0, None
        2047 (0x07ff),  (0x), InsertMenuA, 0x0008cf50, None
        2048 (0x0800),  (0x), InsertMenuItemA, 0x0008cfd0, None
        2049 (0x0801),  (0x), InsertMenuItemW, 0x0001fb40, None
        2050 (0x0802),  (0x), InsertMenuW, 0x0001fa60, None
        2057 (0x0809),  (0x), IsCharAlphaA, 0x000872e0, None
        2058 (0x080a),  (0x), IsCharAlphaNumericA, 0x00087300, None
        2059 (0x080b),  (0x), IsCharAlphaNumericW, 0x000325f0, None
        2060 (0x080c),  (0x), IsCharAlphaW, 0x00087320, None
        2061 (0x080d),  (0x), IsCharLowerA, 0x00087340, None
        2062 (0x080e),  (0x), IsCharLowerW, 0x00087360, None
        2063 (0x080f),  (0x), IsCharUpperA, 0x00087380, None
        2064 (0x0810),  (0x), IsCharUpperW, 0x000873a0, None
        2076 (0x081c),  (0x), IsMenu, 0x00027960, None
        2100 (0x0834),  (0x), LoadAcceleratorsA, 0x00052320, None
        2101 (0x0835),  (0x), LoadAcceleratorsW, 0x00027ae0, None
        2104 (0x0838),  (0x), LoadCursorA, 0x00029eb0, None
        2105 (0x0839),  (0x), LoadCursorFromFileA, 0x0004c390, None
        2106 (0x083a),  (0x), LoadCursorFromFileW, 0x0004c400, None
        2107 (0x083b),  (0x), LoadCursorW, 0x000145c0, None
        2108 (0x083c),  (0x), LoadIconA, 0x0002cb30, None
        2109 (0x083d),  (0x), LoadIconW, 0x00016eb0, None
        2110 (0x083e),  (0x), LoadImageA, 0x0002fd80, None
        2111 (0x083f),  (0x), LoadImageW, 0x00016b40, None
        2116 (0x0844),  (0x), LoadMenuA, 0x0004fe90, None
        2117 (0x0845),  (0x), LoadMenuIndirectA, 0x00021ee0, None
        2118 (0x0846),  (0x), LoadMenuIndirectW, 0x00021ee0, None
        2119 (0x0847),  (0x), LoadMenuW, 0x00021e20, None
        2121 (0x0849),  (0x), LoadStringA, 0x00052360, None
        2122 (0x084a),  (0x), LoadStringW, 0x00028120, None
        2129 (0x0851),  (0x), LookupIconIdFromDirectory, 0x000523f0, None
        2130 (0x0852),  (0x), LookupIconIdFromDirectoryEx, 0x00025aa0, None
        2148 (0x0864),  (0x), MenuItemFromPoint, 0x00034710, None
        2160 (0x0870),  (0x), ModifyMenuA, 0x0008d040, None
        2161 (0x0871),  (0x), ModifyMenuW, 0x00031de0, None
        2171 (0x087b),  (0x), OemToCharA, 0x0007e490, None
        2172 (0x087c),  (0x), OemToCharBuffA, 0x0007e4e0, None
        2173 (0x087d),  (0x), OemToCharBuffW, 0x0007e530, None
        2174 (0x087e),  (0x), OemToCharW, 0x0007e580, None
        2201 (0x0899),  (0x), PrivateExtractIconsA, 0x0006b210, None
        2202 (0x089a),  (0x), PrivateExtractIconsW, 0x0001ba30, None
        2275 (0x08e3),  (0x), RemoveMenu, 0x00034a60, None
        2303 (0x08ff),  (0x), SetCaretBlinkTime, 0x0002b0d0, None
        2304 (0x0900),  (0x), SetCaretPos, 0x0002b810, None
        2313 (0x0909),  (0x), SetCursor, 0x0002b280, None
        2315 (0x090b),  (0x), SetCursorPos, 0x00034bd0, None
        2341 (0x0925),  (0x), SetMenu, 0x0002c8d0, None
        2343 (0x0927),  (0x), SetMenuDefaultItem, 0x00034d20, None
        2344 (0x0928),  (0x), SetMenuInfo, 0x00001770, None
        2345 (0x0929),  (0x), SetMenuItemBitmaps, 0x00001ba0, None
        2346 (0x092a),  (0x), SetMenuItemInfoA, 0x0008d190, None
        2347 (0x092b),  (0x), SetMenuItemInfoW, 0x0001f9f0, None
        2352 (0x0930),  (0x), SetPhysicalCursorPos, 0x00034bd0, None
        2408 (0x0968),  (0x), ShowCaret, 0x00028f80, None
        2409 (0x0969),  (0x), ShowCursor, 0x00034e90, None
        2440 (0x0988),  (0x), TrackPopupMenu, 0x00079620, None
        2441 (0x0989),  (0x), TrackPopupMenuEx, 0x00034f50, None
        2443 (0x098b),  (0x), TranslateAcceleratorA, 0x0008a2e0, None
        2444 (0x098c),  (0x), TranslateAcceleratorW, 0x00025d80, None
         
         */
    }
}
