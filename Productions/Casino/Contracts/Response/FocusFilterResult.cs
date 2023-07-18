using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Entities;

namespace Ban3.Productions.Casino.Contracts.Response;

/// <summary>
/// 
/// </summary>
public class FocusFilterResult
{
    /// 
    public FocusFilterResult()
    {
        Targets = new Dictionary<string, FocusTarget>();
    }

    /// 
    public Dictionary<string ,FocusTarget> Targets { get; set; }

    static readonly object ObjLock = new ();

    /// 
    public void Append(string code, FocusTarget target)
    {
        lock (ObjLock)
        {
            if (Targets.ContainsKey(code))
            {
                Targets[code] = target;
            }
            else
            {
                Targets.Add(code,target);
            }
        }
    }
}