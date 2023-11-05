using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// ​​LWR指标（LWR，Lary Williams R）是一种技术分析工具，是对经典的威廉指标（Williams %R）的一种改进和调整。
/// LWR指标基于威廉指标，通过对威廉指标的计算公式和参数进行修改，提供了更平滑的指标线，从而减少了噪音，并在一定程度上改善了指标的可读性和可用性。
/// LWR指标的计算方法与威廉指标类似，其计算公式如下：
/// 首先确定计算的时间周期，例如一般常用的周期为14天。
/// 计算当日的LWR值：LWR值 = （最高价 - 当日收盘价）/ （最高价 - 最低价） × (-100)
/// 将计算得到的LWR值绘制成图表，形成LWR指标曲线。
/// 与威廉指标不同的是，LWR指标在计算时使用了更平滑的移动平均方法，因此相较于威廉指标，LWR指标的曲线更加平滑，能够过滤掉一些噪音，并且更加易于观察和解读。
/// 类似于威廉指标，LWR指标的取值范围在-100到0之间，其中-100表示市场处于超买状态，0表示市场处于超卖状态。
/// RSV:= (HHV(HIGH,N)-CLOSE)/(HHV(HIGH,N)-LLV(LOW,N))*100;
/// </summary>
public interface ILwr
{
    /// <summary>
    /// LWR1:SMA(RSV,M1,1);
    /// </summary>
    [JsonProperty("lwr1")]
    decimal LWR1 { get; set; }

    /// <summary>
    /// LWR2:SMA(LWR1,M2,1);
    /// </summary>
    [JsonProperty("lwr2")]
    decimal LWR2 { get; set; }
}

