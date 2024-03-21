// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;

namespace Ban3.Infrastructures.Charts.Elements;

public class GeneralLine
    : IHasLine
{
    #region IHasLine

    /// 
    public bool? Show { get; set; } = true;

    ///
    public LineStyle? LineStyle { get; set; }

    ///
    public object? Interval { get; set; }

    #endregion
}