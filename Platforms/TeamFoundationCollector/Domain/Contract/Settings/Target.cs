namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings;

public class Target
{
    public string Instance { get; set; }

    public string Collection { get; set; } 

    public string Project { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
}