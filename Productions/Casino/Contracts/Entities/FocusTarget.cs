#nullable enable

namespace Ban3.Productions.Casino.Contracts.Entities;

/// 
public class FocusTarget
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 代码
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 日线筛选结果
    /// </summary>
    public FocusData? Days { get; set; }

    /// <summary>
    /// 周线筛选结果
    /// </summary>
    public FocusData? Weeks { get; set; }

    /// <summary>
    /// 月线筛选结果
    /// </summary>
    public FocusData? Months { get; set; }
}