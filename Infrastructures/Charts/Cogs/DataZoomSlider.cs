// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 滑动条型数据区域缩放组件
/// https://echarts.apache.org/zh/option.html#dataZoom-slider
/// </summary>
public class DataZoomSlider
    : DataZoom
{
    public DataZoomSlider()
    {
        Type = ECharts.DataZoomType.Slider;
    }
    
}