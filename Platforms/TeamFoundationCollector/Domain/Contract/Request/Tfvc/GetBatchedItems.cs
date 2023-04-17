﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Post for retrieving a set of items given a list of paths or a long path.
/// Allows for specifying the recursionLevel and version descriptors for each path.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get-items-batch?view=azure-devops-rest-7.0&tabs=HTTP
/// </summary>
public class GetBatchedItems
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Post";

    /// <summary>
    /// Version of the API to use. This should be set to '7.0' to use this version of the api.
    /// </summary>
    public string ApiVersion { get; set; } = "7.0";

    public GetBatchedItemsBody? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/itembatch";

    public string RequestQuery() => $"?api-version={ApiVersion}";

    public string RequestBody() => JsonConvert.SerializeObject(Body);
}