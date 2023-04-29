namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request;

public class PresetRequest
{
    public string Instance { get; set; } =Config.Target.Instance;

    public string Organization { get; set; } = Config.Target.Organization;

    public string Project { get; set; } = Config.Target.Project;
    
    public string ApiVersion { get; set; } = Config.Target.ApiVersion;

    public string Method { get; set; } = "Get";

    public virtual string QueryString()
    {

        var result = new Dictionary<string, object>();

        this.Parse(result);
    }

    public virtual string RequestBody() => string.Empty;
}