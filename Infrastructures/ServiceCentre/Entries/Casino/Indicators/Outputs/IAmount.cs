using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 
/// </summary>
public interface IAmount : IOutput
{
    /// <summary>
    /// 
    /// </summary>
    IEnumerable<ILine<double>> Lines { get; set; }
}

