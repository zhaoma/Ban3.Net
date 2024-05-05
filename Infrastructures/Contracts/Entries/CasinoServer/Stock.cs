//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino标的
/// </summary>
public class Stock
{
    /// <summary>
    /// 代码
    /// 600001_SH
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 600001
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
