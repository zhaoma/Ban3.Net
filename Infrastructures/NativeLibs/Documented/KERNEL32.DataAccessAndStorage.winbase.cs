using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// winbase.h This header is used by multiple technologies.
    /// This file is Data Access and Storage parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-checknamelegaldos8dot3a
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         
        130 (0x0082),  (0x), CheckNameLegalDOS8Dot3A, 0x00039ab0, None
        131 (0x0083),  (0x), CheckNameLegalDOS8Dot3W, 0x00039b60, None
         
        171 (0x00ab),  (0x), CopyFile2, 0x0003afc0, None
        172 (0x00ac),  (0x), CopyFileA, 0x00062580, None
        173 (0x00ad),  (0x), CopyFileExA, 0x00062630, None
        174 (0x00ae),  (0x), CopyFileExW, 0x00020e80, None
        175 (0x00af),  (0x), CopyFileTransactedA, 0x000626f0, None
        176 (0x00b0),  (0x), CopyFileTransactedW, 0x000627e0, None
        177 (0x00b1),  (0x), CopyFileW, 0x00025990, None
        178 (0x00b2),  (0x), CopyLZFile, 0x00038110, None
         
        185 (0x00b9),  (0x), CreateDirectoryA, 0x000252e0, None
        186 (0x00ba),  (0x), CreateDirectoryExA, 0x00063210, None
        187 (0x00bb),  (0x), CreateDirectoryExW, 0x0003afe0, None
        188 (0x00bc),  (0x), CreateDirectoryTransactedA, 0x00038470, None
        189 (0x00bd),  (0x), CreateDirectoryTransactedW, 0x000632a0, None
        190 (0x00be),  (0x), CreateDirectoryW, 0x000252f0, None
         
        198 (0x00c6),  (0x), CreateFile2, 0x00025300, None
        199 (0x00c7),  (0x), CreateFileA, 0x00025310, None
        200 (0x00c8),  (0x), CreateFileMappingA, 0x0001c470, None
        202 (0x00ca),  (0x), CreateFileMappingNumaA, 0x00063450, None
        205 (0x00cd),  (0x), CreateFileTransactedA, 0x000628e0, None
        206 (0x00ce),  (0x), CreateFileTransactedW, 0x000629a0, None
        207 (0x00cf),  (0x), CreateFileW, 0x00025320, None
        208 (0x00d0),  (0x), CreateHardLinkA, 0x0003b020, None
        209 (0x00d1),  (0x), CreateHardLinkTransactedA, 0x00043ed0, None
        210 (0x00d2),  (0x), CreateHardLinkTransactedW, 0x00063520, None
        211 (0x00d3),  (0x), CreateHardLinkW, 0x0003b040, None
         
        241 (0x00f1),  (0x), CreateSymbolicLinkA, 0x00063af0, None
        242 (0x00f2),  (0x), CreateSymbolicLinkTransactedA, 0x00063bb0, None
        243 (0x00f3),  (0x), CreateSymbolicLinkTransactedW, 0x00063c70, None
        244 (0x00f4),  (0x), CreateSymbolicLinkW, 0x0003b230, None
         
        279 (0x0117),  (0x), DeleteFileA, 0x00025340, None
        280 (0x0118),  (0x), DeleteFileTransactedA, 0x00063d50, None
        281 (0x0119),  (0x), DeleteFileTransactedW, 0x00024930, None
        282 (0x011a),  (0x), DeleteFileW, 0x00025350, None
        
        387 (0x0183),  (0x), FindFirstFileA, 0x000253c0, None
        388 (0x0184),  (0x), FindFirstFileExA, 0x000253d0, None
        389 (0x0185),  (0x), FindFirstFileExW, 0x000253e0, None
        390 (0x0186),  (0x), FindFirstFileNameTransactedW, 0x00038570, None
        391 (0x0187),  (0x), FindFirstFileNameW, 0x000253f0, None
        392 (0x0188),  (0x), FindFirstFileTransactedA, 0x00038650, None
        393 (0x0189),  (0x), FindFirstFileTransactedW, 0x00066ef0, None
        394 (0x018a),  (0x), FindFirstFileW, 0x00025400, None
        395 (0x018b),  (0x), FindFirstStreamTransactedW, 0x00038740, None
        396 (0x018c),  (0x), FindFirstStreamW, api-ms-win-core-file-l1-2-2.FindFirstStreamW, None
        397 (0x018d),  (0x), FindFirstVolumeA, 0x00065710, None
        398 (0x018e),  (0x), FindFirstVolumeMountPointA, 0x000658b0, None
        399 (0x018f),  (0x), FindFirstVolumeMountPointW, 0x00065aa0, None
        400 (0x0190),  (0x), FindFirstVolumeW, 0x00025410, None
        
        404 (0x0194),  (0x), FindNextFileA, 0x00025430, None
        405 (0x0195),  (0x), FindNextFileNameW, 0x00025440, None
        406 (0x0196),  (0x), FindNextFileW, 0x00025450, None
        407 (0x0197),  (0x), FindNextStreamW, api-ms-win-core-file-l1-2-2.FindNextStreamW, None
        408 (0x0198),  (0x), FindNextVolumeA, 0x00065d30, None
        409 (0x0199),  (0x), FindNextVolumeMountPointA, 0x00065ed0, None
        410 (0x019a),  (0x), FindNextVolumeMountPointW, 0x000665c0, None
        411 (0x019b),  (0x), FindNextVolumeW, 0x00025460, None
        
        456 (0x01c8),  (0x), GetBinaryType, 0x000615f0, None
        457 (0x01c9),  (0x), GetBinaryTypeA, 0x000615f0, None
        458 (0x01ca),  (0x), GetBinaryTypeW, 0x00061640, None
        482 (0x01e2),  (0x), GetCompressedFileSizeA, 0x0003b710, None
        483 (0x01e3),  (0x), GetCompressedFileSizeTransactedA, 0x00063da0, None
        484 (0x01e4),  (0x), GetCompressedFileSizeTransactedW, 0x00063e00, None
        485 (0x01e5),  (0x), GetCompressedFileSizeW, 0x0003b730, None
        
        587 (0x024b),  (0x), GetFileAttributesA, 0x000254f0, None
        588 (0x024c),  (0x), GetFileAttributesExA, 0x00025500, None
        589 (0x024d),  (0x), GetFileAttributesExW, 0x00025510, None
        590 (0x024e),  (0x), GetFileAttributesTransactedA, 0x00063ed0, None
        591 (0x024f),  (0x), GetFileAttributesTransactedW, 0x00063f40, None
        592 (0x0250),  (0x), GetFileAttributesW, 0x00025520, None
        593 (0x0251),  (0x), GetFileBandwidthReservation, 0x00038820, None
        594 (0x0252),  (0x), GetFileInformationByHandle, 0x00025530, None
        595 (0x0253),  (0x), GetFileInformationByHandleEx, 0x0001fe10, None
        
        609 (0x0261),  (0x), GetFullPathNameA, 0x000255a0, None
        610 (0x0262),  (0x), GetFullPathNameTransactedA, 0x00038230, None
        611 (0x0263),  (0x), GetFullPathNameTransactedW, 0x00067dd0, None
        612 (0x0264),  (0x), GetFullPathNameW, 0x000255b0, None
        
        624 (0x0270),  (0x), GetLogicalDriveStringsA, 0x000184d0, None
        625 (0x0271),  (0x), GetLogicalDriveStringsW, 0x000255c0, None
        626 (0x0272),  (0x), GetLogicalDrives, 0x00018590, None
        
        629 (0x0275),  (0x), GetLongPathNameA, 0x0005a310, None
        630 (0x0276),  (0x), GetLongPathNameTransactedA, 0x00041390, None
        631 (0x0277),  (0x), GetLongPathNameTransactedW, 0x000619c0, None
        632 (0x0278),  (0x), GetLongPathNameW, 0x000068c0, None
        727 (0x02d7),  (0x), GetShortPathNameA, 0x00061a90, None
        728 (0x02d8),  (0x), GetShortPathNameW, 0x00006400, None
        
        766 (0x02fe),  (0x), GetTempFileNameA, 0x000255d0, None
        767 (0x02ff),  (0x), GetTempFileNameW, 0x000255e0, NoneNone
        812 (0x032c),  (0x), GetVolumeNameForVolumeMountPointA, 0x00024790, None
        813 (0x032d),  (0x), GetVolumeNameForVolumeMountPointW, 0x00025030, None
        814 (0x032e),  (0x), GetVolumePathNameA, 0x00066650, None
        815 (0x032f),  (0x), GetVolumePathNameW, 0x00025640, None
        816 (0x0330),  (0x), GetVolumePathNamesForVolumeNameA, 0x00066830, None
        817 (0x0331),  (0x), GetVolumePathNamesForVolumeNameW, 0x00025650, None
        
        1006 (0x03ee),  (0x), MoveFileA, 0x00064020, None
        1007 (0x03ef),  (0x), MoveFileExA, 0x00064050, None
        1008 (0x03f0),  (0x), MoveFileExW, 0x00021450, None
        1009 (0x03f1),  (0x), MoveFileTransactedA, 0x00064080, None
        1010 (0x03f2),  (0x), MoveFileTransactedW, 0x00024570, None
        1011 (0x03f3),  (0x), MoveFileW, 0x00023050, None
        1012 (0x03f4),  (0x), MoveFileWithProgressA, 0x00064160, None
        1013 (0x03f5),  (0x), MoveFileWithProgressW, 0x0003c1b0, None

        1032 (0x0408),  (0x), OpenFile, 0x00062b50, None
        1033 (0x0409),  (0x), OpenFileById, 0x0003c260, None
        1098 (0x044a),  (0x), QueryDosDeviceA, 0x000654c0, None
        1099 (0x044b),  (0x), QueryDosDeviceW, 0x00025690, None
        
        1144 (0x0478),  (0x), ReadDirectoryChangesExW, 0x0003c4e0, None
        1145 (0x0479),  (0x), ReadDirectoryChangesW, 0x00024a70, None
        1213 (0x04bd),  (0x), RemoveDirectoryA, 0x000256d0, None
        1214 (0x04be),  (0x), RemoveDirectoryTransactedA, 0x00038520, None
        1215 (0x04bf),  (0x), RemoveDirectoryTransactedW, 0x00063390, None
        1216 (0x04c0),  (0x), RemoveDirectoryW, 0x000256e0, None

        1223 (0x04c7),  (0x), ReplaceFile, 0x0003cb40, None
        1224 (0x04c8),  (0x), ReplaceFileA, 0x000630d0, None
        1225 (0x04c9),  (0x), ReplaceFileW, 0x0003cb40, None
        1305 (0x0519),  (0x), SetCurrentDirectoryA, 0x0003cd70, None
        1306 (0x051a),  (0x), SetCurrentDirectoryW, 0x00021b20, None
        
        1323 (0x052b),  (0x), SetFileAttributesA, 0x00025700, None
        1324 (0x052c),  (0x), SetFileAttributesTransactedA, 0x00064730, None
        1325 (0x052d),  (0x), SetFileAttributesTransactedW, 0x00064790, None
        1326 (0x052e),  (0x), SetFileAttributesW, 0x00025710, None
        1327 (0x052f),  (0x), SetFileBandwidthReservation, 0x000388d0, None
        1328 (0x0530),  (0x), SetFileCompletionNotificationModes, 0x0001e700, None
        
        1333 (0x0535),  (0x), SetFileShortNameA, 0x00038a10, None
        1334 (0x0536),  (0x), SetFileShortNameW, 0x00038a60, None
        1371 (0x055b),  (0x), SetSearchPathMode, 0x00039620, None
        1412 (0x0584),  (0x), SetVolumeLabelA, 0x00067ec0, None
        1413 (0x0585),  (0x), SetVolumeLabelW, 0x00067f70, None
        1414 (0x0586),  (0x), SetVolumeMountPointA, 0x00066a40, None
        1415 (0x0587),  (0x), SetVolumeMountPointW, 0x00023b80, None
        1416 (0x0588),  (0x), SetVolumeMountPointWStub, 0x0003cfb0, None

         */


    }
}
