using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Post for retrieving a set of items given a list of paths or a long path.
/// Allows for specifying the recursionLevel and version descriptors for each path.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get-items-batch?view=azure-devops-rest-7.0
/// </summary>
public class GetBatchedItems
    : PresetRequest, IRequest
{
    public GetBatchedItems() { Method = "Post"; }
        
    public GetBatchedItemsBody? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/itembatch";

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}