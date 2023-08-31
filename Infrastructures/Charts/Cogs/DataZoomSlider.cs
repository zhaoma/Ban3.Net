//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    滑动条型数据区域缩放组件
//  reference:https://echarts.apache.org/zh/option.html#dataZoom-slider
//  ————————————————————————————————————————————————————————————————————————————

using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// 
public class DataZoomSlider
    : DataZoom
{
    public DataZoomSlider()
    {
        Type = ECharts.DataZoomType.Slider;
    }
    
}