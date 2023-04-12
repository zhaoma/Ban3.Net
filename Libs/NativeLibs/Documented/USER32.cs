using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using static Ban3.Infrastructures.NativeLibs.Documented.USER32;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    public static partial class USER32
    {
        const string Dll = "user32.dll";

        /*
         
        1502 (0x05de),  (0x), Ordinal_1502, 0x00052a00, None
        1503 (0x05df),  (0x), GetPointerFrameArrivalTimes, 0x00050750, None
        *   1504 (0x05e0),  (0x), ActivateKeyboardLayout, 0x0002c7c0, None
        *   1505 (0x05e1),  (0x), AddClipboardFormatListener, 0x0002cfa0, None
        1506 (0x05e2),  (0x), AddVisualIdentifier, 0x00033af0, None
        *   1507 (0x05e3),  (0x), AdjustWindowRect, 0x000891c0, None
        *   1508 (0x05e4),  (0x), AdjustWindowRectEx, 0x000165d0, None
        *   1509 (0x05e5),  (0x), AdjustWindowRectExForDpi, 0x00010350, None
        1510 (0x05e6),  (0x), AlignRects, 0x0008f140, None
        1511 (0x05e7),  (0x), AllowForegroundActivation, 0x00089230, None
        *   1512 (0x05e8),  (0x), AllowSetForegroundWindow, 0x0002b830, None
        *   1513 (0x05e9),  (0x), AnimateWindow, 0x00083ba0, None
        *   1514 (0x05ea),  (0x), AnyPopup, 0x00084940, None
        *   1515 (0x05eb),  (0x), AppendMenuA, 0x0008ca40, None
        *   1516 (0x05ec),  (0x), AppendMenuW, 0x0001fae0, None
        *   1517 (0x05ed),  (0x), AreDpiAwarenessContextsEqual, 0x00029400, None
        *   1518 (0x05ee),  (0x), ArrangeIconicWindows, 0x00089250, None
        1519 (0x05ef),  (0x), AttachThreadInput, 0x00033b00, None
        *   1520 (0x05f0),  (0x), BeginDeferWindowPos, 0x00029f40, None
        *   1521 (0x05f1),  (0x), BeginPaint, 0x00033b20, None
        *   1522 (0x05f2),  (0x), BlockInput, 0x00033b30, None
        *   1523 (0x05f3),  (0x), BringWindowToTop, 0x00031370, None
        *   1524 (0x05f4),  (0x), BroadcastSystemMessage, 0x0008caa0, None
        *   1525 (0x05f5),  (0x), BroadcastSystemMessageA, 0x0008caa0, None
        *   1526 (0x05f6),  (0x), BroadcastSystemMessageExA, 0x0008cad0, None
        *   1527 (0x05f7),  (0x), BroadcastSystemMessageExW, 0x0008a7e0, None
        *   1528 (0x05f8),  (0x), BroadcastSystemMessageW, 0x0002aeb0, None
        1529 (0x05f9),  (0x), BuildReasonArray, 0x00032860, None
        1530 (0x05fa),  (0x), CalcMenuBar, 0x00033b50, None
        *   1531 (0x05fb),  (0x), CalculatePopupWindowPosition, 0x00033b60, None
        1532 (0x05fc),  (0x), CallMsgFilter, 0x00085c80, None
        *   1533 (0x05fd),  (0x), CallMsgFilterA, 0x00085c80, None
        *   1534 (0x05fe),  (0x), CallMsgFilterW, 0x0008bff0, None
        *   1535 (0x05ff),  (0x), CallNextHookEx, 0x00001fa0, None
        *   1536 (0x0600),  (0x), CallWindowProcA, 0x000505e0, None
        *   1537 (0x0601),  (0x), CallWindowProcW, 0x0000e3f0, None
        1538 (0x0602),  (0x), CancelShutdown, 0x00057c60, None
        1539 (0x0603),  (0x), CascadeChildWindows, 0x00089270, None
        *   1540 (0x0604),  (0x), CascadeWindows, 0x000790c0, None
        *   1541 (0x0605),  (0x), ChangeClipboardChain, 0x000871a0, None
        *   1542 (0x0606),  (0x), ChangeDisplaySettingsA, 0x00085da0, None
        *   1543 (0x0607),  (0x), ChangeDisplaySettingsExA, 0x00031010, None
        *   1544 (0x0608),  (0x), ChangeDisplaySettingsExW, 0x00027190, None
        *   1545 (0x0609),  (0x), ChangeDisplaySettingsW, 0x0008c0b0, None
        1546 (0x060a),  (0x), ChangeMenuA, 0x000793b0, None
        1547 (0x060b),  (0x), ChangeMenuW, 0x00079460, None
        *   1548 (0x060c),  (0x), ChangeWindowMessageFilter, 0x0002b2a0, None
        *   1549 (0x060d),  (0x), ChangeWindowMessageFilterEx, 0x00033b80, None
        1550 (0x060e),  (0x), Ordinal_1550, 0x0007f620, None
        1551 (0x060f),  (0x), Ordinal_1551, 0x0007f6b0, None
        1552 (0x0610),  (0x), Ordinal_1552, 0x0007f5d0, None
        1553 (0x0611),  (0x), DwmGetDxRgn, 0x0002d020, None
        1554 (0x0612),  (0x), Ordinal_1554, 0x0002d020, None
        *   1555 (0x0613),  (0x), CharLowerA, 0x0002ce30, None
        *   1556 (0x0614),  (0x), CharLowerBuffA, 0x000871c0, None
        *   1557 (0x0615),  (0x), CharLowerBuffW, 0x000871e0, None
        *   1558 (0x0616),  (0x), CharLowerW, 0x00031ea0, None
        *   1559 (0x0617),  (0x), CharNextA, 0x0002b1c0, None
        *   1560 (0x0618),  (0x), CharNextExA, 0x00087200, None
        *   1561 (0x0619),  (0x), CharNextW, 0x0002bc60, None
        *   1562 (0x061a),  (0x), CharPrevA, 0x00001e20, None
        *   1563 (0x061b),  (0x), CharPrevExA, 0x00087220, None
        *   1564 (0x061c),  (0x), CharPrevW, 0x00087240, None
        *   1565 (0x061d),  (0x), CharToOemA, 0x000286e0, None
        *   1566 (0x061e),  (0x), CharToOemBuffA, 0x0007e2e0, None
        *   1567 (0x061f),  (0x), CharToOemBuffW, 0x0007e330, None
        *   1568 (0x0620),  (0x), CharToOemW, 0x0007e390, None
        *   1569 (0x0621),  (0x), CharUpperA, 0x000298e0, None
        *   1570 (0x0622),  (0x), CharUpperBuffA, 0x00087260, None
        *   1571 (0x0623),  (0x), CharUpperBuffW, 0x00001360, None
        *   1572 (0x0624),  (0x), CharUpperW, 0x00026ca0, None
        1573 (0x0625),  (0x), CheckBannedOneCoreTransformApi, 0x0002d010, None
        1574 (0x0626),  (0x), CheckDBCSEnabledExt, 0x00021d20, None
        *   1575 (0x0627),  (0x), CheckDlgButton, 0x00001b60, None
        *   1576 (0x0628),  (0x), CheckMenuItem, 0x0001f810, None
        *   1577 (0x0629),  (0x), CheckMenuRadioItem, 0x00001910, None
        1578 (0x062a),  (0x), CheckProcessForClipboardAccess, 0x00033b90, None
        1579 (0x062b),  (0x), CheckProcessSession, 0x00033ba0, None
        *   1580 (0x062c),  (0x), CheckRadioButton, 0x00001380, None
        1581 (0x062d),  (0x), CheckWindowThreadDesktop, 0x00033bb0, None
        *   1582 (0x062e),  (0x), ChildWindowFromPoint, 0x000892a0, None
        *   1583 (0x062f),  (0x), ChildWindowFromPointEx, 0x00033bc0, None
        1584 (0x0630),  (0x), CliImmSetHotKey, 0x0004c2b0, None
        1585 (0x0631),  (0x), ClientThreadSetup, 0x0001d4d0, None
        *   1586 (0x0632),  (0x), ClientToScreen, 0x000117c0, None
        *   1587 (0x0633),  (0x), ClipCursor, 0x00033be0, None
        *   1588 (0x0634),  (0x), CloseClipboard, 0x0002c9c0, None
        *   1589 (0x0635),  (0x), CloseDesktop, 0x00033bf0, None
        1590 (0x0636),  (0x), CloseGestureInfoHandle, 0x0004f790, None
        1591 (0x0637),  (0x), CloseTouchInputHandle, 0x00052930, None
        *   1592 (0x0638),  (0x), CloseWindow, 0x00089350, None
        *   1593 (0x0639),  (0x), CloseWindowStation, 0x00033c00, None
        1594 (0x063a),  (0x), ConsoleControl, 0x000274b0, None
        1595 (0x063b),  (0x), ControlMagnification, 0x00033c60, None
        *   1596 (0x063c),  (0x), CopyAcceleratorTableA, 0x00051cf0, None
        *   1597 (0x063d),  (0x), CopyAcceleratorTableW, 0x00033c70, None
        1598 (0x063e),  (0x), CopyIcon, 0x00027000, None
        1599 (0x063f),  (0x), CopyImage, 0x00015160, None
        *   1600 (0x0640),  (0x), CopyRect, 0x00023c30, None
        *   1601 (0x0641),  (0x), CountClipboardFormats, 0x0002bb80, None
        1602 (0x0642),  (0x), CreateAcceleratorTableA, 0x00051d80, None
        1603 (0x0643),  (0x), CreateAcceleratorTableW, 0x00033c80, None
        *   1604 (0x0644),  (0x), CreateCaret, 0x0002bdb0, None
        *   1605 (0x0645),  (0x), CreateCursor, 0x00031950, None
        1606 (0x0646),  (0x), CreateDCompositionHwndTarget, 0x00033cb0, None
        *   1607 (0x0647),  (0x), CreateDesktopA, 0x00089390, None
        *   1608 (0x0648),  (0x), CreateDesktopExA, 0x000893d0, None
        *   1609 (0x0649),  (0x), CreateDesktopExW, 0x0002c270, None
        *   1610 (0x064a),  (0x), CreateDesktopW, 0x0002c230, None
        *   1611 (0x064b),  (0x), CreateDialogIndirectParamA, 0x00051e10, None
        1612 (0x064c),  (0x), CreateDialogIndirectParamAorW, 0x00003b20, None
        *   1613 (0x064d),  (0x), CreateDialogIndirectParamW, 0x00002930, None
        *   1614 (0x064e),  (0x), CreateDialogParamA, 0x00051e40, None
        *   1615 (0x064f),  (0x), CreateDialogParamW, 0x00003610, None
        *   1616 (0x0650),  (0x), CreateIcon, 0x00051f30, None
        *   1617 (0x0651),  (0x), CreateIconFromResource, 0x00052000, None
        *   1618 (0x0652),  (0x), CreateIconFromResourceEx, 0x000259b0, None
        *   1619 (0x0653),  (0x), CreateIconIndirect, 0x000158b0, None
        *   1620 (0x0654),  (0x), CreateMDIWindowA, 0x000790f0, None
        *   1621 (0x0655),  (0x), CreateMDIWindowW, 0x00079170, None
        *   1622 (0x0656),  (0x), CreateMenu, 0x00031fe0, None
        *   1623 (0x0657),  (0x), CreatePopupMenu, 0x0002c980, None
        *   1624 (0x0658),  (0x), CreateSyntheticPointerDevice, 0x0007f6e0, None
        1625 (0x0659),  (0x), CreateSystemThreads, 0x0008a8b0, None
        *   1626 (0x065a),  (0x), CreateWindowExA, 0x00003c10, None
        *   1627 (0x065b),  (0x), CreateWindowExW, 0x000076b0, None
        1628 (0x065c),  (0x), CreateWindowInBand, 0x00005f50, None
        1629 (0x065d),  (0x), CreateWindowInBandEx, 0x00005ff0, None
        1630 (0x065e),  (0x), CreateWindowIndirect, 0x00084990, None
        *   1631 (0x065f),  (0x), CreateWindowStationA, 0x00089590, None
        *   1632 (0x0660),  (0x), CreateWindowStationW, 0x0001dad0, None
        1633 (0x0661),  (0x), CsrBroadcastSystemMessageExW, 0x0002add0, None
        1634 (0x0662),  (0x), CtxInitUser32, 0x0001d340, None
        *   1635 (0x0663),  (0x), DdeAbandonTransaction, 0x00084f10, None
        *   1636 (0x0664),  (0x), DdeAccessData, 0x0006bfa0, None
        *   1637 (0x0665),  (0x), DdeAddData, 0x0006c060, None
        *   1638 (0x0666),  (0x), DdeClientTransaction, 0x00084ff0, None
        *   1639 (0x0667),  (0x), DdeCmpStringHandles, 0x0006cbf0, None
        *   1640 (0x0668),  (0x), DdeConnect, 0x000571b0, None
        *   1641 (0x0669),  (0x), DdeConnectList, 0x000572c0, None
        *   1642 (0x066a),  (0x), DdeCreateDataHandle, 0x0006c200, None
        *   1643 (0x066b),  (0x), DdeCreateStringHandleA, 0x0006cc10, None
        *   1644 (0x066c),  (0x), DdeCreateStringHandleW, 0x0002ac40, None
        *   1645 (0x066d),  (0x), DdeDisconnect, 0x000575b0, None
        *   1646 (0x066e),  (0x), DdeDisconnectList, 0x00057660, None
        *   1647 (0x066f),  (0x), DdeEnableCallback, 0x0004e100, None
        *   1648 (0x0670),  (0x), DdeFreeDataHandle, 0x0006c360, None
        *   1649 (0x0671),  (0x), DdeFreeStringHandle, 0x0006cc30, None
        *   1650 (0x0672),  (0x), DdeGetData, 0x0006c3e0, None
        *   1651 (0x0673),  (0x), DdeGetLastError, 0x00058d70, None
        *   1652 (0x0674),  (0x), DdeGetQualityOfService, 0x0002d040, None
        *   1653 (0x0675),  (0x), DdeImpersonateClient, 0x00058dd0, None
        *   1654 (0x0676),  (0x), DdeInitializeA, 0x00058e70, None
        *   1655 (0x0677),  (0x), DdeInitializeW, 0x0001cfe0, None
        *   1656 (0x0678),  (0x), DdeKeepStringHandle, 0x0006cd10, None
        *   1657 (0x0679),  (0x), DdeNameService, 0x0002a900, None
        *   1658 (0x067a),  (0x), DdePostAdvise, 0x00085680, None
        *   1659 (0x067b),  (0x), DdeQueryConvInfo, 0x00085950, None
        *   1660 (0x067c),  (0x), DdeQueryNextServer, 0x00057780, None
        *   1661 (0x067d),  (0x), DdeQueryStringA, 0x0006cde0, None
        *   1662 (0x067e),  (0x), DdeQueryStringW, 0x0006ce00, None
        *   1663 (0x067f),  (0x), DdeReconnect, 0x000578e0, None
        *   1664 (0x0680),  (0x), DdeSetQualityOfService, 0x0002d040, None
        *   1665 (0x0681),  (0x), DdeSetUserHandle, 0x00085b80, None
        *   1666 (0x0682),  (0x), DdeUnaccessData, 0x0006c550, None
        *   1667 (0x0683),  (0x), DdeUninitialize, 0x00058e90, None
        *   1668 (0x0684),  (0x), DefDlgProcA, NTDLL.NtdllDialogWndProc_A, None
        *   1669 (0x0685),  (0x), DefDlgProcW, NTDLL.NtdllDialogWndProc_W, None
        *   1670 (0x0686),  (0x), DefFrameProcA, 0x000791f0, None
        *   1671 (0x0687),  (0x), DefFrameProcW, 0x0002fc30, None
        *   1672 (0x0688),  (0x), DefMDIChildProcA, 0x00079220, None
        *   1673 (0x0689),  (0x), DefMDIChildProcW, 0x0002e180, None
        *   1674 (0x068a),  (0x), DefRawInputProc, 0x0008a810, None
        *   1675 (0x068b),  (0x), DefWindowProcA, NTDLL.NtdllDefWindowProc_A, None
        *   1676 (0x068c),  (0x), DefWindowProcW, NTDLL.NtdllDefWindowProc_W, None
        *   1677 (0x068d),  (0x), DeferWindowPos, 0x00027e50, None
        1678 (0x068e),  (0x), DeferWindowPosAndBand, 0x00089610, None
        *   1679 (0x068f),  (0x), DeleteMenu, 0x00033d00, None
        *   1680 (0x0690),  (0x), DeregisterShellHookWindow, 0x0002cdf0, None
        *   1681 (0x0691),  (0x), DestroyAcceleratorTable, 0x00027a40, None
        *   1682 (0x0692),  (0x), DestroyCaret, 0x0002c890, None
        *   1683 (0x0693),  (0x), DestroyCursor, 0x00029020, None
        1684 (0x0694),  (0x), DestroyDCompositionHwndTarget, 0x00033d40, None
        *   1685 (0x0695),  (0x), DestroyIcon, 0x00029020, None
        *   1686 (0x0696),  (0x), DestroyMenu, 0x00033d50, None
        1687 (0x0697),  (0x), DestroyReasons, 0x000327d0, None
        *   1688 (0x0698),  (0x), DestroySyntheticPointerDevice, 0x00033d60, None
        *   1689 (0x0699),  (0x), DestroyWindow, 0x00033d70, None
        *   1690 (0x069a),  (0x), DialogBoxIndirectParamA, 0x00052030, None
        1691 (0x069b),  (0x), DialogBoxIndirectParamAorW, 0x0002d400, None
        *   1692 (0x069c),  (0x), DialogBoxIndirectParamW, 0x0002d3d0, None
        *   1693 (0x069d),  (0x), DialogBoxParamA, 0x00052060, None
        *   1694 (0x069e),  (0x), DialogBoxParamW, 0x0002d340, None
        1695 (0x069f),  (0x), DisableProcessWindowsGhosting, 0x0002cca0, None
        *   1696 (0x06a0),  (0x), DispatchMessageA, 0x0002b730, None
        *   1697 (0x06a1),  (0x), DispatchMessageW, 0x0000dfd0, None
        *   1698 (0x06a2),  (0x), DisplayConfigGetDeviceInfo, 0x00029920, None
        *   1699 (0x06a3),  (0x), DisplayConfigSetDeviceInfo, 0x0008e7d0, None
        1700 (0x06a4),  (0x), DisplayExitWindowsWarnings, 0x00057cc0, None
        *   1701 (0x06a5),  (0x), DlgDirListA, 0x000769d0, None
        *   1702 (0x06a6),  (0x), DlgDirListComboBoxA, 0x00055690, None
        *   1703 (0x06a7),  (0x), DlgDirListComboBoxW, 0x00055780, None
        *   1704 (0x06a8),  (0x), DlgDirListW, 0x00076ad0, None
        *   1705 (0x06a9),  (0x), DlgDirSelectComboBoxExA, 0x000557e0, None
        *   1706 (0x06aa),  (0x), DlgDirSelectComboBoxExW, 0x00055890, None
        *   1707 (0x06ab),  (0x), DlgDirSelectExA, 0x00076b30, None
        *   1708 (0x06ac),  (0x), DlgDirSelectExW, 0x00076bf0, None
        1709 (0x06ad),  (0x), DoSoundConnect, 0x00033d90, None
        1710 (0x06ae),  (0x), DoSoundDisconnect, 0x00033da0, None
        1711 (0x06af),  (0x), DragDetect, 0x00033dc0, None
        1712 (0x06b0),  (0x), DragObject, 0x00033dd0, None
        *   1713 (0x06b1),  (0x), DrawAnimatedRects, 0x00033de0, None
        *   1714 (0x06b2),  (0x), DrawCaption, 0x0007dc80, None
        1715 (0x06b3),  (0x), DrawCaptionTempA, 0x00085dd0, None
        1716 (0x06b4),  (0x), DrawCaptionTempW, 0x0008c0e0, None
        *   1717 (0x06b5),  (0x), DrawEdge, 0x00023000, None
        *   1718 (0x06b6),  (0x), DrawFocusRect, 0x00030400, None
        1719 (0x06b7),  (0x), DrawFrame, 0x0008ff60, None
        *   1720 (0x06b8),  (0x), DrawFrameControl, 0x000900a0, None
        *   1721 (0x06b9),  (0x), DrawIcon, 0x00089670, None
        *   1722 (0x06ba),  (0x), DrawIconEx, 0x000263e0, None
        *   1723 (0x06bb),  (0x), DrawMenuBar, 0x00032570, None
        1724 (0x06bc),  (0x), DrawMenuBarTemp, 0x00079510, None
        *   1725 (0x06bd),  (0x), DrawStateA, 0x00079d20, None
        *   1726 (0x06be),  (0x), DrawStateW, 0x00028340, None
        *   1727 (0x06bf),  (0x), DrawTextA, 0x00058330, None
        *   1728 (0x06c0),  (0x), DrawTextExA, 0x000583b0, None
        *   1729 (0x06c1),  (0x), DrawTextExW, 0x0001e7d0, None
        *   1730 (0x06c2),  (0x), DrawTextW, 0x0001e720, None
        1731 (0x06c3),  (0x), DwmGetDxSharedSurface, 0x0002dc30, None
        1732 (0x06c4),  (0x), DwmGetRemoteSessionOcclusionEvent, 0x00033df0, None
        1733 (0x06c5),  (0x), DwmGetRemoteSessionOcclusionState, 0x00033e00, None
        1734 (0x06c6),  (0x), DwmKernelShutdown, 0x00033e10, None
        1735 (0x06c7),  (0x), DwmKernelStartup, 0x00033e20, None
        1736 (0x06c8),  (0x), DwmLockScreenUpdates, 0x0002ce10, None
        1737 (0x06c9),  (0x), DwmValidateWindow, 0x00033e30, None
        1738 (0x06ca),  (0x), EditWndProc, 0x00061b20, None
        *   1739 (0x06cb),  (0x), EmptyClipboard, 0x00032610, None
        *   1740 (0x06cc),  (0x), EnableMenuItem, 0x0001f890, None
        *   1741 (0x06cd),  (0x), EnableMouseInPointer, 0x00033e50, None
        *   1742 (0x06ce),  (0x), EnableNonClientDpiScaling, 0x00033e80, None
        1743 (0x06cf),  (0x), EnableOneCoreTransformMode, 0x00033e90, None
        *   1744 (0x06d0),  (0x), EnableScrollBar, 0x00013250, None
        1745 (0x06d1),  (0x), EnableSessionForMMCSS, 0x00032170, None
        *   1746 (0x06d2),  (0x), EnableWindow, 0x0002b370, None
        *   1747 (0x06d3),  (0x), EndDeferWindowPos, 0x0002a600, None
        1748 (0x06d4),  (0x), EndDeferWindowPosEx, 0x00033f00, None
        *   1749 (0x06d5),  (0x), EndDialog, 0x00031c60, None
        *   1750 (0x06d6),  (0x), EndMenu, 0x00033f10, None
        *   1751 (0x06d7),  (0x), EndPaint, 0x00033f20, None
        *   1752 (0x06d8),  (0x), EndTask, 0x00057f80, None
        1753 (0x06d9),  (0x), EnterReaderModeHelper, 0x0007f150, None
        *   1754 (0x06da),  (0x), EnumChildWindows, 0x0000ecc0, None
        *   1755 (0x06db),  (0x), EnumClipboardFormats, 0x000320c0, None
        *   1756 (0x06dc),  (0x), EnumDesktopWindows, 0x00021840, None
        *   1757 (0x06dd),  (0x), EnumDesktopsA, 0x00003430, None
        *   1758 (0x06de),  (0x), EnumDesktopsW, 0x00004f60, None
        *   1759 (0x06df),  (0x), EnumDisplayDevicesA, 0x00008bc0, None
        *   1760 (0x06e0),  (0x), EnumDisplayDevicesW, 0x00027350, None
        *   1761 (0x06e1),  (0x), EnumDisplayMonitors, 0x00033f30, None
        *   1762 (0x06e2),  (0x), EnumDisplaySettingsA, 0x00008990, None
        *   1763 (0x06e3),  (0x), EnumDisplaySettingsExA, 0x000089b0, None
        *   1764 (0x06e4),  (0x), EnumDisplaySettingsExW, 0x00008850, None
        *   1765 (0x06e5),  (0x), EnumDisplaySettingsW, 0x00008830, None
        *   1766 (0x06e6),  (0x), EnumPropsA, 0x0004ed70, None
        *   1767 (0x06e7),  (0x), EnumPropsExA, 0x0004ed90, None
        *   1768 (0x06e8),  (0x), EnumPropsExW, 0x00026dd0, None
        *   1769 (0x06e9),  (0x), EnumPropsW, 0x0004edb0, None
        *   1770 (0x06ea),  (0x), EnumThreadWindows, 0x00021870, None
        *   1771 (0x06eb),  (0x), EnumWindowStationsA, 0x00003410, None
        *   1772 (0x06ec),  (0x), EnumWindowStationsW, 0x00004f40, None
        *   1773 (0x06ed),  (0x), EnumWindows, 0x000218a0, None
        *   1774 (0x06ee),  (0x), EqualRect, 0x00023950, None
        *   1775 (0x06ef),  (0x), EvaluateProximityToPolygon, 0x00081ee0, None
        *   1776 (0x06f0),  (0x), EvaluateProximityToRect, 0x00082410, None
        *   1777 (0x06f1),  (0x), ExcludeUpdateRgn, 0x00033f40, None
        *   1778 (0x06f2),  (0x), ExitWindowsEx, 0x0002c010, None
        *   1779 (0x06f3),  (0x), FillRect, 0x000232d0, None
        *   1780 (0x06f4),  (0x), FindWindowA, 0x0007e260, None
        *   1781 (0x06f5),  (0x), FindWindowExA, 0x00003050, None
        *   1782 (0x06f6),  (0x), FindWindowExW, 0x00025fe0, None
        *   1783 (0x06f7),  (0x), FindWindowW, 0x000235e0, None
        1784 (0x06f8),  (0x), FlashWindow, 0x000896e0, None
        1785 (0x06f9),  (0x), FlashWindowEx, 0x00033f50, None
        *   1786 (0x06fa),  (0x), FrameRect, 0x000303d0, None
        1787 (0x06fb),  (0x), FreeDDElParam, 0x0005a720, None
        1788 (0x06fc),  (0x), FrostCrashedWindow, 0x00033f70, None
        *   1789 (0x06fd),  (0x), GetActiveWindow, 0x0002b390, None
        1790 (0x06fe),  (0x), GetAltTabInfo, 0x00085ef0, None
        *   1791 (0x06ff),  (0x), GetAltTabInfoA, 0x00085ef0, None
        *   1792 (0x0700),  (0x), GetAltTabInfoW, 0x0008c1d0, None
        *   1793 (0x0701),  (0x), GetAncestor, 0x00033f90, None
        1794 (0x0702),  (0x), GetAppCompatFlags, 0x0002b180, None
        1795 (0x0703),  (0x), GetAppCompatFlags2, 0x00011a90, None
        *   1796 (0x0704),  (0x), GetAsyncKeyState, 0x00023fc0, None
        1797 (0x0705),  (0x), GetAutoRotationState, 0x00033fa0, None
        *   1798 (0x0706),  (0x), GetAwarenessFromDpiAwarenessContext, 0x00027f40, None
        *   1799 (0x0707),  (0x), GetCIMSSM, 0x00033fb0, None
        *   1800 (0x0708),  (0x), GetCapture, 0x00027e00, None
        *   1801 (0x0709),  (0x), GetCaretBlinkTime, 0x00033fc0, None
        *   1802 (0x070a),  (0x), GetCaretPos, 0x00033fd0, None
        *   1803 (0x070b),  (0x), GetClassInfoA, 0x00002aa0, None
        *   1804 (0x070c),  (0x), GetClassInfoExA, 0x00002b40, None
        *   1805 (0x070d),  (0x), GetClassInfoExW, 0x00007050, None
        *   1806 (0x070e),  (0x), GetClassInfoW, 0x00007000, None
        *   1807 (0x070f),  (0x), GetClassLongA, 0x0008cb10, None
        *   1808 (0x0710),  (0x), GetClassLongPtrA, 0x0008cb70, None
        *   1809 (0x0711),  (0x), GetClassLongPtrW, 0x00028000, None
        *   1810 (0x0712),  (0x), GetClassLongW, 0x00011b30, None
        *   1811 (0x0713),  (0x), GetClassNameA, 0x0008c200, None
        *   1812 (0x0714),  (0x), GetClassNameW, 0x00021ce0, None
        *   1813 (0x0715),  (0x), GetClassWord, 0x00028730, None
        *   1814 (0x0716),  (0x), GetClientRect, 0x00012cc0, None
        *   1815 (0x0717),  (0x), GetClipCursor, 0x00033fe0, None
        1816 (0x0718),  (0x), GetClipboardAccessToken, 0x00033ff0, None
        *   1817 (0x0719),  (0x), GetClipboardData, 0x0002b430, None
        *   1818 (0x071a),  (0x), GetClipboardFormatNameA, 0x00085f20, None
        *   1819 (0x071b),  (0x), GetClipboardFormatNameW, 0x0002c960, None
        *   1820 (0x071c),  (0x), GetClipboardOwner, 0x0002cd90, None
        *   1821 (0x071d),  (0x), GetClipboardSequenceNumber, 0x0002c7e0, None
        *   1822 (0x071e),  (0x), GetClipboardViewer, 0x00087280, None
        *   1823 (0x071f),  (0x), GetComboBoxInfo, 0x00034000, None
        *   1824 (0x0720),  (0x), GetCurrentInputMessageSource, 0x00034010, None
        *   1825 (0x0721),  (0x), GetCursor, 0x00034020, None
        *   1826 (0x0722),  (0x), GetCursorFrameInfo, 0x0002c630, None
        *   1827 (0x0723),  (0x), GetCursorInfo, 0x00034030, None
        *   1828 (0x0724),  (0x), GetCursorPos, 0x00027e30, None
        *   1829 (0x0725),  (0x), GetDC, 0x00026290, None
        *   1830 (0x0726),  (0x), GetDCEx, 0x00034040, None
        1831 (0x0727),  (0x), GetDesktopID, 0x00034050, None
        *   1832 (0x0728),  (0x), GetDesktopWindow, 0x0000ae40, None
        *   1833 (0x0729),  (0x), GetDialogBaseUnits, 0x000323d0, None
        *   1834 (0x072a),  (0x), GetDialogControlDpiChangeBehavior, 0x0005b250, None
        *   1835 (0x072b),  (0x), GetDialogDpiChangeBehavior, 0x0005b280, None
        1836 (0x072c),  (0x), GetDisplayAutoRotationPreferences, 0x00034060, None
        *   1837 (0x072d),  (0x), GetDisplayConfigBufferSizes, 0x00028ef0, None
        *   1838 (0x072e),  (0x), GetDlgCtrlID, 0x00020c50, None
        *   1839 (0x072f),  (0x), GetDlgItem, 0x00010100, None
        *   1840 (0x0730),  (0x), GetDlgItemInt, 0x0005b2d0, None
        *   1841 (0x0731),  (0x), GetDlgItemTextA, 0x0008cbd0, None
        *   1842 (0x0732),  (0x), GetDlgItemTextW, 0x00032300, None
        *   1843 (0x0733),  (0x), GetDoubleClickTime, 0x00034080, None
        1844 (0x0734),  (0x), GetDpiAwarenessContextForProcess, 0x00089750, None
        1845 (0x0735),  (0x), GetDpiForMonitorInternal, 0x00027a10, None
        *   1846 (0x0736),  (0x), GetDpiForSystem, 0x000115e0, None
        *   1847 (0x0737),  (0x), GetDpiForWindow, 0x00013ed0, None
        *   1848 (0x0738),  (0x), GetDpiFromDpiAwarenessContext, 0x00089770, None
        1849 (0x0739),  (0x), GetExtendedPointerDeviceProperty, 0x00034090, None
        *   1850 (0x073a),  (0x), GetFocus, 0x00023a30, None
        *   1851 (0x073b),  (0x), GetForegroundWindow, 0x000340a0, None
        *   1852 (0x073c),  (0x), GetGUIThreadInfo, 0x000340b0, None
        1853 (0x073d),  (0x), GetGestureConfig, 0x000340c0, None
        1854 (0x073e),  (0x), GetGestureExtraArgs, 0x0004f820, None
        1855 (0x073f),  (0x), GetGestureInfo, 0x0004f850, None
        1856 (0x0740),  (0x), GetGuiResources, 0x000340d0, None
        *   1857 (0x0741),  (0x), GetIconInfo, 0x00027060, None
        *   1858 (0x0742),  (0x), GetIconInfoExA, 0x000521d0, None
        *   1859 (0x0743),  (0x), GetIconInfoExW, 0x0002a010, None
        1860 (0x0744),  (0x), GetInputDesktop, 0x000897a0, None
        1861 (0x0745),  (0x), GetInputLocaleInfo, 0x000340f0, None
        *   1862 (0x0746),  (0x), GetInputState, 0x00084ab0, None
        1863 (0x0747),  (0x), GetInternalWindowPos, 0x00034130, None
        *   1864 (0x0748),  (0x), GetKBCodePage, 0x000897c0, None
        *   1865 (0x0749),  (0x), GetKeyNameTextA, 0x00085fd0, None
        *   1866 (0x074a),  (0x), GetKeyNameTextW, 0x0002c1c0, None
        *   1867 (0x074b),  (0x), GetKeyState, 0x0001e0d0, None
        *   1868 (0x074c),  (0x), GetKeyboardLayout, 0x00027120, None
        *   1869 (0x074d),  (0x), GetKeyboardLayoutList, 0x00034140, None
        *   1870 (0x074e),  (0x), GetKeyboardLayoutNameA, 0x00086090, None
        *   1871 (0x074f),  (0x), GetKeyboardLayoutNameW, 0x0002c1e0, None
        *   1872 (0x0750),  (0x), GetKeyboardState, 0x00034150, None
        *   1873 (0x0751),  (0x), GetKeyboardType, 0x00031f40, None
        *   1874 (0x0752),  (0x), GetLastActivePopup, 0x00014c60, None
        *   1875 (0x0753),  (0x), GetLastInputInfo, 0x00026b10, None
        *   1876 (0x0754),  (0x), GetLayeredWindowAttributes, 0x00034160, None
        *   1877 (0x0755),  (0x), GetListBoxInfo, 0x00034170, None
        1878 (0x0756),  (0x), GetMagnificationDesktopColorEffect, 0x000771e0, None
        1879 (0x0757),  (0x), GetMagnificationDesktopMagnification, 0x000772d0, None
        1880 (0x0758),  (0x), GetMagnificationDesktopSamplingMode, 0x00077370, None
        1881 (0x0759),  (0x), GetMagnificationLensCtxInformation, 0x00034180, None
        *   1882 (0x075a),  (0x), GetMenu, 0x0002a520, None
        *   1883 (0x075b),  (0x), GetMenuBarInfo, 0x00034190, None
        *   1884 (0x075c),  (0x), GetMenuCheckMarkDimensions, 0x000795c0, None
        1885 (0x075d),  (0x), GetMenuContextHelpId, 0x00079600, None
        *   1886 (0x075e),  (0x), GetMenuDefaultItem, 0x000291d0, None
        *   1887 (0x075f),  (0x), GetMenuInfo, 0x000016d0, None
        *   1888 (0x0760),  (0x), GetMenuItemCount, 0x000262c0, None
        *   1889 (0x0761),  (0x), GetMenuItemID, 0x0002a680, None
        *   1890 (0x0762),  (0x), GetMenuItemInfoA, 0x0008cc20, None
        *   1891 (0x0763),  (0x), GetMenuItemInfoW, 0x0001fcf0, None
        *   1892 (0x0764),  (0x), GetMenuItemRect, 0x000341a0, None
        *   1893 (0x0765),  (0x), GetMenuState, 0x0001f930, None
        *   1894 (0x0766),  (0x), GetMenuStringA, 0x0008cd20, None
        *   1895 (0x0767),  (0x), GetMenuStringW, 0x00030e60, None
        *   1896 (0x0768),  (0x), GetMessageA, 0x000287e0, None
        *   1897 (0x0769),  (0x), GetMessageExtraInfo, 0x000295e0, None
        *   1898 (0x076a),  (0x), GetMessagePos, 0x0002b0b0, None
        *   1899 (0x076b),  (0x), GetMessageTime, 0x00029f20, None
        *   1900 (0x076c),  (0x), GetMessageW, 0x00021b70, None
        *   1901 (0x076d),  (0x), GetMonitorInfoA, 0x0002dd40, None
        *   1902 (0x076e),  (0x), GetMonitorInfoW, 0x00020800, None
        *   1903 (0x076f),  (0x), GetMouseMovePointsEx, 0x000341b0, None
        *   1904 (0x0770),  (0x), GetNextDlgGroupItem, 0x0005b8d0, None
        *   1905 (0x0771),  (0x), GetNextDlgTabItem, 0x00001d90, None
        *   1906 (0x0772),  (0x), GetOpenClipboardWindow, 0x0002cd20, None
        *   1907 (0x0773),  (0x), GetParent, 0x0001dd30, None
        *   1908 (0x0774),  (0x), GetPhysicalCursorPos, 0x00027e30, None
        *   1909 (0x0775),  (0x), GetPointerCursorId, 0x000341e0, None
        *   1910 (0x0776),  (0x), GetPointerDevice, 0x000341f0, None
        *   1911 (0x0777),  (0x), GetPointerDeviceCursors, 0x00034200, None
        1912 (0x0778),  (0x), GetPointerDeviceInputSpace, 0x00034210, None
        1913 (0x0779),  (0x), GetPointerDeviceOrientation, 0x00034220, None
        *   1914 (0x077a),  (0x), GetPointerDeviceProperties, 0x00034230, None
        *   1915 (0x077b),  (0x), GetPointerDeviceRects, 0x00034240, None
        *   1916 (0x077c),  (0x), GetPointerDevices, 0x00034250, None
        *   1917 (0x077d),  (0x), GetPointerFrameInfo, 0x000508d0, None
        *   1918 (0x077e),  (0x), GetPointerFrameInfoHistory, 0x00050920, None
        *   1919 (0x077f),  (0x), GetPointerFramePenInfo, 0x00050960, None
        *   1920 (0x0780),  (0x), GetPointerFramePenInfoHistory, 0x000509b0, None
        1921 (0x0781),  (0x), GetPointerFrameTimes, 0x00034260, None
        *   1922 (0x0782),  (0x), GetPointerFrameTouchInfo, 0x000509f0, None
        *   1923 (0x0783),  (0x), GetPointerFrameTouchInfoHistory, 0x00050a40, None
        *   1924 (0x0784),  (0x), GetPointerInfo, 0x00050a80, None
        *   1925 (0x0785),  (0x), GetPointerInfoHistory, 0x00050ae0, None
        *   1926 (0x0786),  (0x), GetPointerInputTransform, 0x00034270, None
        *   1927 (0x0787),  (0x), GetPointerPenInfo, 0x00050b30, None
        *   1928 (0x0788),  (0x), GetPointerPenInfoHistory, 0x00050b90, None
        *   1929 (0x0789),  (0x), GetPointerTouchInfo, 0x00050be0, None
        *   1930 (0x078a),  (0x), GetPointerTouchInfoHistory, 0x00050c40, None
        *   1931 (0x078b),  (0x), GetPointerType, 0x00034290, None
        *   1932 (0x078c),  (0x), GetPriorityClipboardFormat, 0x000872a0, None
        *   1933 (0x078d),  (0x), GetProcessDefaultLayout, 0x0002cd00, None
        1934 (0x078e),  (0x), GetProcessDpiAwarenessInternal, 0x0002b790, None
        *   1935 (0x078f),  (0x), GetProcessWindowStation, 0x000342c0, None
        1936 (0x0790),  (0x), GetProgmanWindow, 0x000897e0, None
        *   1937 (0x0791),  (0x), GetPropA, 0x0002daa0, None
        *   1938 (0x0792),  (0x), GetPropW, 0x00009ea0, None
        *   1939 (0x0793),  (0x), GetQueueStatus, 0x00021010, None
        *   1940 (0x0794),  (0x), GetRawInputBuffer, 0x0006b450, None
        *   1941 (0x0795),  (0x), GetRawInputData, 0x000342e0, None
        *   1942 (0x0796),  (0x), GetRawInputDeviceInfoA, 0x0008cd70, None
        *   1943 (0x0797),  (0x), GetRawInputDeviceInfoW, 0x000323b0, None
        *   1944 (0x0798),  (0x), GetRawInputDeviceList, 0x000342f0, None
        *   1945 (0x0799),  (0x), GetRawPointerDeviceData, 0x00034300, None
        1946 (0x079a),  (0x), GetReasonTitleFromReasonCode, 0x000326e0, None
        *   1947 (0x079b),  (0x), GetRegisteredRawInputDevices, 0x00034310, None
        *   1948 (0x079c),  (0x), GetScrollBarInfo, 0x00034330, None
        *   1949 (0x079d),  (0x), GetScrollInfo, 0x00028520, None
        *   1950 (0x079e),  (0x), GetScrollPos, 0x000313b0, None
        *   1951 (0x079f),  (0x), GetScrollRange, 0x00084af0, None
        1952 (0x07a0),  (0x), GetSendMessageReceiver, 0x00089840, None
        1953 (0x07a1),  (0x), GetShellChangeNotifyWindow, 0x0002bfd0, None
        *   1954 (0x07a2),  (0x), GetShellWindow, 0x00028290, None
        *   1955 (0x07a3),  (0x), GetSubMenu, 0x0002a1f0, None
        *   1956 (0x07a4),  (0x), GetSysColor, 0x00025fa0, None
        *   1957 (0x07a5),  (0x), GetSysColorBrush, 0x00028150, None
        *   1958 (0x07a6),  (0x), GetSystemDpiForProcess, 0x00034340, None
        *   1959 (0x07a7),  (0x), GetSystemMenu, 0x00034350, None
        *   1960 (0x07a8),  (0x), GetSystemMetrics, 0x00020eb0, None
        *   1961 (0x07a9),  (0x), GetSystemMetricsForDpi, 0x00010b50, None
        *   1962 (0x07aa),  (0x), GetTabbedTextExtentA, 0x00058580, None
        *   1963 (0x07ab),  (0x), GetTabbedTextExtentW, 0x00058680, None
        1964 (0x07ac),  (0x), GetTaskmanWindow, 0x0002cd40, None
        *   1965 (0x07ad),  (0x), GetThreadDesktop, 0x00034360, None
        *   1966 (0x07ae),  (0x), GetThreadDpiAwarenessContext, 0x00023df0, None
        *   1967 (0x07af),  (0x), GetThreadDpiHostingBehavior, 0x00089860, None
        *   1968 (0x07b0),  (0x), GetTitleBarInfo, 0x00034370, None
        1969 (0x07b1),  (0x), GetTopLevelWindow, 0x00034380, None
        *   1970 (0x07b2),  (0x), GetTopWindow, 0x0002d240, None
        1971 (0x07b3),  (0x), GetTouchInputInfo, 0x000529c0, None
        *   1972 (0x07b4),  (0x), GetUnpredictedMessagePos, 0x000898b0, None
        *   1973 (0x07b5),  (0x), GetUpdateRect, 0x0002b3d0, None
        *   1974 (0x07b6),  (0x), GetUpdateRgn, 0x000898d0, None
        *   1975 (0x07b7),  (0x), GetUpdatedClipboardFormats, 0x000872c0, None
        *   1976 (0x07b8),  (0x), GetUserObjectInformationA, 0x0002c550, None
        *   1977 (0x07b9),  (0x), GetUserObjectInformationW, 0x000343b0, None
        1978 (0x07ba),  (0x), GetUserObjectSecurity, 0x00089970, None
        1979 (0x07bb),  (0x), GetWinStationInfo, 0x000899d0, None
        *   1980 (0x07bc),  (0x), GetWindow, 0x00009d30, None
        1981 (0x07bd),  (0x), GetWindowBand, 0x000343c0, None
        1982 (0x07be),  (0x), GetWindowCompositionAttribute, 0x000343d0, None
        1983 (0x07bf),  (0x), GetWindowCompositionInfo, 0x000343e0, None
        1984 (0x07c0),  (0x), GetWindowContextHelpId, 0x000899f0, None
        1985 (0x07c1),  (0x), GetWindowDC, 0x000343f0, None
        *   1986 (0x07c2),  (0x), GetWindowDisplayAffinity, 0x00034400, None
        *   1987 (0x07c3),  (0x), GetWindowDpiAwarenessContext, 0x000133b0, None
        *   1988 (0x07c4),  (0x), GetWindowDpiHostingBehavior, 0x00089a10, None
        *   1989 (0x07c5),  (0x), GetWindowFeedbackSetting, 0x00034410, None
        *   1990 (0x07c6),  (0x), GetWindowInfo, 0x00010550, None
        *   1991 (0x07c7),  (0x), GetWindowLongA, 0x00013f30, None
        *   1992 (0x07c8),  (0x), GetWindowLongPtrA, 0x00010d70, None
        *   1993 (0x07c9),  (0x), GetWindowLongPtrW, 0x0000f7c0, None
        *   1994 (0x07ca),  (0x), GetWindowLongW, 0x0000fb00, None
        1995 (0x07cb),  (0x), GetWindowMinimizeRect, 0x00034430, None
        1996 (0x07cc),  (0x), GetWindowModuleFileName, 0x0008ceb0, None
        *   1997 (0x07cd),  (0x), GetWindowModuleFileNameA, 0x0008ceb0, None
        *   1998 (0x07ce),  (0x), GetWindowModuleFileNameW, 0x0008a830, None
        *   1999 (0x07cf),  (0x), GetWindowPlacement, 0x00034440, None
        2000 (0x07d0),  (0x), GetWindowProcessHandle, 0x00034450, None
        2001 (0x07d1),  (0x), Ordinal_2001, 0x00077630, None
        2002 (0x07d2),  (0x), Ordinal_2002, 0x000773d0, None
        *   2003 (0x07d3),  (0x), GetWindowRect, 0x00014670, None
        2004 (0x07d4),  (0x), GetWindowRgn, 0x0002a390, None
        2005 (0x07d5),  (0x), Ordinal_2005, 0x00034b60, None
        2006 (0x07d6),  (0x), GetWindowRgnBox, 0x00009050, None
        2007 (0x07d7),  (0x), GetWindowRgnEx, 0x00034460, None
        *   2008 (0x07d8),  (0x), GetWindowTextA, 0x00009420, None
        *   2009 (0x07d9),  (0x), GetWindowTextLengthA, 0x0008cf00, None
        2010 (0x07da),  (0x), Ordinal_2010, 0x00034f20, None
        *   2011 (0x07db),  (0x), GetWindowTextLengthW, 0x0000a190, None
        *   2012 (0x07dc),  (0x), GetWindowTextW, 0x0000c280, None
        *   2013 (0x07dd),  (0x), GetWindowThreadProcessId, 0x00003500, None
        2014 (0x07de),  (0x), GetWindowWord, 0x00084bc0, None
        2015 (0x07df),  (0x), GhostWindowFromHungWindow, 0x00034470, None
        *   2016 (0x07e0),  (0x), GrayStringA, 0x00089a80, None
        *   2017 (0x07e1),  (0x), GrayStringW, 0x00089ae0, None
        *   2018 (0x07e2),  (0x), HideCaret, 0x00028f60, None
        *   2019 (0x07e3),  (0x), HiliteMenuItem, 0x000344a0, None
        2020 (0x07e4),  (0x), HungWindowFromGhostWindow, 0x000344b0, None
        2021 (0x07e5),  (0x), IMPGetIMEA, 0x000867e0, None
        2022 (0x07e6),  (0x), IMPGetIMEW, 0x00086800, None
        2023 (0x07e7),  (0x), IMPQueryIMEA, 0x00086820, None
        2024 (0x07e8),  (0x), IMPQueryIMEW, 0x00086840, None
        2025 (0x07e9),  (0x), IMPSetIMEA, 0x00086860, None
        2026 (0x07ea),  (0x), IMPSetIMEW, 0x00086880, None
        2027 (0x07eb),  (0x), ImpersonateDdeClientWindow, 0x000344c0, None
        *   2028 (0x07ec),  (0x), InSendMessage, 0x000282f0, None
        *   2029 (0x07ed),  (0x), InSendMessageEx, 0x00023c60, None
        *   2030 (0x07ee),  (0x), InflateRect, 0x00004e70, None
        2031 (0x07ef),  (0x), InheritWindowMonitor, 0x000344d0, None
        2032 (0x07f0),  (0x), InitDManipHook, 0x00022310, None
        2033 (0x07f1),  (0x), InitializeGenericHidInjection, 0x000344e0, None
        2034 (0x07f2),  (0x), InitializeInputDeviceInjection, 0x000344f0, None
        2035 (0x07f3),  (0x), InitializeLpkHooks, 0x00027430, None
        2036 (0x07f4),  (0x), InitializePointerDeviceInjection, 0x00034500, None
        2037 (0x07f5),  (0x), InitializePointerDeviceInjectionEx, 0x00034510, None
        *   2038 (0x07f6),  (0x), InitializeTouchInjection, 0x00034520, None
        2039 (0x07f7),  (0x), InjectDeviceInput, 0x00034530, None
        2040 (0x07f8),  (0x), InjectGenericHidInput, 0x00034540, None
        2041 (0x07f9),  (0x), InjectKeyboardInput, 0x00034550, None
        2042 (0x07fa),  (0x), InjectMouseInput, 0x00034560, None
        2043 (0x07fb),  (0x), InjectPointerInput, 0x00034570, None
        *   2044 (0x07fc),  (0x), InjectSyntheticPointerInput, 0x00034570, None
        *   2045 (0x07fd),  (0x), InjectTouchInput, 0x00034580, None
        2046 (0x07fe),  (0x), InputSpaceRegionFromPoint, 0x00034590, None
        *   2047 (0x07ff),  (0x), InsertMenuA, 0x0008cf50, None
        *   2048 (0x0800),  (0x), InsertMenuItemA, 0x0008cfd0, None
        *   2049 (0x0801),  (0x), InsertMenuItemW, 0x0001fb40, None
        *   2050 (0x0802),  (0x), InsertMenuW, 0x0001fa60, None
        2051 (0x0803),  (0x), InternalGetWindowIcon, 0x0007de00, None
        *   2052 (0x0804),  (0x), InternalGetWindowText, 0x00027fb0, None
        *   2053 (0x0805),  (0x), IntersectRect, 0x00013b10, None
        *   2054 (0x0806),  (0x), InvalidateRect, 0x000345b0, None
        *   2055 (0x0807),  (0x), InvalidateRgn, 0x000345c0, None
        *   2056 (0x0808),  (0x), InvertRect, 0x000261f0, None
        *   2057 (0x0809),  (0x), IsCharAlphaA, 0x000872e0, None
        *   2058 (0x080a),  (0x), IsCharAlphaNumericA, 0x00087300, None
        *   2059 (0x080b),  (0x), IsCharAlphaNumericW, 0x000325f0, None
        *   2060 (0x080c),  (0x), IsCharAlphaW, 0x00087320, None
        *   2061 (0x080d),  (0x), IsCharLowerA, 0x00087340, None
        *   2062 (0x080e),  (0x), IsCharLowerW, 0x00087360, None
        *   2063 (0x080f),  (0x), IsCharUpperA, 0x00087380, None
        *   2064 (0x0810),  (0x), IsCharUpperW, 0x000873a0, None
        *   2065 (0x0811),  (0x), IsChild, 0x00013f80, None
        *   2066 (0x0812),  (0x), IsClipboardFormatAvailable, 0x000235c0, None
        2067 (0x0813),  (0x), IsDialogMessage, 0x0005b540, None
        *   2068 (0x0814),  (0x), IsDialogMessageA, 0x0005b540, None
        *   2069 (0x0815),  (0x), IsDialogMessageW, 0x0000bd60, None
        *   2070 (0x0816),  (0x), IsDlgButtonChecked, 0x0005b450, None
        *   2071 (0x0817),  (0x), IsGUIThread, 0x000280e0, None
        *   2072 (0x0818),  (0x), IsHungAppWindow, 0x00029ef0, None
        *   2073 (0x0819),  (0x), IsIconic, 0x0000c180, None
        2074 (0x081a),  (0x), IsImmersiveProcess, 0x00029660, None
        2075 (0x081b),  (0x), IsInDesktopWindowBand, 0x0002b2c0, None
        *   2076 (0x081c),  (0x), IsMenu, 0x00027960, None
        *   2077 (0x081d),  (0x), IsMouseInPointerEnabled, 0x000345e0, None
        2078 (0x081e),  (0x), IsOneCoreTransformMode, 0x00034610, None
        *   2079 (0x081f),  (0x), IsProcessDPIAware, 0x00021af0, None
        2080 (0x0820),  (0x), IsQueueAttached, 0x00089b40, None
        *   2081 (0x0821),  (0x), IsRectEmpty, 0x00023480, None
        2082 (0x0822),  (0x), IsSETEnabled, 0x0007f3c0, None
        2083 (0x0823),  (0x), IsServerSideWindow, 0x00011b00, None
        2084 (0x0824),  (0x), IsThreadDesktopComposited, 0x00010cc0, None
        2085 (0x0825),  (0x), IsThreadTSFEventAware, 0x00001470, None
        2086 (0x0826),  (0x), IsTopLevelWindow, 0x00034630, None
        2087 (0x0827),  (0x), IsTouchWindow, 0x00034640, None
        *   2088 (0x0828),  (0x), IsValidDpiAwarenessContext, 0x00089b60, None
        2089 (0x0829),  (0x), IsWinEventHookInstalled, 0x00023ab0, None
        *   2090 (0x082a),  (0x), IsWindow, 0x0000a090, None
        2091 (0x082b),  (0x), IsWindowArranged, 0x0000c110, None
        *   2092 (0x082c),  (0x), IsWindowEnabled, 0x00011a40, None
        2093 (0x082d),  (0x), IsWindowInDestroy, 0x000234b0, None
        2094 (0x082e),  (0x), IsWindowRedirectedForPrint, 0x00013340, None
        *   2095 (0x082f),  (0x), IsWindowUnicode, 0x00011770, None
        *   2096 (0x0830),  (0x), IsWindowVisible, 0x0001e180, None
        2097 (0x0831),  (0x), IsWow64Message, 0x00050610, None
        *   2098 (0x0832),  (0x), IsZoomed, 0x00023980, None
        *   2099 (0x0833),  (0x), KillTimer, 0x00034670, None
        *   2100 (0x0834),  (0x), LoadAcceleratorsA, 0x00052320, None
        *   2101 (0x0835),  (0x), LoadAcceleratorsW, 0x00027ae0, None
        *   2102 (0x0836),  (0x), LoadBitmapA, 0x00031e60, None
        *   2103 (0x0837),  (0x), LoadBitmapW, 0x0002bcb0, None
        *   2104 (0x0838),  (0x), LoadCursorA, 0x00029eb0, None
        *   2105 (0x0839),  (0x), LoadCursorFromFileA, 0x0004c390, None
        *   2106 (0x083a),  (0x), LoadCursorFromFileW, 0x0004c400, None
        *   2107 (0x083b),  (0x), LoadCursorW, 0x000145c0, None
        *   2108 (0x083c),  (0x), LoadIconA, 0x0002cb30, None
        *   2109 (0x083d),  (0x), LoadIconW, 0x00016eb0, None
        *   2110 (0x083e),  (0x), LoadImageA, 0x0002fd80, None
        *   2111 (0x083f),  (0x), LoadImageW, 0x00016b40, None
        *   2112 (0x0840),  (0x), LoadKeyboardLayoutA, 0x00089b80, None
        2113 (0x0841),  (0x), LoadKeyboardLayoutEx, 0x00089c10, None
        *   2114 (0x0842),  (0x), LoadKeyboardLayoutW, 0x0001d000, None
        2115 (0x0843),  (0x), LoadLocalFonts, 0x0002cf20, None
        *   2116 (0x0844),  (0x), LoadMenuA, 0x0004fe90, None
        *   2117 (0x0845),  (0x), LoadMenuIndirectA, 0x00021ee0, None
        *   2118 (0x0846),  (0x), LoadMenuIndirectW, 0x00021ee0, None
        *   2119 (0x0847),  (0x), LoadMenuW, 0x00021e20, None
        2120 (0x0848),  (0x), LoadRemoteFonts, 0x0002cea0, None
        *   2121 (0x0849),  (0x), LoadStringA, 0x00052360, None
        *   2122 (0x084a),  (0x), LoadStringW, 0x00028120, None
        *   2123 (0x084b),  (0x), LockSetForegroundWindow, 0x00089c40, None
        2124 (0x084c),  (0x), LockWindowStation, 0x00034690, None
        *   2125 (0x084d),  (0x), LockWindowUpdate, 0x000346a0, None
        *   2126 (0x084e),  (0x), LockWorkStation, 0x000346b0, None
        *   2127 (0x084f),  (0x), LogicalToPhysicalPoint, 0x000346d0, None
        *   2128 (0x0850),  (0x), LogicalToPhysicalPointForPerMonitorDPI, 0x000346e0, None
        *   2129 (0x0851),  (0x), LookupIconIdFromDirectory, 0x000523f0, None
        *   2130 (0x0852),  (0x), LookupIconIdFromDirectoryEx, 0x00025aa0, None
        2131 (0x0853),  (0x), MBToWCSEx, 0x000241c0, None
        2132 (0x0854),  (0x), MBToWCSExt, 0x00024190, None
        2133 (0x0855),  (0x), MB_GetString, 0x0007c2c0, None
        2134 (0x0856),  (0x), MITGetCursorUpdateHandle, 0x0002cfc0, None
        2135 (0x0857),  (0x), MITSetForegroundRoutingInfo, 0x0002d020, None
        2136 (0x0858),  (0x), MITSetInputDelegationMode, 0x0002b7f0, None
        2137 (0x0859),  (0x), MITSetLastInputRecipient, 0x0007f720, None
        2138 (0x085a),  (0x), MITSynthesizeTouchInput, 0x0007f740, None
        2139 (0x085b),  (0x), MakeThreadTSFEventAware, 0x0002b110, None
        *   2140 (0x085c),  (0x), MapDialogRect, 0x000317b0, None
        2141 (0x085d),  (0x), MapPointsByVisualIdentifier, 0x000346f0, None
        *   2142 (0x085e),  (0x), MapVirtualKeyA, 0x00086100, None
        *   2143 (0x085f),  (0x), MapVirtualKeyExA, 0x00086170, None
        *   2144 (0x0860),  (0x), MapVirtualKeyExW, 0x0002b0f0, None
        *   2145 (0x0861),  (0x), MapVirtualKeyW, 0x00027fe0, None
        2146 (0x0862),  (0x), MapVisualRelativePoints, 0x00034700, None
        *   2147 (0x0863),  (0x), MapWindowPoints, 0x0000b9f0, None
        *   2148 (0x0864),  (0x), MenuItemFromPoint, 0x00034710, None
        2149 (0x0865),  (0x), MenuWindowProcA, 0x00050630, None
        2150 (0x0866),  (0x), MenuWindowProcW, 0x000506b0, None
        2151 (0x0867),  (0x), MessageBeep, 0x00089c60, None
        *   2152 (0x0868),  (0x), MessageBoxA, 0x0007c2f0, None
        *   2153 (0x0869),  (0x), MessageBoxExA, 0x0007c350, None
        *   2154 (0x086a),  (0x), MessageBoxExW, 0x0007c380, None
        *   2155 (0x086b),  (0x), MessageBoxIndirectA, 0x0007c3b0, None
        *   2156 (0x086c),  (0x), MessageBoxIndirectW, 0x0007c560, None
        2157 (0x086d),  (0x), MessageBoxTimeoutA, 0x0007c620, None
        2158 (0x086e),  (0x), MessageBoxTimeoutW, 0x0007c790, None
        *   2159 (0x086f),  (0x), MessageBoxW, 0x0007c970, None
        *   2160 (0x0870),  (0x), ModifyMenuA, 0x0008d040, None
        *   2161 (0x0871),  (0x), ModifyMenuW, 0x00031de0, None
        *   2162 (0x0872),  (0x), MonitorFromPoint, 0x00029620, None
        *   2163 (0x0873),  (0x), MonitorFromRect, 0x000136e0, None
        *   2164 (0x0874),  (0x), MonitorFromWindow, 0x00021140, None
        *   2165 (0x0875),  (0x), MoveWindow, 0x00034720, None
        2166 (0x0876),  (0x), MsgWaitForMultipleObjects, 0x00020720, None
        2167 (0x0877),  (0x), MsgWaitForMultipleObjectsEx, 0x00020750, None
        2168 (0x0878),  (0x), NotifyOverlayWindow, 0x00089c80, None
        2169 (0x0879),  (0x), NotifyWinEvent, 0x00004a50, None
        *   2170 (0x087a),  (0x), OemKeyScan, 0x0007e400, None
        *   2171 (0x087b),  (0x), OemToCharA, 0x0007e490, None
        *   2172 (0x087c),  (0x), OemToCharBuffA, 0x0007e4e0, None
        *   2173 (0x087d),  (0x), OemToCharBuffW, 0x0007e530, None
        *   2174 (0x087e),  (0x), OemToCharW, 0x0007e580, None
        *   2175 (0x087f),  (0x), OffsetRect, 0x0000ae10, None
        *   2176 (0x0880),  (0x), OpenClipboard, 0x0002b970, None
        *   2177 (0x0881),  (0x), OpenDesktopA, 0x0001b4f0, None
        *   2178 (0x0882),  (0x), OpenDesktopW, 0x0001a620, None
        *   2179 (0x0883),  (0x), OpenIcon, 0x00089ca0, None
        *   2180 (0x0884),  (0x), OpenInputDesktop, 0x00034740, None
        2181 (0x0885),  (0x), OpenThreadDesktop, 0x00034750, None
        *   2182 (0x0886),  (0x), OpenWindowStationA, 0x0001c520, None
        *   2183 (0x0887),  (0x), OpenWindowStationW, 0x0001b480, None
        2184 (0x0888),  (0x), PackDDElParam, 0x0005a7a0, None
        *   2185 (0x0889),  (0x), PackTouchHitTestingProximityEvaluation, 0x00082550, None
        *   2186 (0x088a),  (0x), PaintDesktop, 0x0007de20, None
        2187 (0x088b),  (0x), PaintMenuBar, 0x00034760, None
        2188 (0x088c),  (0x), PaintMonitor, 0x00034770, None
        *   2189 (0x088d),  (0x), PeekMessageA, 0x00009910, None
        *   2190 (0x088e),  (0x), PeekMessageW, 0x0000a370, None
        *   2191 (0x088f),  (0x), PhysicalToLogicalPoint, 0x00034790, None
        *   2192 (0x0890),  (0x), PhysicalToLogicalPointForPerMonitorDPI, 0x000347a0, None
        *   2193 (0x0891),  (0x), PostMessageA, 0x00029970, None
        *   2194 (0x0892),  (0x), PostMessageW, 0x000210a0, None
        *   2195 (0x0893),  (0x), PostQuitMessage, 0x0002bac0, None
        *   2196 (0x0894),  (0x), PostThreadMessageA, 0x00032270, None
        *   2197 (0x0895),  (0x), PostThreadMessageW, 0x00027f70, None
        2198 (0x0896),  (0x), PrintWindow, 0x000347b0, None
        2199 (0x0897),  (0x), PrivateExtractIconExA, 0x0006afe0, None
        2200 (0x0898),  (0x), PrivateExtractIconExW, 0x0006b070, None
        *   2201 (0x0899),  (0x), PrivateExtractIconsA, 0x0006b210, None
        *   2202 (0x089a),  (0x), PrivateExtractIconsW, 0x0001ba30, None
        2203 (0x089b),  (0x), PrivateRegisterICSProc, 0x00052410, None
        *   2204 (0x089c),  (0x), PtInRect, 0x000136b0, None
        2205 (0x089d),  (0x), QueryBSDRWindow, 0x000347f0, None
        *   2206 (0x089e),  (0x), QueryDisplayConfig, 0x00026720, None
        2207 (0x089f),  (0x), QuerySendMessage, 0x00034800, None
        2208 (0x08a0),  (0x), RIMAddInputObserver, 0x00034810, None
        2209 (0x08a1),  (0x), RIMAreSiblingDevices, 0x00034820, None
        2210 (0x08a2),  (0x), RIMDeviceIoControl, 0x00034830, None
        2211 (0x08a3),  (0x), RIMEnableMonitorMappingForDevice, 0x00034840, None
        2212 (0x08a4),  (0x), RIMFreeInputBuffer, 0x00034850, None
        2213 (0x08a5),  (0x), RIMGetDevicePreparsedData, 0x00034860, None
        2214 (0x08a6),  (0x), RIMGetDevicePreparsedDataLockfree, 0x00034870, None
        2215 (0x08a7),  (0x), RIMGetDeviceProperties, 0x00034880, None
        2216 (0x08a8),  (0x), RIMGetDevicePropertiesLockfree, 0x00034890, None
        2217 (0x08a9),  (0x), RIMGetPhysicalDeviceRect, 0x000348a0, None
        2218 (0x08aa),  (0x), RIMGetSourceProcessId, 0x000348b0, None
        2219 (0x08ab),  (0x), RIMObserveNextInput, 0x000348c0, None
        2220 (0x08ac),  (0x), RIMOnPnpNotification, 0x000348d0, None
        2221 (0x08ad),  (0x), RIMOnTimerNotification, 0x000348e0, None
        2222 (0x08ae),  (0x), RIMQueryDevicePath, 0x000348f0, None
        2223 (0x08af),  (0x), RIMReadInput, 0x00034900, None
        2224 (0x08b0),  (0x), RIMRegisterForInput, 0x00034910, None
        2225 (0x08b1),  (0x), RIMRemoveInputObserver, 0x00034920, None
        2226 (0x08b2),  (0x), RIMSetExtendedDeviceProperty, 0x00034930, None
        2227 (0x08b3),  (0x), RIMSetTestModeStatus, 0x00034940, None
        2228 (0x08b4),  (0x), RIMUnregisterForInput, 0x00034950, None
        2229 (0x08b5),  (0x), RIMUpdateInputObserverRegistration, 0x00034960, None
        *   2230 (0x08b6),  (0x), RealChildWindowFromPoint, 0x00034970, None
        *   2231 (0x08b7),  (0x), RealGetWindowClass, 0x00086260, None
        *   2232 (0x08b8),  (0x), RealGetWindowClassA, 0x00086260, None
        *   2233 (0x08b9),  (0x), RealGetWindowClassW, 0x00023ef0, None
        2234 (0x08ba),  (0x), ReasonCodeNeedsBugID, 0x0007f5b0, None
        2235 (0x08bb),  (0x), ReasonCodeNeedsComment, 0x0007f5c0, None
        2236 (0x08bc),  (0x), RecordShutdownReason, 0x00032d30, None
        *   2237 (0x08bd),  (0x), RedrawWindow, 0x00034980, None
        2238 (0x08be),  (0x), RegisterBSDRWindow, 0x00034990, None
        *   2239 (0x08bf),  (0x), RegisterClassA, 0x00002ad0, None
        *   2240 (0x08c0),  (0x), RegisterClassExA, 0x0008d0c0, None
        *   2241 (0x08c1),  (0x), RegisterClassExW, 0x00007250, None
        *   2242 (0x08c2),  (0x), RegisterClassW, 0x00007280, None
        *   2243 (0x08c3),  (0x), RegisterClipboardFormatA, 0x00003140, None
        *   2244 (0x08c4),  (0x), RegisterClipboardFormatW, 0x00026c50, None
        2245 (0x08c5),  (0x), RegisterDManipHook, 0x000349a0, None
        *   2246 (0x08c6),  (0x), RegisterDeviceNotificationA, 0x0002bba0, None
        *   2247 (0x08c7),  (0x), RegisterDeviceNotificationW, 0x0002bba0, None
        2248 (0x08c8),  (0x), RegisterErrorReportingDialog, 0x000349b0, None
        2249 (0x08c9),  (0x), RegisterFrostWindow, 0x00089d30, None
        2250 (0x08ca),  (0x), RegisterGhostWindow, 0x00089d50, None
        *   2251 (0x08cb),  (0x), RegisterHotKey, 0x000349c0, None
        2252 (0x08cc),  (0x), RegisterLogonProcess, 0x0002cbd0, None
        2253 (0x08cd),  (0x), RegisterMessagePumpHook, 0x0002be00, None
        *   2254 (0x08ce),  (0x), RegisterPointerDeviceNotifications, 0x000349d0, None
        2255 (0x08cf),  (0x), RegisterPointerInputTarget, 0x00050cb0, None
        2256 (0x08d0),  (0x), RegisterPointerInputTargetEx, 0x00050750, None
        *   2257 (0x08d1),  (0x), RegisterPowerSettingNotification, 0x0002a2c0, None
        *   2258 (0x08d2),  (0x), RegisterRawInputDevices, 0x000349e0, None
        2259 (0x08d3),  (0x), RegisterServicesProcess, 0x000349f0, None
        2260 (0x08d4),  (0x), RegisterSessionPort, 0x00034a00, None
        *   2261 (0x08d5),  (0x), RegisterShellHookWindow, 0x0002cc80, None
        *   2262 (0x08d6),  (0x), RegisterSuspendResumeNotification, 0x0007e070, None
        2263 (0x08d7),  (0x), RegisterSystemThread, 0x00032540, None
        2264 (0x08d8),  (0x), RegisterTasklist, 0x00034a20, None
        2265 (0x08d9),  (0x), RegisterTouchHitTestingWindow, 0x00034a30, None
        2266 (0x08da),  (0x), RegisterTouchWindow, 0x0007e0e0, None
        2267 (0x08db),  (0x), RegisterUserApiHook, 0x0002c6a0, None
        *   2268 (0x08dc),  (0x), RegisterWindowMessageA, 0x00003140, None
        *   2269 (0x08dd),  (0x), RegisterWindowMessageW, 0x00026c50, None
        *   2270 (0x08de),  (0x), ReleaseCapture, 0x0002c5c0, None
        *   2271 (0x08df),  (0x), ReleaseDC, 0x00023ca0, None
        2272 (0x08e0),  (0x), ReleaseDwmHitTestWaiters, 0x00034a50, None
        *   2273 (0x08e1),  (0x), RemoveClipboardFormatListener, 0x0002cf80, None
        2274 (0x08e2),  (0x), RemoveInjectionDevice, 0x00033d60, None
        *   2275 (0x08e3),  (0x), RemoveMenu, 0x00034a60, None
        *   2276 (0x08e4),  (0x), RemovePropA, 0x00086330, None
        *   2277 (0x08e5),  (0x), RemovePropW, 0x000260d0, None
        2278 (0x08e6),  (0x), RemoveThreadTSFEventAwareness, 0x00082de0, None
        2279 (0x08e7),  (0x), RemoveVisualIdentifier, 0x00034a70, None
        *   2280 (0x08e8),  (0x), ReplyMessage, 0x00029900, None
        2281 (0x08e9),  (0x), ResolveDesktopForWOW, 0x00034a90, None
        2282 (0x08ea),  (0x), ReuseDDElParam, 0x0005a820, None
        *   2283 (0x08eb),  (0x), ScreenToClient, 0x00011cf0, None
        2284 (0x08ec),  (0x), ScrollChildren, 0x00079240, None
        *   2285 (0x08ed),  (0x), ScrollDC, 0x00026d90, None
        *   2286 (0x08ee),  (0x), ScrollWindow, 0x00089db0, None
        *   2287 (0x08ef),  (0x), ScrollWindowEx, 0x00026ae0, None
        *   2288 (0x08f0),  (0x), SendDlgItemMessageA, 0x0008d110, None
        *   2289 (0x08f1),  (0x), SendDlgItemMessageW, 0x00001420, None
        *   2290 (0x08f2),  (0x), SendIMEMessageExA, 0x000868a0, None
                                  [This function is obsolete and should not be used.]
                                  https://learn.microsoft.com/en-us/windows/win32/api/ime/nf-ime-sendimemessageexa
        *   2291 (0x08f3),  (0x), SendIMEMessageExW, 0x000868c0, None
                                  [This function is obsolete and should not be used.]
                                  https://learn.microsoft.com/en-us/windows/win32/api/ime/nf-ime-sendimemessageexw
        *   2292 (0x08f4),  (0x), SendInput, 0x00034ac0, None
        *   2293 (0x08f5),  (0x), SendMessageA, 0x000096c0, None
        *   2294 (0x08f6),  (0x), SendMessageCallbackA, 0x000863d0, None
        *   2295 (0x08f7),  (0x), SendMessageCallbackW, 0x00027eb0, None
        *   2296 (0x08f8),  (0x), SendMessageTimeoutA, 0x00031200, None
        *   2297 (0x08f9),  (0x), SendMessageTimeoutW, 0x00020ae0, None
        *   2298 (0x08fa),  (0x), SendMessageW, 0x0000d540, None
        *   2299 (0x08fb),  (0x), SendNotifyMessageA, 0x00030c90, None
        *   2300 (0x08fc),  (0x), SendNotifyMessageW, 0x00029480, None
        *   2301 (0x08fd),  (0x), SetActiveWindow, 0x00034b00, None
        *   2302 (0x08fe),  (0x), SetCapture, 0x00034b50, None
        *   2303 (0x08ff),  (0x), SetCaretBlinkTime, 0x0002b0d0, None
        *   2304 (0x0900),  (0x), SetCaretPos, 0x0002b810, None
        *   2305 (0x0901),  (0x), SetClassLongA, 0x00086460, None
        *   2306 (0x0902),  (0x), SetClassLongPtrA, 0x00086480, None
        *   2307 (0x0903),  (0x), SetClassLongPtrW, 0x0002caa0, None
        *   2308 (0x0904),  (0x), SetClassLongW, 0x00032520, None
        *   2309 (0x0905),  (0x), SetClassWord, 0x00034b70, None
        *   2310 (0x0906),  (0x), SetClipboardData, 0x00030090, None
        *   2311 (0x0907),  (0x), SetClipboardViewer, 0x00032590, None
        *   2312 (0x0908),  (0x), SetCoalescableTimer, 0x00034b80, None
        *   2313 (0x0909),  (0x), SetCursor, 0x0002b280, None
        2314 (0x090a),  (0x), SetCursorContents, 0x00034bb0, None
        *   2315 (0x090b),  (0x), SetCursorPos, 0x00034bd0, None
        2316 (0x090c),  (0x), SetDebugErrorLevel, 0x0002d010, None
        2317 (0x090d),  (0x), SetDeskWallpaper, 0x00089e10, None
        2318 (0x090e),  (0x), SetDesktopColorTransform, 0x00034be0, None
        *   2319 (0x090f),  (0x), SetDialogControlDpiChangeBehavior, 0x00034c00, None
        *   2320 (0x0910),  (0x), SetDialogDpiChangeBehavior, 0x0005b490, None
        2321 (0x0911),  (0x), SetDisplayAutoRotationPreferences, 0x00034c10, None
        *   2322 (0x0912),  (0x), SetDisplayConfig, 0x0008e840, None
        *   2323 (0x0913),  (0x), SetDlgItemInt, 0x00001560, None
        *   2324 (0x0914),  (0x), SetDlgItemTextA, 0x0008d160, None
        *   2325 (0x0915),  (0x), SetDlgItemTextW, 0x0008a880, None
        *   2326 (0x0916),  (0x), SetDoubleClickTime, 0x00089e30, None
        2327 (0x0917),  (0x), SetFeatureReportResponse, 0x00034c40, None
        *   2328 (0x0918),  (0x), SetFocus, 0x00034c50, None
        *   2329 (0x0919),  (0x), SetForegroundWindow, 0x0002bde0, None
        2330 (0x091a),  (0x), SetFullscreenMagnifierOffsetsDWMUpdated, 0x00034c70, None
        2331 (0x091b),  (0x), SetGestureConfig, 0x00034c80, None
        2332 (0x091c),  (0x), SetInternalWindowPos, 0x00034cc0, None
        *   2333 (0x091d),  (0x), SetKeyboardState, 0x00034cd0, None
        2334 (0x091e),  (0x), SetLastErrorEx, 0x0007e5e0, None
        *   2335 (0x091f),  (0x), SetLayeredWindowAttributes, 0x00034ce0, None
        2336 (0x0920),  (0x), SetMagnificationDesktopColorEffect, 0x00077480, None
        2337 (0x0921),  (0x), SetMagnificationDesktopMagnification, 0x00077560, None
        2338 (0x0922),  (0x), SetMagnificationDesktopMagnifierOffsetsDWMUpdated, 0x00034cf0, None
        2339 (0x0923),  (0x), SetMagnificationDesktopSamplingMode, 0x000775e0, None
        2340 (0x0924),  (0x), SetMagnificationLensCtxInformation, 0x00034d00, None
        *   2341 (0x0925),  (0x), SetMenu, 0x0002c8d0, None
        2342 (0x0926),  (0x), SetMenuContextHelpId, 0x00034d10, None
        *   2343 (0x0927),  (0x), SetMenuDefaultItem, 0x00034d20, None
        *   2344 (0x0928),  (0x), SetMenuInfo, 0x00001770, None
        *   2345 (0x0929),  (0x), SetMenuItemBitmaps, 0x00001ba0, None
        *   2346 (0x092a),  (0x), SetMenuItemInfoA, 0x0008d190, None
        *   2347 (0x092b),  (0x), SetMenuItemInfoW, 0x0001f9f0, None
        *   2348 (0x092c),  (0x), SetMessageExtraInfo, 0x00050730, None
        2349 (0x092d),  (0x), SetMessageQueue, 0x0002d040, None
        2350 (0x092e),  (0x), SetMirrorRendering, 0x00034d30, None
        *   2351 (0x092f),  (0x), SetParent, 0x0002c460, None
        *   2352 (0x0930),  (0x), SetPhysicalCursorPos, 0x00034bd0, None
        2353 (0x0931),  (0x), SetPointerDeviceInputSpace, 0x00034d40, None
        *   2354 (0x0932),  (0x), SetProcessDPIAware, 0x0001b4d0, None
        *   2355 (0x0933),  (0x), SetProcessDefaultLayout, 0x00089e50, None
        *   2356 (0x0934),  (0x), SetProcessDpiAwarenessContext, 0x0001a4f0, None
        2357 (0x0935),  (0x), SetProcessDpiAwarenessInternal, 0x0001a4a0, None
        2358 (0x0936),  (0x), SetProcessRestrictionExemption, 0x00034d80, None
        *   2359 (0x0937),  (0x), SetProcessWindowStation, 0x00034d90, None
        2360 (0x0938),  (0x), SetProgmanWindow, 0x00089e70, None
        *   2361 (0x0939),  (0x), SetPropA, 0x000865c0, None
        *   2362 (0x093a),  (0x), SetPropW, 0x000240b0, None
        *   2363 (0x093b),  (0x), SetRect, 0x00023a00, None
        *   2364 (0x093c),  (0x), SetRectEmpty, 0x000239e0, None
        *   2365 (0x093d),  (0x), SetScrollInfo, 0x00012a60, None
        *   2366 (0x093e),  (0x), SetScrollPos, 0x00032480, None
        *   2367 (0x093f),  (0x), SetScrollRange, 0x00030f70, None
        2368 (0x0940),  (0x), SetShellChangeNotifyWindow, 0x0002cf60, None
        2369 (0x0941),  (0x), SetShellWindow, 0x00089e90, None
        2370 (0x0942),  (0x), SetShellWindowEx, 0x00034db0, None
        *   2371 (0x0943),  (0x), SetSysColors, 0x0002ce50, None
        2372 (0x0944),  (0x), SetSysColorsTemp, 0x0007e600, None
        2373 (0x0945),  (0x), SetSystemCursor, 0x0007e100, None
        2374 (0x0946),  (0x), SetSystemMenu, 0x00034dc0, None
        2375 (0x0947),  (0x), SetTaskmanWindow, 0x0002cf00, None
        *   2376 (0x0948),  (0x), SetThreadDesktop, 0x0002c210, None
        *   2377 (0x0949),  (0x), SetThreadDpiAwarenessContext, 0x00016c50, None
        *   2378 (0x094a),  (0x), SetThreadDpiHostingBehavior, 0x00089ed0, None
        2379 (0x094b),  (0x), SetThreadInputBlocked, 0x00034de0, None
        *   2380 (0x094c),  (0x), SetTimer, 0x00023d00, None
        *   2381 (0x094d),  (0x), SetUserObjectInformationA, 0x00089fc0, None
        *   2382 (0x094e),  (0x), SetUserObjectInformationW, 0x0008a040, None
        2383 (0x094f),  (0x), SetUserObjectSecurity, 0x0002c8f0, None
        2384 (0x0950),  (0x), SetWinEventHook, 0x000294f0, None
        2385 (0x0951),  (0x), SetWindowBand, 0x00034e00, None
        2386 (0x0952),  (0x), SetWindowCompositionAttribute, 0x00028ed0, None
        2387 (0x0953),  (0x), SetWindowCompositionTransition, 0x00034e10, None
        2388 (0x0954),  (0x), SetWindowContextHelpId, 0x0008a050, None
        *   2389 (0x0955),  (0x), SetWindowDisplayAffinity, 0x00034e20, None
        *   2390 (0x0956),  (0x), SetWindowFeedbackSetting, 0x00034e30, None
        *   2391 (0x0957),  (0x), SetWindowLongA, 0x0002c940, None
        *   2392 (0x0958),  (0x), SetWindowLongPtrA, 0x0002c9a0, None
        *   2393 (0x0959),  (0x), SetWindowLongPtrW, 0x0000b750, None
        *   2394 (0x095a),  (0x), SetWindowLongW, 0x00010ea0, None
        *   2395 (0x095b),  (0x), SetWindowPlacement, 0x00034e50, None
        *   2396 (0x095c),  (0x), SetWindowPos, 0x00034e60, None
        *   2397 (0x095d),  (0x), SetWindowRgn, 0x000145f0, None
        2398 (0x095e),  (0x), SetWindowRgnEx, 0x0007e160, None
        2399 (0x095f),  (0x), SetWindowStationUser, 0x0002c800, None
        *   2400 (0x0960),  (0x), SetWindowTextA, 0x0008d200, None
        *   2401 (0x0961),  (0x), SetWindowTextW, 0x000143e0, None
        2402 (0x0962),  (0x), SetWindowWord, 0x00034e80, None
        2403 (0x0963),  (0x), SetWindowsHookA, 0x0004fbb0, None
        *   2404 (0x0964),  (0x), SetWindowsHookExA, 0x0004fbd0, None
        2405 (0x0965),  (0x), SetWindowsHookExAW, 0x000359d0, None
        *   2406 (0x0966),  (0x), SetWindowsHookExW, 0x0002b3b0, None
        2407 (0x0967),  (0x), SetWindowsHookW, 0x0004fbf0, None
        *   2408 (0x0968),  (0x), ShowCaret, 0x00028f80, None
        *   2409 (0x0969),  (0x), ShowCursor, 0x00034e90, None
        *   2410 (0x096a),  (0x), ShowOwnedPopups, 0x000325d0, None
        *   2411 (0x096b),  (0x), ShowScrollBar, 0x00034ea0, None
        2412 (0x096c),  (0x), ShowStartGlass, 0x0008a070, None
        2413 (0x096d),  (0x), ShowSystemCursor, 0x00034eb0, None
        *   2414 (0x096e),  (0x), ShowWindow, 0x00034ec0, None
        *   2415 (0x096f),  (0x), ShowWindowAsync, 0x00034ed0, None
        *   2416 (0x0970),  (0x), ShutdownBlockReasonCreate, 0x0002a890, None
        *   2417 (0x0971),  (0x), ShutdownBlockReasonDestroy, 0x00034ee0, None
        *   2418 (0x0972),  (0x), ShutdownBlockReasonQuery, 0x00034ef0, None
        2419 (0x0973),  (0x), SignalRedirectionStartComplete, 0x00034f00, None
        *   2420 (0x0974),  (0x), SkipPointerFrameMessages, 0x00034f10, None
        2421 (0x0975),  (0x), SoftModalMessageBox, 0x0007c9d0, None
        *   2422 (0x0976),  (0x), SoundSentry, 0x00034f30, None
        *   2423 (0x0977),  (0x), SubtractRect, 0x0002a100, None
        *   2424 (0x0978),  (0x), SwapMouseButton, 0x0008a090, None
        *   2425 (0x0979),  (0x), SwitchDesktop, 0x0002cce0, None
        2426 (0x097a),  (0x), SwitchDesktopWithFade, 0x0002cf40, None
        *   2427 (0x097b),  (0x), SwitchToThisWindow, 0x00001c30, None
        *   2428 (0x097c),  (0x), SystemParametersInfoA, 0x00028bb0, None
        *   2429 (0x097d),  (0x), SystemParametersInfoForDpi, 0x000289f0, None
        *   2430 (0x097e),  (0x), SystemParametersInfoW, 0x00023340, None
        *   2431 (0x097f),  (0x), TabbedTextOutA, 0x00058710, None
        *   2432 (0x0980),  (0x), TabbedTextOutW, 0x00058840, None
        2433 (0x0981),  (0x), TileChildWindows, 0x0008a0b0, None
        *   2434 (0x0982),  (0x), TileWindows, 0x00079270, None
        *   2435 (0x0983),  (0x), ToAscii, 0x0008a0e0, None
        *   2436 (0x0984),  (0x), ToAsciiEx, 0x0008a160, None
        *   2437 (0x0985),  (0x), ToUnicode, 0x0007e1b0, None
        *   2438 (0x0986),  (0x), ToUnicodeEx, 0x00028960, None
        *   2439 (0x0987),  (0x), TrackMouseEvent, 0x00034f40, None
        *   2440 (0x0988),  (0x), TrackPopupMenu, 0x00079620, None
        *   2441 (0x0989),  (0x), TrackPopupMenuEx, 0x00034f50, None
        2442 (0x098a),  (0x), TranslateAccelerator, 0x0008a2e0, None
        *   2443 (0x098b),  (0x), TranslateAcceleratorA, 0x0008a2e0, None
        *   2444 (0x098c),  (0x), TranslateAcceleratorW, 0x00025d80, None
        *   2445 (0x098d),  (0x), TranslateMDISysAccel, 0x000792a0, None
        *   2446 (0x098e),  (0x), TranslateMessage, 0x00009390, None
        2447 (0x098f),  (0x), TranslateMessageEx, 0x00026a80, None
        2448 (0x0990),  (0x), UnhookWinEvent, 0x00034f70, None
        2449 (0x0991),  (0x), UnhookWindowsHook, 0x0008a370, None
        *   2450 (0x0992),  (0x), UnhookWindowsHookEx, 0x0002b310, None
        *   2451 (0x0993),  (0x), UnionRect, 0x00023d30, None
        *   2452 (0x0994),  (0x), UnloadKeyboardLayout, 0x0008a390, None
        2453 (0x0995),  (0x), UnlockWindowStation, 0x00034f80, None
        2454 (0x0996),  (0x), UnpackDDElParam, 0x0005a8e0, None
        *   2455 (0x0997),  (0x), UnregisterClassA, 0x00005510, None
        *   2456 (0x0998),  (0x), UnregisterClassW, 0x00007e60, None
        *   2457 (0x0999),  (0x), UnregisterDeviceNotification, 0x0002bf80, None
        *   2458 (0x099a),  (0x), UnregisterHotKey, 0x00034f90, None
        2459 (0x099b),  (0x), UnregisterMessagePumpHook, 0x00032190, None
        2460 (0x099c),  (0x), UnregisterPointerInputTarget, 0x00050cf0, None
        2461 (0x099d),  (0x), UnregisterPointerInputTargetEx, 0x00050750, None
        *   2462 (0x099e),  (0x), UnregisterPowerSettingNotification, 0x0002b940, None
        2463 (0x099f),  (0x), UnregisterSessionPort, 0x00034fa0, None
        *   2464 (0x09a0),  (0x), UnregisterSuspendResumeNotification, 0x0007e200, None
        2465 (0x09a1),  (0x), UnregisterTouchWindow, 0x0007e240, None
        2466 (0x09a2),  (0x), UnregisterUserApiHook, 0x00034fb0, None
        2467 (0x09a3),  (0x), UpdateDefaultDesktopThumbnail, 0x00034fc0, None
        *   2468 (0x09a4),  (0x), UpdateLayeredWindow, 0x00031420, None
        2469 (0x09a5),  (0x), UpdateLayeredWindowIndirect, 0x0002de60, None
        2470 (0x09a6),  (0x), UpdatePerUserSystemParameters, 0x0001c8e0, None
        *   2471 (0x09a7),  (0x), UpdateWindow, 0x000131f0, None
        2472 (0x09a8),  (0x), UpdateWindowInputSinkHints, 0x00034fd0, None
        2473 (0x09a9),  (0x), User32InitializeImmEntryTable, 0x00019600, None
        2474 (0x09aa),  (0x), UserClientDllInitialize, 0x00017f30, None
        2475 (0x09ab),  (0x), UserHandleGrantAccess, 0x00034ff0, None
        2476 (0x09ac),  (0x), UserLpkPSMTextOut, 0x00058890, None
        2477 (0x09ad),  (0x), UserLpkTabbedTextOut, 0x00058ad0, None
        2478 (0x09ae),  (0x), UserRealizePalette, 0x00030070, None
        2479 (0x09af),  (0x), UserRegisterWowHandlers, 0x0008a3d0, None
        2480 (0x09b0),  (0x), VRipOutput, 0x0002d020, None
        2481 (0x09b1),  (0x), VTagOutput, 0x0002d020, None
        *   2482 (0x09b2),  (0x), ValidateRect, 0x00035000, None
        *   2483 (0x09b3),  (0x), ValidateRgn, 0x00001e00, None
        *   2484 (0x09b4),  (0x), VkKeyScanA, 0x000866a0, None
        *   2485 (0x09b5),  (0x), VkKeyScanExA, 0x00086710, None
        *   2486 (0x09b6),  (0x), VkKeyScanExW, 0x00001660, None
        *   2487 (0x09b7),  (0x), VkKeyScanW, 0x0002bb60, None
        2488 (0x09b8),  (0x), WCSToMBEx, 0x00008d60, None
        2489 (0x09b9),  (0x), WINNLSEnableIME, 0x000868e0, None
        2490 (0x09ba),  (0x), WINNLSGetEnableStatus, 0x00086900, None
        2491 (0x09bb),  (0x), WINNLSGetIMEHotkey, 0x0002d020, None
        2492 (0x09bc),  (0x), WaitForInputIdle, 0x0002ca40, None
        2493 (0x09bd),  (0x), WaitForRedirectionStartComplete, 0x00035020, None
        *   2494 (0x09be),  (0x), WaitMessage, 0x00035030, None
        2495 (0x09bf),  (0x), WinHelpA, 0x00031540, None
        2496 (0x09c0),  (0x), WinHelpW, 0x00031490, None
        *   2497 (0x09c1),  (0x), WindowFromDC, 0x00035040, None
        *   2498 (0x09c2),  (0x), WindowFromPhysicalPoint, 0x00035050, None
        *   2499 (0x09c3),  (0x), WindowFromPoint, 0x00035060, None
        2500 (0x09c4),  (0x), _UserTestTokenForInteractive, 0x00082d00, None
        2501 (0x09c5),  (0x), gSharedInfo, 0x000b4030, None
        2502 (0x09c6),  (0x), gapfnScSendMessage, 0x00092990, None
        2503 (0x09c7),  (0x), DelegateInput, 0x00033cf0, None
        2504 (0x09c8),  (0x), UndelegateInput, 0x00034f60, None
        2505 (0x09c9),  (0x), HandleDelegatedInput, 0x00034480, None
        2506 (0x09ca),  (0x), Ordinal_2506, 0x0004f910, None
        2507 (0x09cb),  (0x), Ordinal_2507, 0x00034b10, None
        2508 (0x09cc),  (0x), Ordinal_2508, 0x000347d0, None
        2509 (0x09cd),  (0x), Ordinal_2509, 0x00033ad0, None
        2510 (0x09ce),  (0x), Ordinal_2510, 0x0002a860, None
        2511 (0x09cf),  (0x), Ordinal_2511, 0x00034c30, None
        2512 (0x09d0),  (0x), Ordinal_2512, 0x00034070, None
        2513 (0x09d1),  (0x), Ordinal_2513, 0x00034af0, None
        2514 (0x09d2),  (0x), Ordinal_2514, 0x00050c90, None
        2515 (0x09d3),  (0x), Ordinal_2515, 0x00050cd0, None
        2516 (0x09d4),  (0x), Ordinal_2516, 0x00033ce0, None
        2517 (0x09d5),  (0x), Ordinal_2517, 0x00034390, None
        2518 (0x09d6),  (0x), Ordinal_2518, 0x0001b0b0, None
        2519 (0x09d7),  (0x), Ordinal_2519, 0x00033e70, None
        2520 (0x09d8),  (0x), Ordinal_2520, 0x000345f0, None
        2521 (0x09d9),  (0x), GetProcessUIContextInformation, 0x000342b0, None
        2522 (0x09da),  (0x), Ordinal_2522, 0x00034b30, None
        2523 (0x09db),  (0x), Ordinal_2523, 0x000012e0, None
        2524 (0x09dc),  (0x), Ordinal_2524, 0x0004ee00, None
        2525 (0x09dd),  (0x), Ordinal_2525, 0x000217d0, None
        2526 (0x09de),  (0x), Ordinal_2526, 0x0004edd0, None
        2527 (0x09df),  (0x), Ordinal_2527, 0x00021810, None
        2528 (0x09e0),  (0x), IsThreadMessageQueueAttached, 0x00026230, None
        2529 (0x09e1),  (0x), Ordinal_2529, 0x00033d80, None
        2530 (0x09e2),  (0x), Ordinal_2530, 0x00035010, None
        2531 (0x09e3),  (0x), Ordinal_2531, 0x00034b40, None
        2532 (0x09e4),  (0x), Ordinal_2532, 0x00034c20, None
        2533 (0x09e5),  (0x), Ordinal_2533, 0x00033b70, None
        2534 (0x09e6),  (0x), Ordinal_2534, 0x00003450, None
        2535 (0x09e7),  (0x), Ordinal_2535, 0x00084a40, None
        2536 (0x09e8),  (0x), Ordinal_2536, 0x000091e0, None
        2537 (0x09e9),  (0x), Ordinal_2537, 0x00034ab0, None
        2538 (0x09ea),  (0x), Ordinal_2538, 0x00034680, None
        2539 (0x09eb),  (0x), Ordinal_2539, 0x00034490, None
        2540 (0x09ec),  (0x), Ordinal_2540, 0x00084c20, None
        2541 (0x09ed),  (0x), Ordinal_2541, 0x000342d0, None
        2542 (0x09ee),  (0x), Ordinal_2542, 0x00034a10, None
        *   2543 (0x09ef),  (0x), keybd_event, 0x0007e280, None
        2544 (0x09f0),  (0x), Ordinal_2544, 0x00033ec0, None
        2545 (0x09f1),  (0x), Ordinal_2545, 0x000341d0, None
        2546 (0x09f2),  (0x), Ordinal_2546, 0x00034a40, None
        *   2547 (0x09f3),  (0x), mouse_event, 0x0002bf20, None
        2548 (0x09f4),  (0x), Ordinal_2548, 0x000342a0, None
        2549 (0x09f5),  (0x), Ordinal_2549, 0x00034d50, None
        2550 (0x09f6),  (0x), Ordinal_2550, 0x00033c10, None
        2551 (0x09f7),  (0x), ReportInertia, 0x00001e60, None
        2552 (0x09f8),  (0x), Ordinal_2552, 0x00089d70, None
        2553 (0x09f9),  (0x), Ordinal_2553, 0x0008a260, None
        2554 (0x09fa),  (0x), Ordinal_2554, 0x00089ce0, None
        2555 (0x09fb),  (0x), Ordinal_2555, 0x000909d0, None
        2556 (0x09fc),  (0x), Ordinal_2556, 0x00034ae0, None
        2557 (0x09fd),  (0x), Ordinal_2557, 0x0002b1e0, None
        2558 (0x09fe),  (0x), Ordinal_2558, 0x00029f70, None
        2559 (0x09ff),  (0x), Ordinal_2559, 0x000341c0, None
        2560 (0x0a00),  (0x), Ordinal_2560, 0x00050780, None
        2561 (0x0a01),  (0x), Ordinal_2561, 0x0002cdb0, None
        2562 (0x0a02),  (0x), wsprintfA, 0x00027520, None
        2563 (0x0a03),  (0x), Ordinal_2563, 0x00033bd0, None
        2564 (0x0a04),  (0x), Ordinal_2564, 0x0002cdd0, None
        2565 (0x0a05),  (0x), Ordinal_2565, 0x0002c480, None
        2566 (0x0a06),  (0x), Ordinal_2566, 0x00034df0, None
        2567 (0x0a07),  (0x), Ordinal_2567, 0x0002cee0, None
        2568 (0x0a08),  (0x), Ordinal_2568, 0x0002c920, None
        2569 (0x0a09),  (0x), Ordinal_2569, 0x00027500, None
        2570 (0x0a0a),  (0x), Ordinal_2570, 0x00089f60, None
        2571 (0x0a0b),  (0x), SetCoreWindow, 0x00034b90, None
        2572 (0x0a0c),  (0x), Ordinal_2572, 0x00021c00, None
        2573 (0x0a0d),  (0x), Ordinal_2573, 0x00014440, None
        2574 (0x0a0e),  (0x), Ordinal_2574, 0x00010d10, None
        2575 (0x0a0f),  (0x), Ordinal_2575, 0x00089730, None
        2576 (0x0a10),  (0x), Ordinal_2576, 0x00034ba0, None
        2577 (0x0a11),  (0x), Ordinal_2577, 0x0002ccc0, None
        2578 (0x0a12),  (0x), Ordinal_2578, 0x00034730, None
        2579 (0x0a13),  (0x), Ordinal_2579, 0x00034e70, None
        2580 (0x0a14),  (0x), wsprintfW, 0x00029b00, None
        2581 (0x0a15),  (0x), Ordinal_2581, 0x0002c3d0, None
        2582 (0x0a16),  (0x), Ordinal_2582, 0x00027170, None
        2583 (0x0a17),  (0x), wvsprintfA, 0x00027550, None
        2584 (0x0a18),  (0x), Ordinal_2584, 0x000896a0, None
        2585 (0x0a19),  (0x), Ordinal_2585, 0x00034fe0, None
        2586 (0x0a1a),  (0x), Ordinal_2586, 0x00034c90, None
        2587 (0x0a1b),  (0x), Ordinal_2587, 0x000222f0, None
        2588 (0x0a1c),  (0x), Ordinal_2588, 0x00033ae0, None
        2589 (0x0a1d),  (0x), Ordinal_2589, 0x00034110, None
        2590 (0x0a1e),  (0x), Ordinal_2590, 0x00034100, None
        2591 (0x0a1f),  (0x), Ordinal_2591, 0x00034ad0, None
        2592 (0x0a20),  (0x), Ordinal_2592, 0x00034ca0, None
        2593 (0x0a21),  (0x), Ordinal_2593, 0x000345a0, None
        2594 (0x0a22),  (0x), Ordinal_2594, 0x00034cb0, None
        2595 (0x0a23),  (0x), Ordinal_2595, 0x00034d60, None
        2596 (0x0a24),  (0x), wvsprintfW, 0x00029b30, None
        2597 (0x0a25),  (0x), Ordinal_2597, 0x0002a2a0, None
        2598 (0x0a26),  (0x), Ordinal_2598, 0x00052150, None
        2599 (0x0a27),  (0x), Ordinal_2599, 0x000269a0, None
        2600 (0x0a28),  (0x), Ordinal_2600, 0x00001e40, None
        2606 (0x0a2e),  (0x), Ordinal_2606, 0x00033eb0, None
        2608 (0x0a30),  (0x), Ordinal_2608, 0x000347c0, None
        2609 (0x0a31),  (0x), Ordinal_2609, 0x00034120, None
        2610 (0x0a32),  (0x), Ordinal_2610, 0x00033c20, None
        2611 (0x0a33),  (0x), Ordinal_2611, 0x00033ef0, None
        2612 (0x0a34),  (0x), Ordinal_2612, 0x0002bb40, None
        2613 (0x0a35),  (0x), Ordinal_2613, 0x00023e70, None
        2614 (0x0a36),  (0x), Ordinal_2614, 0x00034320, None
        2615 (0x0a37),  (0x), Ordinal_2615, 0x00033ea0, None
        2616 (0x0a38),  (0x), Ordinal_2616, 0x00033b10, None
        2617 (0x0a39),  (0x), Ordinal_2617, 0x00034620, None
        2618 (0x0a3a),  (0x), Ordinal_2618, 0x0008ea70, None
        2619 (0x0a3b),  (0x), Ordinal_2619, 0x0002c780, None
        2620 (0x0a3c),  (0x), Ordinal_2620, 0x0008e800, None
        2621 (0x0a3d),  (0x), Ordinal_2621, 0x00033c50, None
        2622 (0x0a3e),  (0x), Ordinal_2622, 0x00034dd0, None
        2626 (0x0a42),  (0x), Ordinal_2626, 0x00034a80, None
        2627 (0x0a43),  (0x), Ordinal_2627, 0x00034b20, None
        2628 (0x0a44),  (0x), Ordinal_2628, 0x00033cc0, None
        2629 (0x0a45),  (0x), Ordinal_2629, 0x00033d10, None
        2630 (0x0a46),  (0x), Ordinal_2630, 0x00034420, None
        2631 (0x0a47),  (0x), Ordinal_2631, 0x00033ee0, None
        2632 (0x0a48),  (0x), Ordinal_2632, 0x00034e40, None
        2633 (0x0a49),  (0x), Ordinal_2633, 0x00033ca0, None
        2634 (0x0a4a),  (0x), Ordinal_2634, 0x00089eb0, None
        2635 (0x0a4b),  (0x), Ordinal_2635, 0x000102b0, None
        2636 (0x0a4c),  (0x), Ordinal_2636, 0x000297a0, None
        2637 (0x0a4d),  (0x), Ordinal_2637, 0x00034da0, None
        2638 (0x0a4e),  (0x), Ordinal_2638, 0x00033c40, None
        2639 (0x0a4f),  (0x), Ordinal_2639, 0x00034bc0, None
        2640 (0x0a50),  (0x), Ordinal_2640, 0x000880e0, None
        2641 (0x0a51),  (0x), Ordinal_2641, 0x00088280, None
        2642 (0x0a52),  (0x), Ordinal_2642, 0x00033f60, None
        2643 (0x0a53),  (0x), Ordinal_2643, 0x00034aa0, None
        2644 (0x0a54),  (0x), Ordinal_2644, 0x00033cd0, None
        2645 (0x0a55),  (0x), Ordinal_2645, 0x000883e0, None
        2646 (0x0a56),  (0x), Ordinal_2646, 0x000347e0, None
        2647 (0x0a57),  (0x), Ordinal_2647, 0x00033c30, None
        2648 (0x0a58),  (0x), Ordinal_2648, 0x00033d30, None
        2649 (0x0a59),  (0x), Ordinal_2649, 0x00034c60, None
        2650 (0x0a5a),  (0x), Ordinal_2650, 0x000340e0, None
        2651 (0x0a5b),  (0x), Ordinal_2651, 0x00033db0, None
        2652 (0x0a5c),  (0x), Ordinal_2652, 0x000343a0, None
        2653 (0x0a5d),  (0x), Ordinal_2653, 0x00034280, None
        2654 (0x0a5e),  (0x), Ordinal_2654, 0x00033c90, None
        2655 (0x0a5f),  (0x), Ordinal_2655, 0x00033d20, None
        2656 (0x0a60),  (0x), Ordinal_2656, 0x00033e60, None
        2657 (0x0a61),  (0x), Ordinal_2657, 0x00034d70, None
        2658 (0x0a62),  (0x), Ordinal_2658, 0x00034bf0, None
        2659 (0x0a63),  (0x), Ordinal_2659, 0x0002d010, None
        2700 (0x0a8c),  (0x), Ordinal_2700, 0x00032000, None
        2702 (0x0a8e),  (0x), Ordinal_2702, 0x000795a0, None
        2703 (0x0a8f),  (0x), Ordinal_2703, 0x00034600, None
        2704 (0x0a90),  (0x), Ordinal_2704, 0x00033e40, None
        2705 (0x0a91),  (0x), Ordinal_2705, 0x000345d0, None
        2706 (0x0a92),  (0x), Ordinal_2706, 0x00034650, None
        2707 (0x0a93),  (0x), Ordinal_2707, 0x00023500, None
        2708 (0x0a94),  (0x), Ordinal_2708, 0x00033b40, None
        2709 (0x0a95),  (0x), Ordinal_2709, 0x00033ed0, None
        2710 (0x0a96),  (0x), Ordinal_2710, 0x00034660, None
        2711 (0x0a97),  (0x), Ordinal_2711, 0x00033f80, None
        2712 (0x0a98),  (0x), Ordinal_2712, 0x0001dea0, None
        2713 (0x0a99),  (0x), Ordinal_2713, 0x0002c8b0, None
        2714 (0x0a9a),  (0x), Ordinal_2714, 0x00031fb0, None
        2715 (0x0a9b),  (0x), Ordinal_2715, 0x000346c0, None
        2716 (0x0a9c),  (0x), Ordinal_2716, 0x00034780, None

         */

    }
}
