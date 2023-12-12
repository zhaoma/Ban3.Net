// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 指标线
/// </summary>
/// <typeparam name="T"></typeparam>
public class Line<T> : ILine<T>
{
    public int Duration { get; set; }

    public T Value { get; set; }
}