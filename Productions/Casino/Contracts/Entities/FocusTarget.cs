#nullable enable
using System.Collections.Generic;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class FocusTarget
{

    public string Name { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;

    public FocusData? Days { get; set; }

    public FocusData? Weeks { get; set; }

    public FocusData? Months { get; set; }


}