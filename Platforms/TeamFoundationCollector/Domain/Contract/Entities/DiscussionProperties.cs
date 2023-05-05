using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

public class DiscussionProperties
{
    public string ItemPath { get; set; } = string.Empty;

    public int StartLine { get; set; }

    public int EndLine { get; set; }

    public int StartColumn { get; set; }

    public int EndColumn { get; set; }

    public string PositionContext { get; set; } = string.Empty;

    public int SupportsMarkdown { get; set; }

    public string UniqueID { get; set; } = string.Empty;

    public DiscussionProperties(Dictionary<string, TypeAndValue>? properties)
    {
        if (properties == null) return;

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.ItemPath"))
            ItemPath = properties["Microsoft.TeamFoundation.Discussion.ItemPath"].Value+"";

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.Position.StartLine"))
            StartLine = properties["Microsoft.TeamFoundation.Discussion.Position.StartLine"].Value.ToInt();

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.Position.EndLine"))
            EndLine = properties["Microsoft.TeamFoundation.Discussion.Position.EndLine"].Value.ToInt();

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.Position.StartColumn"))
            StartColumn = properties["Microsoft.TeamFoundation.Discussion.Position.StartColumn"].Value.ToInt();

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.Position.EndColumn"))
            EndColumn = properties["Microsoft.TeamFoundation.Discussion.Position.EndColumn"].Value.ToInt();

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.Position.PositionContext"))
            PositionContext = properties["Microsoft.TeamFoundation.Discussion.Position.PositionContext"].Value + "";

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.SupportsMarkdown"))
            SupportsMarkdown = properties["Microsoft.TeamFoundation.Discussion.SupportsMarkdown"].Value.ToInt();

        if (properties.ContainsKey("Microsoft.TeamFoundation.Discussion.UniqueID"))
            UniqueID = properties["Microsoft.TeamFoundation.Discussion.UniqueID"].Value + "";
    }
}