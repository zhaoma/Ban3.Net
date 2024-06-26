﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// unit:bps
    /// </summary>
    public enum BaudRate:uint
    {
        CBR_110=110,
        CBR_300=300,
        CBR_600=600,
        CBR_1200 = 1200,
        CBR_2400 = 2400,
        CBR_4800 = 4800,
        CBR_9600 = 9600,
        CBR_14400 = 14400,
        CBR_19200 = 19200,
        CBR_38400 = 38400,
        CBR_57600 = 57600,
        CBR_115200 = 115200,
        CBR_128000 = 128000,
        CBR_25600 = 256000
    }
}
