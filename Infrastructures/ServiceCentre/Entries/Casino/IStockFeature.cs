using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino;

/// <summary>
/// 标的特征声明
/// </summary>
public interface IStockFeature : IStockRecord
{
    /// <summary>
    /// 特质集合
    /// </summary>
    IEnumerable<string> Keys { get; set; }
}

