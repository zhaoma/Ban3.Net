using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace Ban3.Infrastructures.LcmConfig.Entries;

public class ManagedExe
    : ManagedProcess
{
    public string File { get; set; }

    public string Description { get; set; }

    public string Arguments { get; set; }

    public string User { get; set; }

    public bool HideMainWindow { get; set; }

    public string Dependency { get; set; }

}
