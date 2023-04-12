using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Documented
{
    /// <summary>
    /// fileapi.h This header is used by multiple technologies.
    ///     Data Access and Storage
    ///     System Services
    /// This file is Data Access and Storage parts.
    /// https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-arefileapisansi
    /// </summary>
    public static partial class KERNEL32
    {
        /*
         *
        36 (0x0024),  (0x), AreFileApisANSI, 0x000213b0, None
        561 (0x0231),  (0x), GetDiskFreeSpaceA, 0x00025490, None
        562 (0x0232),  (0x), GetDiskFreeSpaceExA, 0x000254a0, None
        563 (0x0233),  (0x), GetDiskFreeSpaceExW, 0x000254b0, None
        564 (0x0234),  (0x), GetDiskFreeSpaceW, 0x000254c0, None
        565 (0x0235),  (0x), GetDiskSpaceInformationA, api-ms-win-core-file-l1-2-3.GetDiskSpaceInformationA, None
        566 (0x0236),  (0x), GetDiskSpaceInformationW, api-ms-win-core-file-l1-2-3.GetDiskSpaceInformationW, None
        569 (0x0239),  (0x), GetDriveTypeA, 0x000254d0, None
        570 (0x023a),  (0x), GetDriveTypeW, 0x000254e0, None
        598 (0x0256),  (0x), GetFileSize, 0x00025540, None
        599 (0x0257),  (0x), GetFileSizeEx, 0x00025550, None
        600 (0x0258),  (0x), GetFileTime, 0x00025560, None
        601 (0x0259),  (0x), GetFileType, 0x00025570, None
        768 (0x0300),  (0x), GetTempPathA, 0x000255f0, None
        769 (0x0301),  (0x), GetTempPathW, 0x00025600, None
        809 (0x0329),  (0x), GetVolumeInformationA, 0x00025610, None
        810 (0x032a),  (0x), GetVolumeInformationByHandleW, 0x00025620, None
        811 (0x032b),  (0x), GetVolumeInformationW, 0x00025630, None
        1574 (0x0626),  (0x), WriteFile, 0x00025790, None
        1575 (0x0627),  (0x), WriteFileEx, 0x000257a0, None
        1576 (0x0628),  (0x), WriteFileGather, 0x000257b0, None
         *
         *
         */


        /// <summary>
        /// AreFileApisANSI
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", ExactSpelling = true)]
        static extern bool AreFileApisANSI();

    }
}
