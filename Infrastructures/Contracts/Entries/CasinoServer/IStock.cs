//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer;

/// <summary>
/// Casino标的
/// </summary>
public interface IStock
{
    /// <summary>
    /// 代码
    /// 600001_SH
    /// </summary>
    string Code { get; set; }

    /// <summary>
    /// 600001
    /// </summary>
    string Symbol { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    string Name { get; set; }
}
