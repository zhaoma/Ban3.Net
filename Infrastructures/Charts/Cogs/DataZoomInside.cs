// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 内置型数据区域缩放组件（dataZoomInside）
/// https://echarts.apache.org/zh/option.html#dataZoom-inside
/// </summary>
public class DataZoomInside : DataZoom
{
    public DataZoomInside()
    {
        Type = ECharts.DataZoomType.Inside;
    }

}