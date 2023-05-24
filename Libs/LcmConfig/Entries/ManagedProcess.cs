using System.Collections.Generic;

namespace Ban3.Infrastructures.LcmConfig.Entries;

public class ManagedProcess
{
    public string Name { get; set; }

    public bool IsAutoRestart { get; set; }

    public int DelayStartInMs { get; set; }

    public bool IsRunOncePerStart { get; set; }

    /// <summary>
    /// 依赖
    /// </summary>
    public List<ManagedProcess> Children { get; set; }

    public List<ManagedProcess> Parents { get; set; }
}