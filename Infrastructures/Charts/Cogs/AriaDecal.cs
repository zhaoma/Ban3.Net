// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 为系列数据增加贴花纹理，作为颜色的辅助，帮助区分数据。
/// 使用默认贴花图案的方式非常简单，只需要开启即可
/// https://echarts.apache.org/zh/option.html#aria.decal
/// </summary>
public class AriaDecal
{
    /// <summary>
    /// 是否显示贴花图案，默认不显示。如果要显示贴花，
    /// 需要保证 aria.enabled 与 aria.decal.show 都是 true。
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Show { get; set; }
}
