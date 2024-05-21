//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Response.CalendarServer;

public class Pack<T> : IZero
{
    /// <summary>
    /// 下页链接(令牌)
    /// </summary>
    public string? Next { get; set; }

    /// <summary>
    /// 时间数据包
    /// </summary>
    public List<T>? Data { get; set; }
}
