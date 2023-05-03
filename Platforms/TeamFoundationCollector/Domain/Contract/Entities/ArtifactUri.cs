using System.Net;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

public class ArtifactUri
{
    public ArtifactUri()
    {
        NeedUrlEncode = true;
    }

    public ArtifactUri(int changesetId)
    {
        Type = ArtifactType.Changeset;
        Id = changesetId + "";
    }

    public ArtifactUri(string shelvesetId, string shelvesetOwner)
    {
        Type = ArtifactType.Shelveset;
        Id = shelvesetId;
        Query = $"shelvesetOwner={shelvesetOwner}";
        NeedUrlEncode = true;
    }

    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ArtifactType Type { get; set; }

    [JsonProperty("query")]
    public string Query { get; set; } = string.Empty;

    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("needUrlEncode")]
    public bool NeedUrlEncode { get; set; }

    public override string ToString()
    {
        var query = Id;
        if (!string.IsNullOrEmpty(Query))
            query += $"&{Query}";

        query = NeedUrlEncode
            ? WebUtility.UrlEncode(query)
            : query;

        return $"vstfs:///VersionControl/{Type}/{query}";
    }
}

