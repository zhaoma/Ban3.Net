using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC;

public class TfvcShallowBranchRef
{
    public TfvcShallowBranchRef()
    {
    }

    /// <summary>
    /// Path for the branch.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; }
}