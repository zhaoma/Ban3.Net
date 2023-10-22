using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 图表生成接口声明
/// </summary>
public interface IChartsHelper
{
    /// <summary>
    /// 创建图表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="chartsDiagram"></param>
    /// <returns></returns>
    Task<bool> TryCreate<T>(T data,out IChartsDiagram chartsDiagram);
}

