#nullable enable

namespace Ban3.Productions.Casino.Contracts.Entities;

public class FocusTarget
{
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public FocusData? Days { get; set; }

    public FocusData? Weeks { get; set; }

    public FocusData? Months { get; set; }


}