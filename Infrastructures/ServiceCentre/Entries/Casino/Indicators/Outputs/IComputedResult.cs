using System.Collections.Generic;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 计算结果声明
/// </summary>
public interface IComputedResult : IStockRecord
{
    /// <summary>
    /// 分析周期
    /// </summary>
    AnalysisCycle AnalysisCycle { get; set; }

    /// <summary>
    /// 成交量均线
    /// </summary>
    IAmount Amount { get; set; }

    /// <summary>
    /// 乖离率
    /// </summary>
    IBias Bias { get; set; }

    /// <summary>
    /// 
    /// </summary>
    ICci Cci { get; set; }

    IDmi Dmi { get; set; }

    IEne Ene { get; set; }

    IKd Kd { get; set; }

    IMa Ma { get; set; }

    IMacd Macd { get; set; }

    int Evaluation { get; set; }

    /// <summary>
    /// 特质集合
    /// </summary>
    IEnumerable<string> Keys { get; set; }
}

