//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    内置型数据区域缩放组件
//  reference:https://echarts.apache.org/zh/option.html#dataZoom-inside
//  ————————————————————————————————————————————————————————————————————————————

using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 内置型数据区域缩放组件（dataZoomInside）
/// </summary>
public class DataZoomInside : DataZoom
{
    public DataZoomInside()
    {
        Type = ECharts.DataZoomType.Inside;
    }

}