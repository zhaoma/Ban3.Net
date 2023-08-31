using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 选框组件标题文本
/// </summary>
public class BrushSetting
{
    /// <summary>
    /// 矩形选择
    /// </summary>
    [JsonProperty("rect", NullValueHandling = NullValueHandling.Ignore)]
    public string? Rect { get; set; }

    /// <summary>
    /// 圈选
    /// </summary>
    [JsonProperty("polygon", NullValueHandling = NullValueHandling.Ignore)]
    public string? Polygon { get; set; }

    /// <summary>
    /// 横向选择
    /// </summary>
    [JsonProperty("lineX", NullValueHandling = NullValueHandling.Ignore)]
    public string? LineX { get; set; }

    /// <summary>
    /// 纵向选择
    /// </summary>
    [JsonProperty("lineY", NullValueHandling = NullValueHandling.Ignore)]
    public string? LineY { get; set; }

    /// <summary>
    /// 保持选择
    /// </summary>
    [JsonProperty("keep", NullValueHandling = NullValueHandling.Ignore)]
    public string? Keep { get; set; }

    /// <summary>
    /// 清除选择
    /// </summary>
    [JsonProperty("clear", NullValueHandling = NullValueHandling.Ignore)]
    public string? Clear { get; set; }
}