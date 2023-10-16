using System;
namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 随机震荡指数
/// </summary>
public interface IKd
{
    /// <summary>
    /// 
    /// </summary>
    decimal K { get; set; }

    /// <summary>
    /// 
    /// </summary>
    decimal D { get; set; }
}

