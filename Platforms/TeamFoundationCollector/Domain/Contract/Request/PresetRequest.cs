using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request;

public class PresetRequest
{
    public string Instance { get; set; } = string.Empty;

    public string Organization { get; set; } = string.Empty;

    public string Project { get; set; } = string.Empty;

}