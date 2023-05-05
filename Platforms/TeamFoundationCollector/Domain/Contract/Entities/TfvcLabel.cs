using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Metadata for a label.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/labels/get?view=azure-devops-rest-7.0#tfvclabel
/// </summary>
public class TfvcLabel
    : TfvcLabelRef
{
    /// <summary>
    /// List of items.
    /// </summary>
    [JsonProperty("items")]
    public List<TfvcItem>? Items { get; set; }

}