using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// The following functions are used to access a console.
    /// https://learn.microsoft.com/en-us/windows/console/console-functions
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         
        7 (0x0007),  (0x), AddConsoleAliasA, 0x00025e00, None
        8 (0x0008),  (0x), AddConsoleAliasW, 0x00025e10, None
        22 (0x0016),  (0x), AllocConsole, 0x00025a50, None
        38 (0x0026),  (0x), AttachConsole, 0x00025a60, None
        142 (0x008e),  (0x), ClosePseudoConsole, 0x00025a70, None
        184 (0x00b8),  (0x), CreateConsoleScreenBuffer, 0x00025b90, None
        234 (0x00ea),  (0x), CreatePseudoConsole, 0x00025a80, None
        373 (0x0175),  (0x), FillConsoleOutputAttribute, 0x00025ba0, None
        374 (0x0176),  (0x), FillConsoleOutputCharacterA, 0x00025bb0, None
        375 (0x0177),  (0x), FillConsoleOutputCharacterW, 0x00025bc0, None
        424 (0x01a8),  (0x), FlushConsoleInputBuffer, 0x00025bd0, None
        434 (0x01b2),  (0x), FreeConsole, 0x00025a90, None
        443 (0x01bb),  (0x), GenerateConsoleCtrlEvent, 0x00025be0, None
        490 (0x01ea),  (0x), GetConsoleAliasA, 0x00025e40, None
        491 (0x01eb),  (0x), GetConsoleAliasExesA, 0x00025e50, None
        492 (0x01ec),  (0x), GetConsoleAliasExesLengthA, 0x00025e60, None
        493 (0x01ed),  (0x), GetConsoleAliasExesLengthW, 0x00025e70, None
        494 (0x01ee),  (0x), GetConsoleAliasExesW, 0x00025e80, None
        495 (0x01ef),  (0x), GetConsoleAliasW, 0x00025e90, None
        496 (0x01f0),  (0x), GetConsoleAliasesA, 0x00025ea0, None
        497 (0x01f1),  (0x), GetConsoleAliasesLengthA, 0x00025eb0, None
        498 (0x01f2),  (0x), GetConsoleAliasesLengthW, 0x00025ec0, None
        499 (0x01f3),  (0x), GetConsoleAliasesW, 0x00025ed0, None
        500 (0x01f4),  (0x), GetConsoleCP, 0x00025aa0, None
        501 (0x01f5),  (0x), GetConsoleCharType, 0x0006a720, None
        502 (0x01f6),  (0x), GetConsoleCommandHistoryA, 0x00025ee0, None
        503 (0x01f7),  (0x), GetConsoleCommandHistoryLengthA, 0x00025ef0, None
        504 (0x01f8),  (0x), GetConsoleCommandHistoryLengthW, 0x00025f00, None
        505 (0x01f9),  (0x), GetConsoleCommandHistoryW, 0x00025f10, None
        506 (0x01fa),  (0x), GetConsoleCursorInfo, 0x00025bf0, None
        507 (0x01fb),  (0x), GetConsoleCursorMode, 0x0006a790, None
        508 (0x01fc),  (0x), GetConsoleDisplayMode, 0x00025f20, None
        509 (0x01fd),  (0x), GetConsoleFontInfo, 0x0006ab00, None
        510 (0x01fe),  (0x), GetConsoleFontSize, 0x00025f30, None
        511 (0x01ff),  (0x), GetConsoleHardwareState, 0x0006a270, None
        512 (0x0200),  (0x), GetConsoleHistoryInfo, 0x00025f40, None
        513 (0x0201),  (0x), GetConsoleInputExeNameA, kernelbase.GetConsoleInputExeNameA, None
        514 (0x0202),  (0x), GetConsoleInputExeNameW, kernelbase.GetConsoleInputExeNameW, None
        515 (0x0203),  (0x), GetConsoleInputWaitHandle, 0x0006a190, None
        516 (0x0204),  (0x), GetConsoleKeyboardLayoutNameA, 0x0006abb0, None
        517 (0x0205),  (0x), GetConsoleKeyboardLayoutNameW, 0x0006abd0, None
        518 (0x0206),  (0x), GetConsoleMode, 0x00025ab0, None
        519 (0x0207),  (0x), GetConsoleNlsMode, 0x0006a810, None
        520 (0x0208),  (0x), GetConsoleOriginalTitleA, 0x00025c00, None
        521 (0x0209),  (0x), GetConsoleOriginalTitleW, 0x00025c10, None
        522 (0x020a),  (0x), GetConsoleOutputCP, 0x00025ac0, None
        523 (0x020b),  (0x), GetConsoleProcessList, 0x00025f50, None
        524 (0x020c),  (0x), GetConsoleScreenBufferInfo, 0x00025c20, None
        525 (0x020d),  (0x), GetConsoleScreenBufferInfoEx, 0x00025c30, None
        526 (0x020e),  (0x), GetConsoleSelectionInfo, 0x00025f60, None
        527 (0x020f),  (0x), GetConsoleTitleA, 0x00025c40, None
        528 (0x0210),  (0x), GetConsoleTitleW, 0x00025c50, None
        529 (0x0211),  (0x), GetConsoleWindow, 0x00025f70, None
        536 (0x0218),  (0x), GetCurrentConsoleFont, 0x00025f80, None
        537 (0x0219),  (0x), GetCurrentConsoleFontEx, 0x00025f90, None
        618 (0x026a),  (0x), GetLargestConsoleWindowSize, 0x00025c60, None
        671 (0x029f),  (0x), GetNumberOfConsoleFonts, 0x0006ac80, None
        672 (0x02a0),  (0x), GetNumberOfConsoleInputEvents, 0x00025ad0, None
        673 (0x02a1),  (0x), GetNumberOfConsoleMouseButtons, 0x00025fa0, None
        733 (0x02dd),  (0x), GetStdHandle, 0x0001dc50, None
        1062 (0x0426),  (0x), PeekConsoleInputA, 0x00025ae0, None
        1063 (0x0427),  (0x), PeekConsoleInputW, 0x00025af0, None
        1133 (0x046d),  (0x), ReadConsoleA, 0x00025b00, None
        1134 (0x046e),  (0x), ReadConsoleInputA, 0x00025b10, None
        1135 (0x046f),  (0x), ReadConsoleInputExA, kernelbase.ReadConsoleInputExA, None
        1136 (0x0470),  (0x), ReadConsoleInputExW, kernelbase.ReadConsoleInputExW, None
        1137 (0x0471),  (0x), ReadConsoleInputW, 0x00025b20, None
        1138 (0x0472),  (0x), ReadConsoleOutputA, 0x00025c70, None
        1139 (0x0473),  (0x), ReadConsoleOutputAttribute, 0x00025c80, None
        1140 (0x0474),  (0x), ReadConsoleOutputCharacterA, 0x00025c90, None
        1141 (0x0475),  (0x), ReadConsoleOutputCharacterW, 0x00025ca0, None
        1142 (0x0476),  (0x), ReadConsoleOutputW, 0x00025cb0, None
        1143 (0x0477),  (0x), ReadConsoleW, 0x00025b30, None
        1231 (0x04cf),  (0x), ResizePseudoConsole, 0x00025b40, None
        1254 (0x04e6),  (0x), ScrollConsoleScreenBufferA, 0x00025cc0, None
        1255 (0x04e7),  (0x), ScrollConsoleScreenBufferW, 0x00025cd0, None
        1272 (0x04f8),  (0x), SetConsoleActiveScreenBuffer, 0x00025ce0, None
        1273 (0x04f9),  (0x), SetConsoleCP, 0x00025cf0, None
        1274 (0x04fa),  (0x), SetConsoleCtrlHandler, 0x00025b50, None
        1275 (0x04fb),  (0x), SetConsoleCursor, 0x0006a3a0, None
        1276 (0x04fc),  (0x), SetConsoleCursorInfo, 0x00025d00, None
        1277 (0x04fd),  (0x), SetConsoleCursorMode, 0x0006a910, None
        1278 (0x04fe),  (0x), SetConsoleCursorPosition, 0x00025d10, None
        1279 (0x04ff),  (0x), SetConsoleDisplayMode, 0x00025fb0, None
        1280 (0x0500),  (0x), SetConsoleFont, 0x0006ace0, None
        1281 (0x0501),  (0x), SetConsoleHardwareState, 0x0006a400, None
        1282 (0x0502),  (0x), SetConsoleHistoryInfo, 0x00025fc0, None
        1283 (0x0503),  (0x), SetConsoleIcon, 0x0006ad40, None
        1284 (0x0504),  (0x), SetConsoleInputExeNameA, kernelbase.SetConsoleInputExeNameA, None
        1285 (0x0505),  (0x), SetConsoleInputExeNameW, kernelbase.SetConsoleInputExeNameW, None
        1286 (0x0506),  (0x), SetConsoleKeyShortcuts, 0x0006a460, None
        1287 (0x0507),  (0x), SetConsoleLocalEUDC, 0x0006a980, None
        1288 (0x0508),  (0x), SetConsoleMaximumWindowSize, 0x00021ba0, None
        1289 (0x0509),  (0x), SetConsoleMenuClose, 0x0006a4f0, None
        1290 (0x050a),  (0x), SetConsoleMode, 0x00025b60, None
        1291 (0x050b),  (0x), SetConsoleNlsMode, 0x0006aa40, None
        1292 (0x050c),  (0x), SetConsoleNumberOfCommandsA, 0x00025fd0, None
        1293 (0x050d),  (0x), SetConsoleNumberOfCommandsW, 0x00025fe0, None
        1294 (0x050e),  (0x), SetConsoleOS2OemFormat, 0x0006aaa0, None
        1295 (0x050f),  (0x), SetConsoleOutputCP, 0x00025d20, None
        1296 (0x0510),  (0x), SetConsolePalette, 0x0006a550, None
        1297 (0x0511),  (0x), SetConsoleScreenBufferInfoEx, 0x00025d30, None
        1298 (0x0512),  (0x), SetConsoleScreenBufferSize, 0x00025d40, None
        1299 (0x0513),  (0x), SetConsoleTextAttribute, 0x00025d50, None
        1300 (0x0514),  (0x), SetConsoleTitleA, 0x00025d60, None
        1301 (0x0515),  (0x), SetConsoleTitleW, 0x00025d70, None
        1302 (0x0516),  (0x), SetConsoleWindowInfo, 0x00025d80, None
        1304 (0x0518),  (0x), SetCurrentConsoleFontEx, 0x00025ff0, None
        1372 (0x055c),  (0x), SetStdHandle, 0x000209d0, None
        1373 (0x055d),  (0x), SetStdHandleEx, 0x0003ceb0, None
        1563 (0x061b),  (0x), WriteConsoleA, 0x00025b70, None
        1564 (0x061c),  (0x), WriteConsoleInputA, 0x00025d90, None
        1565 (0x061d),  (0x), WriteConsoleInputVDMA, 0x0006a600, None
        1566 (0x061e),  (0x), WriteConsoleInputVDMW, 0x0006a690, None
        1567 (0x061f),  (0x), WriteConsoleInputW, 0x00025da0, None
        1568 (0x0620),  (0x), WriteConsoleOutputA, 0x00025db0, None
        1569 (0x0621),  (0x), WriteConsoleOutputAttribute, 0x00025dc0, None
        1570 (0x0622),  (0x), WriteConsoleOutputCharacterA, 0x00025dd0, None
        1571 (0x0623),  (0x), WriteConsoleOutputCharacterW, 0x00025de0, None
        1572 (0x0624),  (0x), WriteConsoleOutputW, 0x00025df0, None
        1573 (0x0625),  (0x), WriteConsoleW, 0x00025b80, None
         
         */


        /// <summary>
        /// AddConsoleAliasA;AddConsoleAliasW
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        /// <param name="ExeName"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        public static extern bool AddConsole(
            string Source,
            string Target,
            string ExeName);


        /// <summary>
        /// AllocConsole
        /// </summary>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        /// <summary>
        /// AttachConsole
        /// </summary>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        [DllImport(Dll, SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);


    }
}
