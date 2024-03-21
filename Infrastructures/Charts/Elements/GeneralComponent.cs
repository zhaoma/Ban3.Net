// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Charts.Elements;

public class GeneralComponent
    : IHasIdentity, IHasPosition
{
    #region IHasIdentity

    /// 
    public string? Id { get; set; }

    /// 
    public bool? Show { get; set; }

    /// 
    public int? ZLevel { get; set; }

    /// 
    public int? Z { get; set; }

    #endregion

    #region IHasPosition

    /// "auto"
    public object? Left { get; set; }

    /// 
    public object? Top { get; set; }

    /// 
    public object? Right { get; set; }

    /// 
    public object? Bottom { get; set; }

    ///
    public object? Width { get; set; }

    /// 
    public object? Height { get; set; }

    #endregion
}