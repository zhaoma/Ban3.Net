// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ban3.Infrastructures.Common.Extensions;

/// <summary>
/// 文件相关扩展方法
/// </summary>
public static partial class Helper
{
    public static async Task<string> ReadAsync( this string filePath )
    {
        return await File.ReadAllTextAsync( filePath );
    }
}