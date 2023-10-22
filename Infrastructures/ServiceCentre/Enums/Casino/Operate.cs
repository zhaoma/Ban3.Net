using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

public enum Operate
{
    /// <summary>
    /// 买进
    /// </summary>
    [Description("买进")]
    Buy = 1,
    /// <summary>
    /// 持有
    /// </summary>
    [Description("持有")]
    Keep = 2,
    /// <summary>
    /// 卖出
    /// </summary>
    [Description("卖出")]
    Sell = 3,
    /// <summary>
    /// 舍弃
    /// </summary>
    [Description("舍弃")]
    Left = 4
}

