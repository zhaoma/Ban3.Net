namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

public class Target
{
    public string Instance { get; set; }

    public string Collection { get; set; } = "CT";

    public string Project { get; set; } = "CTS";

    public string UserName { get; set; }

    public string Password { get; set; }
}