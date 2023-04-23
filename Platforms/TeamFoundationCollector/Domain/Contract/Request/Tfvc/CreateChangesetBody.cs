﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/create?view=azure-devops-rest-7.0
/// </summary>
public class CreateChangesetBody
    : TfvcChangeset
{

}