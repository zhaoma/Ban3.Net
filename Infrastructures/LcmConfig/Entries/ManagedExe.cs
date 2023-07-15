
namespace Ban3.Infrastructures.LcmConfig.Entries;

public class ManagedExe
    : ManagedProcess
{
    public string File { get; set; } = string.Empty;

    public string Description { get; set; }

    public string Arguments { get; set; }

    public string User { get; set; }

    public bool HideMainWindow { get; set; }

    public string Dependency { get; set; }

}
