//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 地址信息
/// </summary>
public class Address : MetaBase, IZero
{
    /// <summary>
    /// 地址的非结构化
    /// </summary>
    public string FormattedValue { get; set; }

    /// <summary>
    /// 类型翻译
    /// </summary>
    public string FormattedType { get; set; }

    /// <summary>
    /// 国家代码
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// 国家
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    ///区域地址
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// 街道地址
    /// </summary>
    public string StreetAddress { get; set; }

    /// <summary>
    /// 扩展地址
    /// </summary>
    public string ExtendedAddress { get; set; }
}
