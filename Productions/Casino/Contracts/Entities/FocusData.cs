using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class FocusData
{
    public FocusData()
    {
        Previous = new List<FocusRecord>();
        Current=new List<FocusRecord>();
    }

    public int Total { get; set; }

    public List<FocusRecord> Previous { get; set; }

    public Dictionary<string, int> PreviousKeys()
        => Previous.Select(o=>o.SetKeys).MergeToDictionary();

    public List<FocusRecord> Current { get; set; }

    public Dictionary<string, int> CurrentKeys()
        => Current.Select(o => o.SetKeys).MergeToDictionary();
}