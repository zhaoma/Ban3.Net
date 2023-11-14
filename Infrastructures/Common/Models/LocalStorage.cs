// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Common.Models;

/// <summary>
/// 本地存储设置
/// </summary>
public class LocalStorage
{
    /// <summary>
    /// 目录物理根目录
    /// </summary>
    public string RootPath { get; set; } = string.Empty;

    /// <summary>
    /// Url根地址
    /// </summary>
    public string RootUrl { get; set; } = string.Empty;
}