
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC;

public class TfvcLabelRef
{
    public TfvcLabelRef()
    {
    }

    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("owner")] public IdentityRef Owner { get; set; }

    [JsonProperty("labelScope")] public string LabelScope { get; set; }

    [JsonProperty("modifiedDate")] public string ModifiedDate { get; set; }

    [JsonProperty("url")] public string Url { get; set; }
}