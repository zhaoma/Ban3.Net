//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 缩放和还原的标题文本
/// </summary>
public class DataZoomTitle
{
    /// <summary>
    /// 缩放的标题文本
    /// </summary>
    [JsonProperty("zoom", NullValueHandling = NullValueHandling.Ignore)]
    public string? Zoom { get; set; }

    /// <summary>
    /// 还原的标题文本
    /// </summary>
    [JsonProperty("back", NullValueHandling = NullValueHandling.Ignore)]
    public string? Back { get; set; }
}
