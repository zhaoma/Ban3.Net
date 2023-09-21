using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.WIQL;

public class WorkItemFieldReference
{
    [JsonProperty("referenceName")] public string ReferenceName { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("url")] public string Url { get; set; }
}