//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/30 10:14
//  function:	GeneralLine.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

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